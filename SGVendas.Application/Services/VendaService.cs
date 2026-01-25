using System.Transactions;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;

public class VendaService : IVendaService
{
    private readonly IVendaCommandRepository _command;

    public VendaService(IVendaCommandRepository command)
    {
        _command = command;
    }

    public async Task<int> CriarVendaAsync(CriarVendaDto dto)
    {
        using var scope = new TransactionScope(
            TransactionScopeAsyncFlowOption.Enabled
        );

        // 1️⃣ VENDA
        var vendaId = await _command.RegistrarVendaAsync(
            dto.ClienteID,
            dto.FormaPgtoID,
            dto.VendedorID,
            dto.Observacoes
        );
        if (dto.FormaPgtoID <= 0)
            throw new Exception("Forma de pagamento inválida.");

        // 2️⃣ ITENS
        foreach (var item in dto.Itens)
        {
            await _command.RegistrarItemAsync(
                vendaId,
                item.ProdutoID,
                item.Quantidade,
                item.PrecoUnitario
            );
        }

        // 3️⃣ PARCELAS
        if (dto.Parcelas != null)
        {
            foreach (var p in dto.Parcelas)
            {
                await _command.GerarParcelaAsync(
                    vendaId,
                    p.Numero,
                    p.DataVencimento,
                    p.Valor
                );
            }
        }

        decimal totalVenda = 0;

        // 2️⃣ ITENS
        foreach (var item in dto.Itens)
        {
            totalVenda += item.Quantidade * item.PrecoUnitario;

            await _command.RegistrarItemAsync(
                vendaId,
                item.ProdutoID,
                item.Quantidade,
                item.PrecoUnitario);

                 // 🔥 BAIXA ESTOQUE
            await _command.BaixarEstoqueAsync(
                item.ProdutoID,
                item.Quantidade);
        }

        // 🔥 ATUALIZA TOTAL DA VENDA
        await _command.AtualizarValorTotalAsync(vendaId, totalVenda);

        scope.Complete();
        return vendaId;
    }
}

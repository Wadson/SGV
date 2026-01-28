using System.Transactions;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;
using System.Text.Json; // Adicione este using no topo do arquivo

public class VendaService : IVendaService
{
    private readonly IVendaCommandRepository _command;

    public VendaService(IVendaCommandRepository command)
    {
        _command = command;
    }

    public async Task<int> CriarVendaAsync(CriarVendaDto dto)
    {
        if (dto.Itens == null || !dto.Itens.Any())
            throw new Exception("A venda deve possuir itens.");

        if (dto.FormaPgtoID <= 0)
            throw new Exception("Forma de pagamento inválida.");

        // Serializa os itens para JSON conforme esperado pelo repositório
        var itensJson = JsonSerializer.Serialize(dto.Itens);

        var vendaId = await _command.RegistrarVendaAsync(
          dto.ClienteID,
          dto.FormaPgtoID,
          dto.VendedorID,
          dto.Observacoes,
          dto.Itens // ✅ PASSA OS ITENS REAIS


      );
        // 🔥 BAIXAR ESTOQUE PRODUTO A PRODUTO
        foreach (var item in dto.Itens)
        {
            await _command.BaixarEstoqueAsync(
                item.ProdutoID,
                item.Quantidade
            );
        }

        // Parcelas continuam fora da SP (regra financeira)
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

        return vendaId;
    }

}

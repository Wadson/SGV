using SGVendas.Application.DTOs;

namespace SGVendas.Application.Interfaces
{
    public interface IVendaCommandRepository
    {
        Task<int> RegistrarVendaAsync(
            int clienteId,
            int formaPgtoId,
            int vendedorId,
            string? observacoes
        );

        Task RegistrarItemAsync(
            int vendaId,
            int produtoId,
            int quantidade,
            decimal precoUnitario
        );

        Task GerarParcelaAsync(
            int vendaId,
            int numeroParcela,
            DateTime dataVencimento,
            decimal valor
        );
    }


}

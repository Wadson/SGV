using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IVendaCommandRepository
    {
        Task<int> RegistrarVendaAsync(
            int clienteId,
            int? formaPgtoId,
            string? observacoes,
            string itensJson
        );
    }
}


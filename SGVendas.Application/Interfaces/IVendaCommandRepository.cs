using SGVendas.Application.DTOs;

namespace SGVendas.Application.Interfaces
{
    public interface IVendaCommandRepository
    {
        Task<int> RegistrarVendaAsync(CriarVendaDto dto);
    }
}

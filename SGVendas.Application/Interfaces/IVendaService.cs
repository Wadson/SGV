using SGVendas.Application.DTOs;

namespace SGVendas.Application.Interfaces
{
    public interface IVendaService
    {
        Task<int> CriarVendaAsync(CriarVendaDto dto);

        IEnumerable<VendaDto> ListarVendas();
    }
}

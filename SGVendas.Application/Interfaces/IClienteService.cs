using SGVendas.Application.DTOs;

namespace SGVendas.Application.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<ClienteDto> Buscar(string termo);
        IEnumerable<ClienteDto> ObterVendedores();
    }
}

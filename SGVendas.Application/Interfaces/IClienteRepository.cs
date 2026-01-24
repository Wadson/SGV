using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Buscar(string termo);
        IEnumerable<Cliente> ObterVendedores();
    }
}

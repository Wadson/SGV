using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> BuscarClientes(string termo);
        IEnumerable<Cliente> BuscarVendedores(string termo);
    }
}

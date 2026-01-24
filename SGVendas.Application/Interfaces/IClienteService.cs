using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<Cliente> BuscarClientes(string termo);
        IEnumerable<Cliente> BuscarVendedores(string termo);
    }
}

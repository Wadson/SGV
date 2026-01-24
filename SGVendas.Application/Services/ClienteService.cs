using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;

namespace SGVendas.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> BuscarClientes(string termo)
        {
            return _clienteRepository.BuscarClientes(termo);
        }

        public IEnumerable<Cliente> BuscarVendedores(string termo)
        {
            return _clienteRepository.BuscarVendedores(termo);
        }
    }
}

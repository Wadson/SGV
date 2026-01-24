using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;

namespace SGVendas.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ClienteDto> Buscar(string termo)
        {
            return _repository.Buscar(termo)
                .Select(c => new ClienteDto
                {
                    ClienteID = c.ClienteID,
                    Nome = c.Nome
                });
        }

        public IEnumerable<ClienteDto> ObterVendedores()
        {
            return _repository.ObterVendedores()
                .Select(c => new ClienteDto
                {
                    ClienteID = c.ClienteID,
                    Nome = c.Nome
                });
        }
    }
}

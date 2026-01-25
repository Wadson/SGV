using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;

namespace SGVendas.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteCadastroRepository _cadastroRepository;
        public ClienteService(IClienteRepository clienteRepository, IClienteCadastroRepository cadastroRepository)
        {
            _clienteRepository = clienteRepository;
            _cadastroRepository = cadastroRepository;
        }

        public IEnumerable<Cliente> BuscarClientes(string termo)
        {
            return _clienteRepository.BuscarClientes(termo);
        }

        public IEnumerable<Cliente> BuscarVendedores(string termo)
        {
            return _clienteRepository.BuscarVendedores(termo);
        }

        public IEnumerable<ClienteDto> Listar(string? filtro)
        {
            return _cadastroRepository.Listar()
                .Select(c => new ClienteDto
                {
                    ClienteID = c.ClienteID,
                    Nome = c.Nome,
                    Cpf = c.Cpf,
                    Telefone = c.Telefone,
                    Email = c.Email,
                    Status = c.Status
                });
        }


        public ClienteDto ObterPorId(int id)
        {
            var c = _cadastroRepository.ObterPorId(id);
            return new ClienteDto
            {
                ClienteID = c.ClienteID,
                Nome = c.Nome,
                Cpf = c.Cpf,
                Telefone = c.Telefone,
                Email = c.Email,
                Status = c.Status
            };
        }

        public void Criar(CriarClienteDto dto)
        {
            _cadastroRepository.Criar(new Cliente
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Telefone = dto.Telefone,
                Email = dto.Email,
                Status = 1,
                DataCriacao = DateTime.Now
            });
        }

        public void Atualizar(int id, CriarClienteDto dto)
        {
            var cliente = _cadastroRepository.ObterPorId(id);

            cliente.Nome = dto.Nome;
            cliente.Cpf = dto.Cpf;
            cliente.Telefone = dto.Telefone;
            cliente.Email = dto.Email;

            _cadastroRepository.Atualizar(cliente);
        }


        public void Excluir(int id)
        {
            _cadastroRepository.Excluir(id);
        }

    }
}

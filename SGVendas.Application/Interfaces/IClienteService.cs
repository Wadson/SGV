using SGVendas.Application.DTOs;
using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<Cliente> BuscarClientes(string termo);
        IEnumerable<Cliente> BuscarVendedores(string termo);

        IEnumerable<ClienteDto> Listar(string? filtro);
        ClienteDto ObterPorId(int id);
        void Criar(CriarClienteDto dto);
        void Atualizar(int id, CriarClienteDto dto);
        void Excluir(int id);
    }
}

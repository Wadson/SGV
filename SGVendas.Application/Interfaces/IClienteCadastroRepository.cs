using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IClienteCadastroRepository
    {
        IEnumerable<Cliente> Listar();
        IEnumerable<Cliente> Buscar(string termo);

        Cliente ObterPorId(int id);
        void Criar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int id);
    }
}

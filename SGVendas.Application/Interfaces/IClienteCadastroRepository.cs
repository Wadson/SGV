using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IClienteCadastroRepository
    {
        IEnumerable<Cliente> Listar();
        Cliente ObterPorId(int id);
        void Criar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int id);
    }
}

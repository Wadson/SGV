using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IProdutoRepository
    {
        // 🔍 Busca rápida (autocomplete / vendas)
        IEnumerable<Produto> BuscarProdutos(string termo);

        // 📄 Consulta
        Produto? ObterPorId(int produtoId);
        IEnumerable<Produto> Listar();

        // 🧱 CRUD
        void Add(Produto produto);
        void Atualizar(Produto produto);
        void Excluir(int produtoId);
    }
}

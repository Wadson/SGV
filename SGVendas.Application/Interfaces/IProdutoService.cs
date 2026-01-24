using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<Produto> BuscarProdutos(string termo);
        Produto? ObterProduto(int produtoId);
    }
}

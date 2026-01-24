using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> BuscarProdutos(string termo);
        Produto? ObterPorId(int produtoId);
    }
}

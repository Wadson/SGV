using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Buscar(string termo);
    }
}

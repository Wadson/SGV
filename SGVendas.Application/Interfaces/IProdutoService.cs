using SGVendas.Application.DTOs;

namespace SGVendas.Application.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoDto> Buscar(string termo);
    }
}

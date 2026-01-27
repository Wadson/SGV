using SGVendas.Application.DTOs;

namespace SGVendas.Application.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoDto> Listar();
        ProdutoDto? ObterPorId(int id);

        void Criar(ProdutoDto dto);
        void Atualizar(int id, ProdutoDto dto);
        void Excluir(int id);

        IEnumerable<ProdutoDto> BuscarProdutos(string termo);
    }
}

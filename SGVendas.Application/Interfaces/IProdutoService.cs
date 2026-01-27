using SGVendas.Application.DTOs;

namespace SGVendas.Application.Interfaces
{
    public interface IProdutoService
    {
       
        ProdutoDto? ObterPorId(int id);               

        // 🔍 Autocomplete (Venda)
        IEnumerable<Produto> BuscarProdutos(string termo);

        // 📄 Listagem geral
        IEnumerable<ProdutoDto> Listar();

        // 🔎 Pesquisa parcial (Tela de Produtos)
        IEnumerable<ProdutoDto> Pesquisar(string termo);

        // ➕ CRUD
        void Criar(ProdutoDto dto);
        void Atualizar(int id, ProdutoDto dto);
        void Excluir(int id);
    }
}

using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;

namespace SGVendas.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscarProdutos(string termo)
        {
            return _produtoRepository.BuscarProdutos(termo);
        }

        public Produto? ObterProduto(int produtoId)
        {
            return _produtoRepository.ObterPorId(produtoId);
        }
    }
}

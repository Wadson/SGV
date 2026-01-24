using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;
using SGVendas.Infra.Context;

namespace SGVendas.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SGVendasDbContext _context;

        public ProdutoRepository(SGVendasDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> BuscarProdutos(string termo)
        {
           
               return _context.Produtos
                .Where(p =>
                (p.Status == "Disponível" || p.Status == "Em Produção") &&
                p.NomeProduto.Contains(termo))

                .OrderBy(p => p.NomeProduto)
                .Take(10)
                .ToList();
        }

        public Produto? ObterPorId(int produtoId)
        {
            return _context.Produtos
                .FirstOrDefault(p => p.ProdutoID == produtoId);
        }
    }
}

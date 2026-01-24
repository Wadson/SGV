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

        public IEnumerable<Produto> Buscar(string termo)
        {
            return _context.Produtos
                .Where(p => p.NomeProduto.Contains(termo))
                .OrderBy(p => p.NomeProduto)
                .Take(20)
                .ToList();
        }
    }
}

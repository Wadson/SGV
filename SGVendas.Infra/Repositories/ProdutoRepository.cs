using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Produto> Listar()
        {
            return _context.Produto
                .AsNoTracking()
                .OrderBy(p => p.NomeProduto)
                .ToList();
        }

        public IEnumerable<Produto> BuscarProdutos(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
                return Enumerable.Empty<Produto>();

            return _context.Produto
                .Where(p =>
                    (p.Status == "Disponível" || p.Status == "Em Produção") &&
                    p.NomeProduto.Contains(termo))
                .OrderBy(p => p.NomeProduto)
                .Take(10)
                .ToList();
        }

        public IEnumerable<Produto> Pesquisar(string termo)
        {
            var query = _context.Produto
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(termo))
            {
                query = query.Where(p =>
                    EF.Functions.Like(p.NomeProduto, $"%{termo}%"));
            }

            return query
                .OrderBy(p => p.NomeProduto)
                .ToList();
        }

        public Produto? ObterPorId(int produtoId)
        {
            return _context.Produto
                .FirstOrDefault(p => p.ProdutoID == produtoId);
        }

        // 🔽 Métodos adicionais (necessários para o Service)

        public IQueryable<Produto> Query()
        {
            return _context.Produto
                .AsNoTracking()
                .OrderBy(p => p.NomeProduto);
        }

        public void Add(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _context.Produto.Update(produto);
            _context.SaveChanges();
        }

        public void Excluir(int produtoId)
        {
            var produto = _context.Produto.Find(produtoId);
            if (produto == null) return;

            _context.Produto.Remove(produto);
            _context.SaveChanges();
        }
    }
}

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




        // 🔽 Métodos adicionais (necessários para o Service)

        public IEnumerable<Produto> Listar()
        {
            return _context.Produtos
                .AsNoTracking()
                .OrderBy(p => p.NomeProduto)
                .ToList();
        }       
        public void Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void Excluir(int produtoId)
        {
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null) return;

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }
}

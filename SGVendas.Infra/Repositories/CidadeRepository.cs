using Microsoft.EntityFrameworkCore;
using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;
using SGVendas.Infra.Context;

namespace SGVendas.Infra.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly SGVendasDbContext _context;

        public CidadeRepository(SGVendasDbContext context)
        {
            _context = context;
        }

        public Cidade BuscarPorNomeEUf(string nome, string uf)
        {
            return _context.Cidade
                .Include(c => c.Estado)
                .AsNoTracking()
                .FirstOrDefault(c =>
                    c.Nome == nome &&
                    c.Estado.Uf == uf);
        }


        public Cidade ObterPorId(int id)
        {
            return _context.Cidade.Find(id);
        }
    }
}

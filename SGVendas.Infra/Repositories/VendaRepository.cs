using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;
using SGVendas.Infra.Context;

namespace SGVendas.Infra.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly SGVendasDbContext _context;

        public VendaRepository(SGVendasDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Venda venda)
        {
            _context.Vendas.Add(venda);
        }

        public Venda? ObterPorId(int vendaId)
        {
            return _context.Vendas
                .FirstOrDefault(v => v.VendaID == vendaId);
        }

        public IEnumerable<Venda> ObterTodas()
        {
            return _context.Vendas
                .OrderByDescending(v => v.DataVenda)
                .ToList();
        }
    }
}

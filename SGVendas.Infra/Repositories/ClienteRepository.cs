using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;
using SGVendas.Infra.Context;

namespace SGVendas.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SGVendasDbContext _context;

        public ClienteRepository(SGVendasDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> Buscar(string termo)
        {
            return _context.Clientes
                .Where(c => c.Nome.Contains(termo))
                .OrderBy(c => c.Nome)
                .Take(20)
                .ToList();
        }

        public IEnumerable<Cliente> ObterVendedores()
        {
            return _context.Clientes
                .Where(c => c.IsVendedor)
                .OrderBy(c => c.Nome)
                .ToList();
        }
    }
}

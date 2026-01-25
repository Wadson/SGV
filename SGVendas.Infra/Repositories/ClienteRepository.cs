using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;
using SGVendas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace SGVendas.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SGVendasDbContext _context;

        public ClienteRepository(SGVendasDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> BuscarClientes(string termo)
        {
            return _context.Clientes
                .Where(c => c.Nome.Contains(termo))
                .OrderBy(c => c.Nome)
                .Take(10)
                .ToList();
        }

        public IEnumerable<Cliente> BuscarVendedores(string termo)
        {
            return _context.Clientes
             .Where(c => c.IsVendedor && c.Status == 1 && c.Nome.Contains(termo))
             .OrderBy(c => c.Nome)
             .Take(10)
             .ToList();

        }
        public IEnumerable<Cliente> Listar(string filtro = null)
        {
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(c =>
                    c.Nome.Contains(filtro) ||
                    c.Cpf.Contains(filtro) ||
                    c.Cnpj.Contains(filtro));
            }

            return query.OrderBy(c => c.Nome).ToList();
        }


    }
}

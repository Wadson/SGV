using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;
using SGVendas.Infra.Context;
using System.Collections.Generic;
using System.Linq;
namespace SGVendas.Infra.Repositories
{
    /// <summary>
    /// Implementação do repositório de vendas usando Entity Framework Core.
    /// </summary>
    public class VendaRepository : IVendaRepository
    {
        private readonly SGVendasDbContext _context;

        /// <summary>
        /// DbContext é injetado automaticamente pelo ASP.NET Core.
        /// </summary>
        public VendaRepository(SGVendasDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Salva uma nova venda no banco.
        /// </summary>
        public int Adicionar(Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();

            return venda.VendaID;
        }

        /// <summary>
        /// Retorna todas as vendas cadastradas.
        /// </summary>
        public IEnumerable<Venda> ObterTodas()
        {
            return _context.Vendas.ToList();
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SGVendas.Application.Interfaces;
using SGVendas.Infra.Context;

namespace SGVendas.Infra.Repositories
{
    public class VendaCommandRepository : IVendaCommandRepository
    {
        private readonly SGVendasDbContext _context;

        public VendaCommandRepository(SGVendasDbContext context)
        {
            _context = context;
        }

        public async Task<int> RegistrarVendaAsync(
         int clienteId,
         int? formaPgtoId,
         string? observacoes,
         string itensJson)
        {
            var vendaIdParam = new SqlParameter("@VendaID", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.sp_registrar_venda @ClienteID, @FormaPgtoID, @Observacoes, @Itens",
                new SqlParameter("@ClienteID", clienteId),
                new SqlParameter("@FormaPgtoID", (object?)formaPgtoId ?? DBNull.Value),
                new SqlParameter("@Observacoes", (object?)observacoes ?? DBNull.Value),
                new SqlParameter("@Itens", itensJson)
            );

            return vendaIdParam.Value is int id ? id : 0;
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SGVendas.Application.Interfaces;
using SGVendas.Infra.Context;
using System;
using System.Linq;

namespace SGVendas.Infra.Repositories
{
    /// <summary>
    /// Implementação de comandos de venda via Stored Procedure.
    /// </summary>
    public class VendaCommandRepository : IVendaCommandRepository
    {
        private readonly SGVendasDbContext _context;

        public VendaCommandRepository(SGVendasDbContext context)
        {
            _context = context;
        }

        public int RegistrarVenda(
            int clienteID,
            int? formaPgtoID,
            string? observacoes,
            string itensJson
        )
        {
            // Parâmetros da stored procedure
            var pCliente = new SqlParameter("@ClienteID", clienteID);
            var pFormaPgto = new SqlParameter("@FormaPgtoID", formaPgtoID ?? (object)DBNull.Value);
            var pObs = new SqlParameter("@Observacoes", observacoes ?? (object)DBNull.Value);
            var pItens = new SqlParameter("@Itens", itensJson);

            // A SP retorna um SELECT com VendaID
            var vendaID = _context.Database
                .SqlQueryRaw<int>(
                    "EXEC sp_registrar_venda @ClienteID, @FormaPgtoID, @Observacoes, @Itens",
                    pCliente, pFormaPgto, pObs, pItens
                )
                .AsEnumerable()
                .First();

            return vendaID;
        }
    }
}

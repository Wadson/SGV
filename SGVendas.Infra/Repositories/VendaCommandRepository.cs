using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;
using SGVendas.Infra.Context;
using System.Data;

namespace SGVendas.Infra.Repositories
{
    public class VendaCommandRepository : IVendaCommandRepository
    {
        private readonly SGVendasDbContext _context;

        public VendaCommandRepository(SGVendasDbContext context)
        {
            _context = context;
        }

        public async Task<int> RegistrarVendaAsync(CriarVendaDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // =========================
                // 1️⃣ REGISTRA VENDA
                // =========================
                var vendaId = await _context.Database.ExecuteSqlRawAsync(
                    @"EXEC sp_registrar_venda 
                      @ClienteID,
                      @FormaPgtoID,
                      @VendedorID,
                      @Observacoes",
                    new SqlParameter("@ClienteID", dto.ClienteID),
                    new SqlParameter("@FormaPgtoID", dto.FormaPgtoID),
                    new SqlParameter("@VendedorID", dto.VendedorID),
                    new SqlParameter("@Observacoes", dto.Observacoes ?? (object)DBNull.Value)
                );

                // =========================
                // 2️⃣ ITENS + BAIXA ESTOQUE
                // =========================
                foreach (var item in dto.Itens)
                {
                    await _context.Database.ExecuteSqlRawAsync(
                        @"EXEC sp_registrar_item_venda 
                          @VendaID,
                          @ProdutoID,
                          @Quantidade,
                          @PrecoUnitario",
                        new SqlParameter("@VendaID", vendaId),
                        new SqlParameter("@ProdutoID", item.ProdutoID),
                        new SqlParameter("@Quantidade", item.Quantidade),
                        new SqlParameter("@PrecoUnitario", item.PrecoUnitario)
                    );
                }

                // =========================
                // 3️⃣ PARCELAS
                // =========================
                foreach (var parcela in dto.Parcelas)
                {
                    await _context.Database.ExecuteSqlRawAsync(
                        @"EXEC sp_gerar_parcela 
                          @VendaID,
                          @Numero,
                          @DataVencimento,
                          @Valor",
                        new SqlParameter("@VendaID", vendaId),
                        new SqlParameter("@Numero", parcela.Numero),
                        new SqlParameter("@DataVencimento", parcela.DataVencimento),
                        new SqlParameter("@Valor", parcela.Valor)
                    );
                }

                await transaction.CommitAsync();
                return vendaId;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

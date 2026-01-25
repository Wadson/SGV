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

        // ======================================================
        // REGISTRA VENDA + ITENS (SP sp_registrar_venda)
        // ======================================================
        public async Task<int> RegistrarVendaAsync(
           int clienteId,
           int formaPgtoId,
           int vendedorId,
           string? observacoes
       )
        {
            var vendaIdParam = new SqlParameter
            {
                ParameterName = "@VendaID",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            await _context.Database.ExecuteSqlRawAsync(
                @"
        EXEC sp_registrar_venda
            @ClienteID,
            @FormaPgtoID,
            @VendedorID,
            @Observacoes,
            @VendaID OUTPUT
        ",
                new SqlParameter("@ClienteID", clienteId),
                new SqlParameter("@FormaPgtoID", formaPgtoId),
                new SqlParameter("@VendedorID", vendedorId),
                new SqlParameter("@Observacoes", observacoes ?? (object)DBNull.Value),
                vendaIdParam
            );

            return (int)vendaIdParam.Value;
        }




        public async Task RegistrarItemAsync(
                                            int vendaId,
                                            int produtoId,
                                            int quantidade,
                                            decimal precoUnitario)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"INSERT INTO ItemVenda
        (
            VendaID,
            ProdutoID,
            Quantidade,
            PrecoUnitario,
            Subtotal
        )
        VALUES
        (
            @VendaID,
            @ProdutoID,
            @Quantidade,
            @PrecoUnitario,
            @Subtotal
        )",
                new SqlParameter("@VendaID", vendaId),
                new SqlParameter("@ProdutoID", produtoId),
                new SqlParameter("@Quantidade", quantidade),
                new SqlParameter("@PrecoUnitario", precoUnitario),
                new SqlParameter("@Subtotal", quantidade * precoUnitario)
            );
        }
       
        // ======================================================
        // REGISTRA PARCELA (SP OU INSERT DIRETO)
        // ======================================================
        public async Task GerarParcelaAsync(
            int vendaId,
            int numeroParcela,
            DateTime dataVencimento,
            decimal valor)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"
                INSERT INTO Parcela
                (
                    VendaID,
                    NumeroParcela,
                    DataVencimento,
                    ValorParcela,
                    Status
                )
                VALUES
                (
                    @VendaID,
                    @NumeroParcela,
                    @DataVencimento,
                    @ValorParcela,
                    'Pendente'
                )
                ",
                new SqlParameter("@VendaID", vendaId),
                new SqlParameter("@NumeroParcela", numeroParcela),
                new SqlParameter("@DataVencimento", dataVencimento),
                new SqlParameter("@ValorParcela", valor)
            );
        }

        public async Task AtualizarValorTotalAsync(int vendaId, decimal valorTotal)
        {
            await _context.Database.ExecuteSqlRawAsync(
                  @"UPDATE Venda
                  SET ValorTotal = @ValorTotal
                  WHERE VendaID = @VendaID",
                new SqlParameter("@ValorTotal", valorTotal),
                new SqlParameter("@VendaID", vendaId));
        }
        public async Task BaixarEstoqueAsync(int produtoId, int quantidade)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"UPDATE Produtos
                SET Estoque = Estoque - @Quantidade
                WHERE ProdutoID = @ProdutoID",
                new SqlParameter("@Quantidade", quantidade),
                new SqlParameter("@ProdutoID", produtoId));
        }
    }
}

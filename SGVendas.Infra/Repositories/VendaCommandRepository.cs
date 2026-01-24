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
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC sp_registrar_venda 
                    @ClienteID = {0},
                    @FormaPgtoID = {1},
                    @Observacoes = {2},
                    @Itens = {3}",
                clienteId,
                formaPgtoId,
                observacoes,
                itensJson
            );

            // A SP já insere e retorna o ID internamente
            // Se futuramente quiser OUTPUT, ajustamos
            return await _context.Vendas.MaxAsync(v => v.VendaID);
        }

        public async Task GerarParcelasAsync(
            int vendaId,
            int numeroParcelas,
            DateTime dataPrimeiroVencimento)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC sp_gerar_parcelas 
                    @VendaID = {0},
                    @NumeroParcelas = {1},
                    @DataPrimeiroVencimento = {2}",
                vendaId,
                numeroParcelas,
                dataPrimeiroVencimento
            );
        }
    }
}

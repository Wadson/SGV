using Microsoft.EntityFrameworkCore;
using SGVendas.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace SGVendas.Infra.Context
{
    public class SGVendasDbContext : DbContext
    {
        public DbSet<ItemVenda> ItensVenda => Set<ItemVenda>();
      
        public SGVendasDbContext(DbContextOptions<SGVendasDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cidade> Cidade { get; set; }        
        public DbSet<Estado> Estado { get; set; }

      

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Venda> Vendas => Set<Venda>();    
        public DbSet<Parcela> Parcelas => Set<Parcela>();       
        public DbSet<Produto> Produto => Set<Produto>();
        public DbSet<FormaPagamento> FormaPagamento => Set<FormaPagamento>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ===== CONFIGURAÇÃO CLIENTE (NULLABLES) =====
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Cpf)
                      .IsRequired(false);

                entity.Property(e => e.Cnpj)
                      .IsRequired(false);

                entity.Property(e => e.DataNascimento)
                      .IsRequired(false);

                entity.Property(e => e.CidadeID)
                      .IsRequired(false);
            });

            // 🔴 CORREÇÃO PARA TABELA PRODUTOS COM TRIGGER (NÃO QUEBRA NADA)
            modelBuilder.Entity<Produto>()
                .ToTable(tb => tb.UseSqlOutputClause(false));

            // Aplica automaticamente todos os mapeamentos da pasta Mappings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SGVendasDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }



    }
}

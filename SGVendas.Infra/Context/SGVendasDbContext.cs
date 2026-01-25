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
     
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Venda> Vendas => Set<Venda>();    
        public DbSet<Parcela> Parcelas => Set<Parcela>();       
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<FormaPagamento> FormaPagamento => Set<FormaPagamento>();
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica automaticamente todos os mapeamentos da pasta Mappings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SGVendasDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

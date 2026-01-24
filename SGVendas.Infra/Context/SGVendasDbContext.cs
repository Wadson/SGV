using Microsoft.EntityFrameworkCore;
using SGVendas.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace SGVendas.Infra.Context
{
    /// <summary>
    /// Contexto principal do Entity Framework.
    /// Representa a sessão de conexão com o banco de dados.
    /// </summary>
    public class SGVendasDbContext : DbContext
    {
        public DbSet<ItemVenda> ItensVenda => Set<ItemVenda>();

        /// <summary>
        /// Construtor usado pelo ASP.NET Core via DI.
        /// </summary>
        public SGVendasDbContext(DbContextOptions<SGVendasDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Tabela de Clientes.
        /// </summary>
        public DbSet<Cliente> Clientes => Set<Cliente>();

        /// <summary>
        /// Tabela de Vendas.
        /// </summary>
        public DbSet<Venda> Vendas => Set<Venda>();

        /// <summary>
        /// Tabela de Parcelas.
        /// </summary>
        public DbSet<Parcela> Parcelas => Set<Parcela>();

        /// <summary>
        /// Método onde configuramos os mapeamentos.
        /// </summary>

        /// <summary>
        /// Tabela de Produtos.
        /// </summary>
        public DbSet<Produto> Produtos => Set<Produto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica automaticamente todos os mapeamentos da pasta Mappings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SGVendasDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

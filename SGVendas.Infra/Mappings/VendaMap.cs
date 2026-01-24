using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

namespace SGVendas.Infra.Mappings
{
    /// <summary>
    /// Mapeamento da entidade Venda.
    /// </summary>
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda");

            builder.HasKey(v => v.VendaID);

            builder.Property(v => v.ValorTotal)
                   .HasColumnType("decimal(18,2)");

            builder.Property(v => v.Desconto)
                   .HasColumnType("decimal(18,2)");

            builder.Property(v => v.StatusVenda)
                   .HasConversion<string>() // Enum → string
                   .IsRequired();

            // Relacionamento Venda → Parcelas
            builder.HasMany(v => v.Parcelas)
                   .WithOne()
                   .HasForeignKey(p => p.VendaID);
        }
    }
}

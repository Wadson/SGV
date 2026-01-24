using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

namespace SGVendas.Infra.Mappings
{
    /// <summary>
    /// Mapeamento da entidade Parcela.
    /// </summary>
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable("Parcela");

            builder.HasKey(p => p.ParcelaID);

            builder.Property(p => p.ValorParcela)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ValorRecebido)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Status)
                   .HasConversion<string>() // Enum → NVARCHAR
                   .IsRequired();
        }
    }
}

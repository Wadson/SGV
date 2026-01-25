using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

public class EstadoMap : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estado");

        builder.HasKey(e => e.EstadoID);

        builder.Property(e => e.Nome)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(e => e.Uf)
               .HasMaxLength(2)
               .IsRequired();
    }
}

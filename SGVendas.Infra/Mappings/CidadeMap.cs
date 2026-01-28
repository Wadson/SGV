using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

namespace SGVendas.Infra.Mappings
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");

            builder.HasKey(c => c.CidadeID);

            builder.Property(c => c.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasOne(c => c.Estado)
                    .WithMany(e => e.Cidades)
                    .HasForeignKey(c => c.EstadoID)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

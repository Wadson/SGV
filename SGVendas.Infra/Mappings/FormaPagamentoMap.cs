using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

namespace SGVendas.Infra.Mappings
{
    public class FormaPagamentoMap : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.ToTable("FormaPagamento");

            builder.HasKey(f => f.FormaPgtoID);

            builder.Property(f => f.NomeFormaPagamento)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(f => f.Ativo)
                   .IsRequired();
        }
    }
}

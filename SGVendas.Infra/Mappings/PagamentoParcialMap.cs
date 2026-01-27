using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

namespace SGVendas.Infra.Mappings
{
    public class PagamentoParcialMap : IEntityTypeConfiguration<PagamentoParcial>
    {
        public void Configure(EntityTypeBuilder<PagamentoParcial> builder)
        {
            builder.ToTable("PagamentosParciais");

            builder.HasKey(p => p.PagamentoID);

            builder.Property(p => p.ValorPago)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(p => p.DataPagamento)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(p => p.Observacao)
                   .HasMaxLength(300);

            builder.HasOne(p => p.Parcela)
                   .WithMany()
                   .HasForeignKey(p => p.ParcelaID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.FormaPgto)
                   .WithMany()
                   .HasForeignKey(p => p.FormaPgtoID)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(p => p.ParcelaID);
        }
    }
}

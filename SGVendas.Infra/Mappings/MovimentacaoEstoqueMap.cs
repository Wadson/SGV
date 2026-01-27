using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

public class MovimentacaoEstoqueMap : IEntityTypeConfiguration<MovimentacaoEstoque>
{
    public void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
    {
        builder.ToTable("MovimentacaoEstoque");

        builder.HasKey(m => m.MovimentacaoID);

        builder.Property(m => m.TipoMovimentacao)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(m => m.Origem)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(m => m.DataMovimentacao)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.HasOne(m => m.Produto)
               .WithMany(p => p.MovimentacaoEstoques)
               .HasForeignKey(m => m.ProdutoID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.ProdutoID);

        builder.Property(p => p.NomeProduto)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(p => p.Referencia)
               .HasMaxLength(50);

        builder.Property(p => p.PrecoCusto)
               .HasPrecision(18, 2);

        builder.Property(p => p.PrecoDeVenda)
               .HasPrecision(18, 2);

        builder.Property(p => p.Status)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasOne(p => p.Fornecedor)
               .WithMany(f => f.Produto)
               .HasForeignKey(p => p.FornecedorID)
               .OnDelete(DeleteBehavior.SetNull);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PedidoMap : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");

        builder.HasKey(p => p.PedidoID);

        builder.Property(p => p.DataPedido)
               .HasColumnType("date")
               .IsRequired();

        builder.Property(p => p.ValorTotalPedido)
               .HasPrecision(18, 2)
               .IsRequired();

        builder.HasOne(p => p.Fornecedor)
               .WithMany(f => f.Pedidos)
               .HasForeignKey(p => p.FornecedorID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

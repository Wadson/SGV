using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ItensPedidoMap : IEntityTypeConfiguration<ItensPedido>
{
    public void Configure(EntityTypeBuilder<ItensPedido> builder)
    {
        builder.ToTable("ItensPedidos");

        builder.HasKey(i => i.ItensPedidoID);

        builder.Property(i => i.Referencia)
               .HasMaxLength(50);

        builder.Property(i => i.Quantidade)
               .IsRequired();

        builder.HasOne(i => i.Pedido)
               .WithMany(p => p.ItensPedidos)
               .HasForeignKey(i => i.PedidoID)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

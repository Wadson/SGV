using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

namespace SGVendas.Infra.Mappings
{
    /// <summary>
    /// Mapeamento da entidade ItemVenda para a tabela ItemVenda.
    /// </summary>
    public class ItemVendaMap : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("ItemVenda");

            builder.HasKey(i => i.ItemVendaID);

            builder.Property(i => i.Quantidade)
                   .IsRequired();

            builder.Property(i => i.PrecoUnitario)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(i => i.Subtotal)
                   .HasColumnType("decimal(18,2)");

            builder.Property(i => i.DescontoItem)
        .HasColumnType("decimal(18,2)");


            builder.HasOne<Venda>()
                   .WithMany()
                   .HasForeignKey(i => i.VendaID);
        }
    }
}

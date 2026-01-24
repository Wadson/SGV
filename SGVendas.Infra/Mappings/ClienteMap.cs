using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

namespace SGVendas.Infra.Mappings
{
    /// <summary>
    /// Mapeamento da entidade Cliente para a tabela Clientes.
    /// </summary>
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Nome da tabela
            builder.ToTable("Clientes");

            // Chave primária
            builder.HasKey(c => c.ClienteID);

            // Propriedades
            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .HasMaxLength(100);

            builder.Property(c => c.Telefone)
                   .HasMaxLength(20);

            builder.Property(c => c.Status)
                   .HasDefaultValue(true);
        }
    }
}

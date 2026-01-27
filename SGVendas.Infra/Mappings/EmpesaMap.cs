using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

namespace SGVendas.Infra.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");

            builder.HasKey(e => e.EmpresaID);

            builder.Property(e => e.RazaoSocial)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(e => e.NomeFantasia)
                   .HasMaxLength(200);

            builder.Property(e => e.CNPJ)
                   .HasMaxLength(18)
                   .IsRequired();

            builder.HasIndex(e => e.CNPJ)
                   .IsUnique();

            builder.Property(e => e.Logradouro)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(e => e.Bairro)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.Cep)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(e => e.Cidade)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.UF)
                   .HasMaxLength(2)
                   .IsRequired();

            builder.Property(e => e.Email)
                   .HasMaxLength(150);

            builder.Property(e => e.Telefone)
                   .HasMaxLength(20);

            builder.Property(e => e.DataCriacao)
                   .HasDefaultValueSql("SYSDATETIME()");

            builder.Property(e => e.Logo)
                   .HasColumnType("varbinary(max)");
        }
    }
}

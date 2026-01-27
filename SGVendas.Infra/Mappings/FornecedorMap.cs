using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGVendas.Domain.Entities;

public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.ToTable("Fornecedores");

        builder.HasKey(f => f.FornecedorID);

        builder.Property(f => f.Nome)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(f => f.Cnpj)
               .HasMaxLength(18);

        builder.HasIndex(f => f.Cnpj)
               .IsUnique()
               .HasFilter("[Cnpj] IS NOT NULL");

        builder.Property(f => f.Email)
               .HasMaxLength(150);

        builder.Property(f => f.Telefone)
               .HasMaxLength(20);

        builder.Property(f => f.Cep)
               .HasMaxLength(10);

        builder.Property(f => f.DataCriacao)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.HasOne(f => f.Cidade)
               .WithMany()
               .HasForeignKey(f => f.CidadeID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

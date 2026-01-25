using SGVendas.Domain.Entities;

namespace SGVendas.Domain.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        public string Nome { get; set; } = null!;
        public string? TipoCliente { get; set; } = null!; // FISICA / JURIDICA
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public string? Telefone { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? Logradouro { get; set; } = null!;
        public string? Numero { get; set; } = null!;
        public string? Bairro { get; set; } = null!;
        public string? Cep { get; set; } = null!;
        public string? RG { get; set; }
        public string? OrgaoExpedidorRG { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? IE { get; set; }
        public int? CidadeID { get; set; }   // ⚠️ muito comum esquecer
        public Cidade? Cidade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataUltimaCompra { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string? UsuarioAtualizacao { get; set; }
        public decimal? LimiteCredito { get; set; }
        public bool IsVendedor { get; set; }
        public int Status { get; set; }
        public string? Observacoes { get; set; }
    }
}
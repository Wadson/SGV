namespace SGVendas.Application.DTOs
{
    public class EmpresaDto
    {
        public int EmpresaID { get; set; }
        public string RazaoSocial { get; set; } = null!;
        public string? NomeFantasia { get; set; }
        public string CNPJ { get; set; } = null!;
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? CNAE { get; set; }
        public string Logradouro { get; set; } = null!;
        public string? Numero { get; set; }
        public string Bairro { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string UF { get; set; } = null!;
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; } = null!;
        public string? Responsavel { get; set; } = null!;
        public string? CertificadoDigital { get; set; } = null!;
        public DateTime? DataCriacao { get; set; } = null!;
        public DateTime? DataAtualizacao { get; set; } = null!;
        public string? UsuarioCriacao { get; set; } = null!;
        public string? UsuarioAtualizacao { get; set; } = null!;
        public byte[]? Logo { get; set; }
    }
}

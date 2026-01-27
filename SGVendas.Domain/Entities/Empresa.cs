using System;
using System.Collections.Generic;
using System.Text;

namespace SGVendas.Domain.Entities
{
    public class Empresa
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

        public string? Site { get; set; }

        public string? Responsavel { get; set; }

        public string? CertificadoDigital { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public string? UsuarioCriacao { get; set; }

        public string? UsuarioAtualizacao { get; set; }

        public byte[]? Logo { get; set; }
    }
}

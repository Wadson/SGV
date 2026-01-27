namespace SGVendas.Application.DTOs
{
    public class FornecedorDto
    {
        public int FornecedorID { get; set; }
        public string Nome { get; set; } = null!;
        public string? Cnpj { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public int CidadeID { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Cep { get; set; }
        public string? Observacoes { get; set; }
    }
}

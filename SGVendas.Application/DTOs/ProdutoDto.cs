namespace SGVendas.Application.DTOs
{
    public class ProdutoDto
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public decimal PrecoDeVenda { get; set; }      
        public string? Referencia { get; set; }
        public decimal PrecoCusto { get; set; }      
        public int Estoque { get; set; }
        public string Status { get; set; } = "Ativo";
        public string? Unidade { get; set; }
        public string? Marca { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? FornecedorID { get; set; }
        public decimal Lucro { get; set; }
                       
        public DateTime DataDeEntrada { get; set; }      
        public string? Situacao { get; set; }       
        public string? GtinEan { get; set; }
        public string? Imagem { get; set; }        
    }
}

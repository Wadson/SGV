namespace SGVendas.Domain.Entities
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string? Referencia { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal Lucro { get; set; }
        public decimal PrecoDeVenda { get; set; }
        public int Estoque { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

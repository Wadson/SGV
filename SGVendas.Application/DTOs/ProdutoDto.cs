namespace SGVendas.Application.DTOs
{
    public class ProdutoDto
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public decimal PrecoDeVenda { get; set; }
    }
}

namespace SGVendas.Application.DTOs
{
    public class ProdutoAutocompleteDto
    {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}

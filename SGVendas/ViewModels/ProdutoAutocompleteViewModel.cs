namespace SGVendas.Web.ViewModels.Produto
{
    public class ProdutoAutocompleteViewModel
    {
        public int id { get; set; }
        public string label { get; set; } = string.Empty;
        public string value { get; set; } = string.Empty;
        public decimal preco { get; set; }
        public int estoque { get; set; }
    }
}

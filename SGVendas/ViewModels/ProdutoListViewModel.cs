namespace SGVendas.Web.ViewModels
{
    public class ProdutoListViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Preco { get; set; } = string.Empty;
        public int Estoque { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

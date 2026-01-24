namespace SGVendas.Application.DTOs
{
    /// <summary>
    /// Representa um item enviado para composição de uma venda.
    /// </summary>
    public class ItemVendaDto
    {
        /// <summary>
        /// Produto vendido.
        /// </summary>
        public int ProdutoID { get; set; }

        /// <summary>
        /// Quantidade vendida.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço unitário no momento da venda.
        /// </summary>
        public decimal PrecoUnitario { get; set; }
    }
}

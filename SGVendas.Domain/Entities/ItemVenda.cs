namespace SGVendas.Domain.Entities
{
    /// <summary>
    /// Representa um item de uma venda.
    /// Corresponde exatamente à tabela ItemVenda.
    /// </summary>
    public class ItemVenda
    {
        /// <summary>
        /// Chave primária.
        /// </summary>
        public int ItemVendaID { get; set; }

        /// <summary>
        /// Venda à qual o item pertence.
        /// </summary>
        public int VendaID { get; set; }

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

        /// <summary>
        /// Subtotal do item (Quantidade x Preço).
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Desconto aplicado especificamente ao item.
        /// </summary>
        public decimal? DescontoItem { get; set; }
    }
}

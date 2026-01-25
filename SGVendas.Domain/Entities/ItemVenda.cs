namespace SGVendas.Domain.Entities
{   
    public class ItemVenda
    {
      
        public int ItemVendaID { get; set; }
        public int VendaID { get; set; }      
        public int ProdutoID { get; set; }    
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? DescontoItem { get; set; }
    }
}

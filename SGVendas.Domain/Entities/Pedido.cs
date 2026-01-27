public partial class Pedido
{
    public int PedidoID { get; set; }

    public int FornecedorID { get; set; }

    public DateOnly DataPedido { get; set; }

    public decimal ValorTotalPedido { get; set; }

    public virtual Fornecedor Fornecedor { get; set; } = null!;

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}

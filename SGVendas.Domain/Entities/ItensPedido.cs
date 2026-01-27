public partial class ItensPedido
{
    public int ItensPedidoID { get; set; }

    public int PedidoID { get; set; }

    public string? Referencia { get; set; }

    public int Quantidade { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;
}

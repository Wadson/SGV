namespace SGVendas.Domain.Entities
{
    public class Estado
    {
        public int EstadoID { get; set; }
        public string Nome { get; set; } = null!;
        public string Uf { get; set; } = null!;
    }
}

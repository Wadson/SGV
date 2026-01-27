namespace SGVendas.Domain.Entities
{
    public class Estado
    {
        public int EstadoID { get; set; }

        public string Nome { get; set; } = null!;

        public string Uf { get; set; } = null!;

        public int? Ibge { get; set; }

        public int? Pais { get; set; }

        public string? Ddd { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();
    }
}

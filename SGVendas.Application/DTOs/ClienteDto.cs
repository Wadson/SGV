namespace SGVendas.Application.DTOs
{
    public class ClienteDto
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public int Status { get; set; }
        public List<ItemVendaDto> Itens { get; set; }
    }
}

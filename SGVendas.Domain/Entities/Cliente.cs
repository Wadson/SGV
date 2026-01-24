namespace SGVendas.Domain.Entities
{
    /// <summary>
    /// Representa um cliente do sistema.
    /// Pode ser comprador, vendedor ou ambos.
    /// </summary>
    public class Cliente
    {
      
        public int ClienteID { get; set; }     
        public string Nome { get; set; } = string.Empty;       
        public string? Cpf { get; set; }
      
        public string? Telefone { get; set; }
   
        public string? Email { get; set; }
      
        public int Status { get; set; }

        public bool IsVendedor { get; set; } = false;
    }
}

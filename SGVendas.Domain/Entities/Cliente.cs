namespace SGVendas.Domain.Entities
{
    /// <summary>
    /// Representa um cliente do sistema.
    /// Pode ser comprador, vendedor ou ambos.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Identificador único do cliente.
        /// Corresponde à chave primária no banco.
        /// </summary>
        public int ClienteID { get; set; }

        /// <summary>
        /// Nome completo ou razão social do cliente.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// CPF do cliente (pessoa física).
        /// </summary>
        public string? Cpf { get; set; }

        /// <summary>
        /// Telefone principal de contato.
        /// </summary>
        public string? Telefone { get; set; }

        /// <summary>
        /// Email do cliente.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Indica se o cliente está ativo no sistema.
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}

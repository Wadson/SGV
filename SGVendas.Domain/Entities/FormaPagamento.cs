namespace SGVendas.Domain.Entities
{
    /// <summary>
    /// Representa uma forma de pagamento (Dinheiro, Cartão, Pix, etc)
    /// </summary>
    public class FormaPagamento
    {
        public int FormaPgtoID { get; set; }

        public string NomeFormaPagamento { get; set; } = string.Empty;

        public bool Ativo { get; set; }
    }
}

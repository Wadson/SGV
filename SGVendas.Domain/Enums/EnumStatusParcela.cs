namespace SGVendas.Domain.Enums
{
    /// <summary>
    /// Representa o status de uma parcela financeira.
    /// </summary>
    public enum EnumStatusParcela
    {
        /// <summary>
        /// Parcela criada e ainda não paga.
        /// </summary>
        Pendente = 0,

        /// <summary>
        /// Parcela com pagamento parcial.
        /// </summary>
        ParcialmentePago = 1,

        /// <summary>
        /// Parcela totalmente quitada.
        /// </summary>
        Pago = 2,

        /// <summary>
        /// Parcela vencida e não paga.
        /// </summary>
        Atrasada = 3,

        /// <summary>
        /// Parcela cancelada.
        /// </summary>
        Cancelada = 4
    }
}

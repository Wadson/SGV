namespace SGVendas.Domain.Enums
{
    /// <summary>
    /// Representa o status de uma venda no sistema.
    /// Esse enum deve refletir exatamente os valores permitidos no banco.
    /// </summary>
    public enum EnumStatusVenda
    {
        /// <summary>
        /// Venda criada, mas ainda não finalizada.
        /// </summary>
        Aberta = 0,

        /// <summary>
        /// Venda finalizada, aguardando quitação das parcelas.
        /// </summary>
        AguardandoPagamento = 1,

        /// <summary>
        /// Venda totalmente paga.
        /// </summary>
        Concluida = 2,

        /// <summary>
        /// Venda cancelada pelo usuário ou sistema.
        /// </summary>
        Cancelada = 3,

        /// <summary>
        /// Venda temporariamente suspensa.
        /// </summary>
        Suspensa = 4
    }
}

namespace SGVendas.Application.Interfaces
{
    /// <summary>
    /// Repositório de comandos (escrita) da venda.
    /// Responsável por executar Stored Procedures.
    /// </summary>
    public interface IVendaCommandRepository
    {
        /// <summary>
        /// Registra a venda chamando a SP sp_registrar_venda.
        /// </summary>
        Task<int> RegistrarVendaAsync(
            int clienteId,
            int? formaPgtoId,
            string? observacoes,
            string itensJson
        );

        /// <summary>
        /// Gera as parcelas da venda chamando a SP sp_gerar_parcelas.
        /// </summary>
        Task GerarParcelasAsync(
            int vendaId,
            int numeroParcelas,
            DateTime dataPrimeiroVencimento
        );
    }
}

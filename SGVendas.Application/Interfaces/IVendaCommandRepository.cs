namespace SGVendas.Application.Interfaces
{
    /// <summary>
    /// Contrato para comandos de venda via Stored Procedure.
    /// </summary>
    public interface IVendaCommandRepository
    {
        /// <summary>
        /// Registra uma venda chamando a sp_registrar_venda.
        /// Retorna o ID da venda criada.
        /// </summary>
        int RegistrarVenda(
            int clienteID,
            int? formaPgtoID,
            string? observacoes,
            string itensJson
        );
    }
}

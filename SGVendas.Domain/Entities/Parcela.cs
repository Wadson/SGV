using SGVendas.Domain.Enums;
using System;

namespace SGVendas.Domain.Entities
{
    /// <summary>
    /// Representa uma parcela financeira de uma venda.
    /// </summary>
    public class Parcela
    {
        /// <summary>
        /// Identificador único da parcela.
        /// </summary>
        public int ParcelaID { get; set; }

        /// <summary>
        /// Identificador da venda associada.
        /// </summary>
        public int VendaID { get; set; }

        /// <summary>
        /// Número sequencial da parcela.
        /// </summary>
        public int NumeroParcela { get; set; }

        /// <summary>
        /// Data de vencimento da parcela.
        /// </summary>
        public DateTime DataVencimento { get; set; }

        /// <summary>
        /// Valor original da parcela.
        /// </summary>
        public decimal ValorParcela { get; set; }

        /// <summary>
        /// Valor já recebido.
        /// </summary>
        public decimal ValorRecebido { get; set; }

        /// <summary>
        /// Status atual da parcela.
        /// </summary>
        public EnumStatusParcela Status { get; set; } = EnumStatusParcela.Pendente;
    }
}

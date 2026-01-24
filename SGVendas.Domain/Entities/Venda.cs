using SGVendas.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SGVendas.Domain.Entities
{
    /// <summary>
    /// Representa uma venda realizada no sistema.
    /// </summary>
    public class Venda
    {
        /// <summary>
        /// Identificador único da venda.
        /// </summary>
        public int VendaID { get; set; }

        /// <summary>
        /// Cliente associado à venda.
        /// </summary>
        public int ClienteID { get; set; }

        /// <summary>
        /// Data e hora da venda.
        /// </summary>
        public DateTime DataVenda { get; set; } = DateTime.Now;

        /// <summary>
        /// Valor total da venda.
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Valor de desconto aplicado.
        /// </summary>
        public decimal Desconto { get; set; }

        /// <summary>
        /// Status atual da venda.
        /// </summary>
        public EnumStatusVenda StatusVenda { get; set; } = EnumStatusVenda.Aberta;

        /// <summary>
        /// Lista de parcelas associadas à venda.
        /// </summary>
        public List<Parcela> Parcelas { get; set; } = new();
    }
}

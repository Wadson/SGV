using SGVendas.Domain.Enums;
using System;

namespace SGVendas.Application.DTOs
{
    /// <summary>
    /// DTO usado para criar e consultar vendas.
    /// Não representa uma entidade do domínio.
    /// </summary>
    public class VendaDto
    {
        /// <summary>
        /// Identificador da venda.
        /// </summary>
        public int VendaID { get; set; }

        /// <summary>
        /// Cliente associado à venda.
        /// </summary>
        public int ClienteID { get; set; }

        /// <summary>
        /// Data da venda.
        /// </summary>
        public DateTime DataVenda { get; set; }

        /// <summary>
        /// Valor total da venda.
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Status atual da venda.
        /// </summary>
        public EnumStatusVenda StatusVenda { get; set; }
    }
}

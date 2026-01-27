using System;
using System.Collections.Generic;
using System.Text;

namespace SGVendas.Domain.Entities
{
    public class PagamentoParcial
    {
        public int PagamentoID { get; set; }

        public int ParcelaID { get; set; }

        public decimal ValorPago { get; set; }

        public DateOnly DataPagamento { get; set; }

        public int? FormaPgtoID { get; set; }

        public string? Observacao { get; set; }

        public virtual FormaPagamento? FormaPgto { get; set; }

        public virtual Parcela Parcela { get; set; } = null!;
    }
}

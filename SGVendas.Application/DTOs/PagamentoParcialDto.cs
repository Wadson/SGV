using System;

namespace SGVendas.Application.DTOs
{
    public class PagamentoParcialDto
    {
        public int PagamentoID { get; set; }
        public int ParcelaID { get; set; }
        public decimal ValorPago { get; set; }
        public DateOnly DataPagamento { get; set; }
        public int? FormaPgtoID { get; set; }
        public string? Observacao { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SGVendas.Application.DTOs
{
    public class CriarVendaDto
    {
        public int ClienteID { get; set; }
        public int VendedorID { get; set; }
        public int FormaPgtoID { get; set; }

        public string TipoPagamento { get; set; } = "avista"; // avista | parcelado
        public string? Observacoes { get; set; }

        public List<CriarVendaItemDto> Itens { get; set; } = new();
        public List<CriarParcelaDto> Parcelas { get; set; } = new();
    }

    public class CriarVendaItemDto
    {
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }

    public class CriarParcelaDto
    {
        public int Numero { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
    }
}

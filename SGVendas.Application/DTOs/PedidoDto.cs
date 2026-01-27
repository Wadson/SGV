using System;
using System.Collections.Generic;

namespace SGVendas.Application.DTOs
{
    public class PedidoDto
    {
        public int PedidoID { get; set; }
        public int FornecedorID { get; set; }
        public DateOnly DataPedido { get; set; }
        public decimal ValorTotalPedido { get; set; }

        public List<ItensPedidoDto> Itens { get; set; } = new();
    }
}

using SGVendas.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SGVendas.Domain.Entities
{  
    public class Venda
    {      
        public int VendaID { get; set; }
      
        public int ClienteID { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;
      
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }      
        public EnumStatusVenda StatusVenda { get; set; } = EnumStatusVenda.Aberta;

        /// <summary>
        /// Lista de parcelas associadas à venda.
        /// </summary>
        public List<Parcela> Parcelas { get; set; } = new();
    }
}

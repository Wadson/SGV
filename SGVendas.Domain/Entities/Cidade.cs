using System;
using System.Collections.Generic;
using System.Text;

namespace SGVendas.Domain.Entities
{
    public class Cidade
    {
        public int CidadeID { get; set; }
        public string Nome { get; set; } = null!;       
        public int EstadoID { get; set; }
        public Estado Estado { get; set; } = null!;
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace SGVendas.Application.DTOs
{
    public class CriarClienteDto
    {
        public string Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
    }

}

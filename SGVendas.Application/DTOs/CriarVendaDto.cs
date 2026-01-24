using System.Collections.Generic;

namespace SGVendas.Application.DTOs
{
    /// <summary>
    /// DTO usado exclusivamente para criação de uma venda.
    /// </summary>
    public class CriarVendaDto
    {

        /// <summary>
        /// Cliente da venda.
        /// </summary>
        public int ClienteID { get; set; }
        public int VendedorID { get; set; }      
        public int FormaPgtoID { get; set; }
        public string Observacoes { get; set; } = string.Empty;
        /// <summary>
        /// Lista de itens da venda.
        /// </summary>
        public List<ItemVendaDto> Itens { get; set; } = new();
    }
}

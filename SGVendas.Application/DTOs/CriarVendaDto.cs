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

        /// <summary>
        /// Vendedor responsável pela venda.
        /// </summary>
        public int VendedorID { get; set; }

        /// <summary>
        /// Forma de pagamento (opcional).
        /// </summary>
        public int? FormaPgtoID { get; set; }

        /// <summary>
        /// Observações da venda.
        /// </summary>
        public string? Observacoes { get; set; }

        /// <summary>
        /// Lista de itens da venda (entrada do usuário).
        /// </summary>
        public List<CriarVendaItemDto> Itens { get; set; } = new();
    }

    /// <summary>
    /// Item da venda usado apenas para criação.
    /// </summary>
    public class CriarVendaItemDto
    {
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}

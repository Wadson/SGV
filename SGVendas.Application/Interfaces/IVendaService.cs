using SGVendas.Application.DTOs;
using System.Collections.Generic;

namespace SGVendas.Application.Interfaces
{
    /// <summary>
    /// Contrato para serviços de venda.
    /// </summary>
    public interface IVendaService
    {
        /// <summary>
        /// Cria uma nova venda no sistema.
        /// </summary>
        int CriarVenda(CriarVendaDto dto);

        /// <summary>
        /// Retorna todas as vendas cadastradas.
        /// </summary>
        IEnumerable<VendaDto> ListarVendas();
    }
}

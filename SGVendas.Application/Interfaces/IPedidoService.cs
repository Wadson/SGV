using SGVendas.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGVendas.Application.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<PedidoDto?> ObterPorIdAsync(int pedidoId);
        Task<IEnumerable<PedidoDto>> ObterPorFornecedorAsync(int fornecedorId);
        Task<int> CriarPedidoAsync(PedidoDto pedidoDto);
    }
}

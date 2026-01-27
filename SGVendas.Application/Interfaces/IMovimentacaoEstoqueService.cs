using SGVendas.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGVendas.Application.Interfaces.Services
{
    public interface IMovimentacaoEstoqueService
    {
        Task<IEnumerable<MovimentacaoEstoqueDto>> ObterPorProdutoAsync(int produtoId);
        Task RegistrarMovimentacaoAsync(MovimentacaoEstoqueDto dto);
    }
}

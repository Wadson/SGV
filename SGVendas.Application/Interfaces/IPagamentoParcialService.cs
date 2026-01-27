using SGVendas.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGVendas.Application.Interfaces.Services
{
    public interface IPagamentoParcialService
    {
        Task<IEnumerable<PagamentoParcialDto>> ObterPorParcelaAsync(int parcelaId);
        Task RegistrarPagamentoAsync(PagamentoParcialDto dto);
    }
}

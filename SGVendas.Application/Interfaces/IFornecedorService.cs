using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGVendas.Application.Interfaces.Services
{
    public interface IFornecedorService : IBaseService<FornecedorDto>
    {
        Task<IEnumerable<FornecedorDto>> ObterPorCidadeAsync(int cidadeId);
    }
}

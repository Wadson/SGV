using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGVendas.Application.Interfaces.Common
{
    public interface IBaseService<TDto>
    {
        Task<TDto?> ObterPorIdAsync(int id);
        Task<IEnumerable<TDto>> ObterTodosAsync();
        Task<int> CriarAsync(TDto dto);
        Task AtualizarAsync(int id, TDto dto);
        Task RemoverAsync(int id);
    }
}

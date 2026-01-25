using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface ICidadeRepository
    {
        Cidade BuscarPorNomeEUf(string nome, string uf);
        Cidade ObterPorId(int id);
    }
}

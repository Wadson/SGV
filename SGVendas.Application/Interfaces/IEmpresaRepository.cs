using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    public interface IEmpresaRepository
    {
        IEnumerable<Empresa> Listar();
        Empresa? ObterPorId(int empresaId);
        void Criar(Empresa empresa);
        void Atualizar(Empresa empresa);
        void Excluir(int empresaId);
    }
}

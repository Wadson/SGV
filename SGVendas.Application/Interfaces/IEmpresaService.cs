using SGVendas.Application.DTOs;

namespace SGVendas.Application.Interfaces
{
    public interface IEmpresaService
    {
        IEnumerable<EmpresaDto> Listar(string? filtro);
        EmpresaDto ObterPorId(int id);
        void Criar(EmpresaDto dto);
        void Atualizar(int id, EmpresaDto dto);
        void Excluir(int id);
    }
}

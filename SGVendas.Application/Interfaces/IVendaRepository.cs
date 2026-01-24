using SGVendas.Domain.Entities;

namespace SGVendas.Application.Interfaces
{
    /// <summary>
    /// Contrato de acesso a dados da Venda
    /// </summary>
    public interface IVendaRepository
    {
        Venda? ObterPorId(int vendaId);

        IEnumerable<Venda> ObterTodas();

        void Adicionar(Venda venda);
    }
}

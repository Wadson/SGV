using SGVendas.Domain.Entities;
using System.Collections.Generic;

namespace SGVendas.Application.Interfaces
{
    /// <summary>
    /// Contrato de acesso a dados da entidade Venda.
    /// </summary>
    public interface IVendaRepository
    {
        /// <summary>
        /// Persiste uma nova venda no banco de dados.
        /// </summary>
        int Adicionar(Venda venda);

        /// <summary>
        /// Retorna todas as vendas cadastradas.
        /// </summary>
        IEnumerable<Venda> ObterTodas();
    }
}

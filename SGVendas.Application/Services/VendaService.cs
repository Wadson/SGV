using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;
using SGVendas.Domain.Enums;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;




namespace SGVendas.Application.Services
{
    /// <summary>
    /// Serviço de aplicação responsável por vendas.
    /// </summary>
    public class VendaService : IVendaService
    {
        private readonly IVendaCommandRepository _vendaCommandRepository;

        private readonly IVendaRepository _vendaRepository;

        /// <summary>
        /// Repositório é injetado automaticamente.
        /// </summary>
        public VendaService(IVendaRepository vendaRepository, IVendaCommandRepository vendaCommandRepository)
        {
            _vendaRepository = vendaRepository;
            _vendaCommandRepository = vendaCommandRepository;
        }

        /// <summary>
        /// Cria e salva uma nova venda no banco.
        /// </summary>
        public async Task<int> CriarVendaAsync(CriarVendaDto dto)

        {
            // Serializa os itens exatamente como a SP espera
            var itensJson = JsonSerializer.Serialize(
                dto.Itens.Select(i => new
                {
                    ProdutoID = i.ProdutoID,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario
                })
            );

            return await _vendaCommandRepository.RegistrarVendaAsync(
             dto.ClienteID,
             dto.FormaPgtoID,
             dto.Observacoes,
             itensJson
         );

        }

        /// <summary>
        /// Lista todas as vendas cadastradas.
        /// </summary>
        public IEnumerable<VendaDto> ListarVendas()
        {
            return _vendaRepository.ObterTodas()
                .Select(v => new VendaDto
                {
                    VendaID = v.VendaID,
                    ClienteID = v.ClienteID,
                    DataVenda = v.DataVenda,
                    ValorTotal = v.ValorTotal,
                    StatusVenda = v.StatusVenda
                });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;
using SGVendas.Application.Services;

namespace SGVendas.Web.Controllers
{
    /// <summary>
    /// Controller de API para suporte à tela de vendas (AJAX).
    /// </summary>
    [ApiController]
    [Route("api/venda")]
    public class VendaApiController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;
        private readonly IVendaService _vendaService;

        public VendaApiController(IClienteService clienteService, IProdutoService produtoService, IVendaService vendaService)
        {
            _clienteService = clienteService;
            _produtoService = produtoService;
            _vendaService = vendaService;
        }

        /// <summary>
        /// Retorna clientes (autocomplete).
        /// </summary>
        [HttpGet("clientes")]
        public IActionResult ObterClientes(string termo = "")
        {
            var clientes = _clienteService.BuscarClientes(termo);
            return Ok(clientes);
        }

        /// <summary>
        /// Retorna vendedores (clientes marcados como vendedor).
        /// </summary>
        [HttpGet("vendedores")]
        public IActionResult ObterVendedores(string termo)
        {
            var vendedores = _clienteService.BuscarVendedores(termo);

            return Ok(vendedores.Select(v => new
            {
                id = v.ClienteID,
                label = v.Nome,
                value = v.Nome
            }));
        }


        /// <summary>
        /// Retorna produtos (autocomplete).
        /// </summary>
        [HttpGet("produtos")]
        public IActionResult ObterProdutos(string termo = "")
        {
            var produtos = _produtoService.BuscarProdutos(termo);
            return Ok(produtos);
        }

        [HttpPost("finalizar")]
        public async Task<IActionResult> FinalizarVenda([FromBody] CriarVendaDto dto)
        {
            if (dto.Itens == null || !dto.Itens.Any())
                return BadRequest("Venda sem itens.");

            var vendaId = await _vendaService.CriarVendaAsync(dto);

            return Ok(new
            {
                sucesso = true,
                vendaId = vendaId
            });
        }
    }
}

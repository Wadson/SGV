using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.Interfaces;

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

        public VendaApiController(
            IClienteService clienteService,
            IProdutoService produtoService)
        {
            _clienteService = clienteService;
            _produtoService = produtoService;
        }

        /// <summary>
        /// Retorna clientes (autocomplete).
        /// </summary>
        [HttpGet("clientes")]
        public IActionResult ObterClientes(string termo = "")
        {
            var clientes = _clienteService.Buscar(termo);
            return Ok(clientes);
        }

        /// <summary>
        /// Retorna vendedores (clientes marcados como vendedor).
        /// </summary>
        [HttpGet("vendedores")]
        public IActionResult ObterVendedores()
        {
            var vendedores = _clienteService.ObterVendedores();
            return Ok(vendedores);
        }

        /// <summary>
        /// Retorna produtos (autocomplete).
        /// </summary>
        [HttpGet("produtos")]
        public IActionResult ObterProdutos(string termo = "")
        {
            var produtos = _produtoService.Buscar(termo);
            return Ok(produtos);
        }
    }
}

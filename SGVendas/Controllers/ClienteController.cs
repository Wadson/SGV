using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.Interfaces;

namespace SGVendas.Web.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("buscar")]
        public IActionResult BuscarClientes(string termo)
        {
            var clientes = _clienteService.BuscarClientes(termo);

            return Ok(clientes.Select(c => new
            {
                id = c.ClienteID,
                label = c.Nome,
                value = c.Nome
            }));
        }

        [HttpGet("vendedores")]
        public IActionResult BuscarVendedores(string termo)
        {
            var vendedores = _clienteService.BuscarVendedores(termo);

            return Ok(vendedores.Select(v => new
            {
                id = v.ClienteID,
                label = v.Nome,
                value = v.Nome
            }));
        }
    }
}

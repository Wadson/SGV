using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;
using SGVendas.Application.Services;

namespace SGVendas.Web.Controllers.Api
{
    [ApiController]
    [Route("api/vendas")]
    public class VendaApiController : ControllerBase    {
       
        private readonly IVendaService _vendaService;
        public VendaApiController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost("finalizar")]
        public async Task<IActionResult> Finalizar([FromBody] CriarVendaDto dto)
        {
            var vendaId = await _vendaService.CriarVendaAsync(dto);
            return Ok(new { vendaId });
        }

    }
}

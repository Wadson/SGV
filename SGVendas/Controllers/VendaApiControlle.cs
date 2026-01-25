using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;

namespace SGVendas.Web.Controllers.Api
{
    [ApiController]
    [Route("api/vendas")]
    public class VendaApiController : ControllerBase
    {
        private readonly IVendaService _service;

        public VendaApiController(IVendaService service)
        {
            _service = service;
        }

        [HttpPost("finalizar")]
        public async Task<IActionResult> Finalizar([FromBody] CriarVendaDto dto)
        {
            var vendaId = await _service.CriarVendaAsync(dto);
            return Ok(new { vendaId });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;

namespace SGVendas.Web.Controllers
{
    [ApiController]
    [Route("api/vendas")]
    public class VendasApiController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendasApiController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        // =====================================================
        // FINALIZAR VENDA (CHAMADO PELO AJAX)
        // =====================================================
        [HttpPost("finalizar")]
        public async Task<IActionResult> Finalizar([FromBody] CriarVendaDto dto)
        {
            Console.WriteLine("CHEGOU NO CONTROLLER");

            try
            {
                var vendaId = await _vendaService.CriarVendaAsync(dto);

                return Ok(new { vendaId });
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO: " + ex.Message);
                return BadRequest(new { erro = ex.Message });
            }
        }

    }
}

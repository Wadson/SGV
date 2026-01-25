using Microsoft.AspNetCore.Mvc;
using SGVendas.Infra.Context;

namespace SGVendas.Web.Controllers.Api
{
    [ApiController]
    [Route("api/formas-pagamento")]
    public class FormaPagamentoApiController : ControllerBase
    {
        private readonly SGVendasDbContext _context;

        public FormaPagamentoApiController(SGVendasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var formas = _context.FormaPagamento
                .Where(f => f.Ativo)
                .Select(f => new
                {
                    id = f.FormaPgtoID,
                    descricao = f.NomeFormaPagamento
                })
                .OrderBy(f => f.descricao)
                .ToList();

            return Ok(formas);
        }
    }
}

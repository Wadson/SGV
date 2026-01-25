using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.Interfaces;

namespace SGVendas.Web.Controllers
{
    [ApiController]
    [Route("api/cidades")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeRepository _repo;

        public CidadeController(ICidadeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("buscar")]
        public IActionResult Buscar(string nome, string uf)
        {
            var cidade = _repo.BuscarPorNomeEUf(nome, uf);

            if (cidade == null)
                return NotFound();

            return Ok(new
            {
                id = cidade.CidadeID,
                nome = cidade.Nome
            });
        }

    }
}

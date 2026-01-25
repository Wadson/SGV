using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SGVendas.Web.Controllers
{
    [ApiController]
    [Route("api/endereco")]
    public class EnderecoController : ControllerBase
    {
        [HttpGet("cep/{cep}")]
        public async Task<IActionResult> BuscarPorCep(string cep)
        {
            using var http = new HttpClient();
            var url = $"https://viacep.com.br/ws/{cep}/json/";
            var json = await http.GetStringAsync(url);

            if (json.Contains("erro"))
                return BadRequest("CEP não encontrado");

            return Ok(JsonDocument.Parse(json).RootElement);
        }
    }
}

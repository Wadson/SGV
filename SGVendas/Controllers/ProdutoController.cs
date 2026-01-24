using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.Interfaces;

namespace SGVendas.Web.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("buscar")]
        public IActionResult Buscar(string termo)
        {
            var produtos = _produtoService.BuscarProdutos(termo);

            return Ok(produtos.Select(p => new
            {
                id = p.ProdutoID,
                label = p.NomeProduto,
                value = p.NomeProduto,
                preco = p.PrecoDeVenda,
                estoque = p.Estoque
            }));
        }
    }
}

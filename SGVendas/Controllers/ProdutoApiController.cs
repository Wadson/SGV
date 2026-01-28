using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;

namespace SGVendas.Web.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoApiController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoApiController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("buscar")]
        public IActionResult Buscar(string termo)
        {
            var produtos = _produtoService.BuscarProdutos(termo);

            var result = produtos.Select(p => new ProdutoAutocompleteDto
            {
                Id = p.ProdutoID,
                Label = p.NomeProduto,
                Preco = p.PrecoDeVenda,
                Estoque = p.Estoque
            });

            return Ok(result);
        }



        // 🔍 PESQUISA DA TELA DE PRODUTOS       

        [HttpGet("pesquisar")]
        public IActionResult Pesquisar(string termo)
        {
            return Ok(_produtoService.Pesquisar(termo));
        }


        // 📄 LISTAGEM
        [HttpGet]
        public IActionResult Listar()
        {
            var produtos = _produtoService.Listar();
            return Ok(produtos);
        }


        // ➕ CADASTRO (API)
        [HttpPost]
        public IActionResult Create([FromBody] ProdutoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _produtoService.Criar(dto);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProdutoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _produtoService.Atualizar(id, dto);
            return Ok();
        }
    }
}

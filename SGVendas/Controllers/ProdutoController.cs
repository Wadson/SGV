using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;
using SGVendas.Application.Services;

namespace SGVendas.Web.Controllers
{
    public class ProdutoController : Controller
    {
        //private readonly ProdutoService? _produtoService_;
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }

        // ✏️ EDITAR (GET)
        public IActionResult Edit(int id)
        {
            var produto = _produtoService.ObterPorId(id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // 💾 EDITAR (POST)
        [HttpPost]
        public IActionResult Edit(ProdutoDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            _produtoService.Atualizar(dto.ProdutoID, dto);
            return RedirectToAction(nameof(Index));
        }

    }
}
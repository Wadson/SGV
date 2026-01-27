using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;

namespace SGVendas.Web.Controllers
{
    public class ProdutoViewController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoViewController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // 📄 LISTA
        public IActionResult Index()
        {
            return View();
        }

        // ➕ FORM NOVO
        public IActionResult Novo()
        {
            return View();
        }

        // 💾 SALVAR PRODUTO
        [HttpPost]
        public IActionResult Novo(ProdutoDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            _produtoService.Criar(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}

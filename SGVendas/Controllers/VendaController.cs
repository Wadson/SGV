using SGVendas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SGVendas.Web.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

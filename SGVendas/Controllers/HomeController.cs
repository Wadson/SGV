using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SGVendas.Models;

namespace SGVendas.Web.Controllers
{
    /// <summary>
    /// Controller inicial do sistema.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Página inicial.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}

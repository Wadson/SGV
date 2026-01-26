using Microsoft.AspNetCore.Mvc;
using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;

namespace SGVendas.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteCadastroRepository _repo;

        public ClienteController(IClienteCadastroRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string filtro)
        {
            var clientes = _repo.Listar();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                filtro = filtro.Trim().ToLower();

                clientes = clientes.Where(c =>
                    (!string.IsNullOrEmpty(c.Nome) && c.Nome.ToLower().Contains(filtro)) ||
                    (!string.IsNullOrEmpty(c.Cpf) && c.Cpf.Contains(filtro)) ||
                    (!string.IsNullOrEmpty(c.Cnpj) && c.Cnpj.Contains(filtro))
                ).ToList();
            }

            ViewBag.Total = clientes.Count();
            ViewBag.Filtro = filtro;

            return View(clientes);
        }


        [HttpGet]
        public IActionResult Criar()
        {
            return View(new Cliente());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Cliente cliente)
        {
            // 🔒 Validação PF / PJ
            if (cliente.TipoCliente == "FISICA")
            {
                cliente.Cnpj = null;
                cliente.IE = null;

                if (string.IsNullOrWhiteSpace(cliente.Cpf))
                    ModelState.AddModelError("Cpf", "CPF é obrigatório");

                if (string.IsNullOrWhiteSpace(cliente.Nome))
                    ModelState.AddModelError("Nome", "Nome é obrigatório");
            }
            else if (cliente.TipoCliente == "JURIDICA")
            {
                cliente.Cpf = null;
                cliente.RG = null;
                cliente.OrgaoExpedidorRG = null;
                cliente.DataNascimento = null;

                if (string.IsNullOrWhiteSpace(cliente.Cnpj))
                    ModelState.AddModelError("Cnpj", "CNPJ é obrigatório");

                if (string.IsNullOrWhiteSpace(cliente.Nome))
                    ModelState.AddModelError("Nome", "Razão Social é obrigatória");
            }
            else
            {
                ModelState.AddModelError("TipoCliente", "Selecione o tipo de cliente");
            }

            if (!ModelState.IsValid)
                return View(cliente);

            cliente.DataCriacao = DateTime.Now;
            cliente.Status = 1;

            _repo.Criar(cliente);

            TempData["Sucesso"] = "Cliente salvo com sucesso!";
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Editar(int id)
        {
            var cliente = _repo.ObterPorId(id);
            return View("Criar", cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            // mesma validação do Criar
            if (!ModelState.IsValid)
                return View("Criar", cliente);

            cliente.DataAtualizacao = DateTime.Now;
            _repo.Atualizar(cliente);


            TempData["Sucesso"] = "Cliente atualizado com sucesso!";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Excluir(int id)
        {
            _repo.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult BuscarAjax(string termo)
        {
            var clientes = string.IsNullOrWhiteSpace(termo)
                ? _repo.Listar()
                : _repo.Buscar(termo);

            return PartialView("_TabelaClientes", clientes);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using SistemaDeContatos.Models;
using SistemaDeContatos.Repositorio;

namespace SistemaDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio) {
			_contatoRepositorio = contatoRepositorio;
		}

        public IActionResult Index()
        {
            List<ContatoModel> lista = _contatoRepositorio.BuscarTodos();
            return View(lista);
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        public IActionResult AlterarContato(int id)
        {
          ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ExcluirContato(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult CriarContato(ContatoModel contatoModel)
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(contatoModel);
                return RedirectToAction("Index");
            }
            else
            {
                return View(contatoModel);
            }

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contatoModel)
        {
            _contatoRepositorio.Alterar(contatoModel);
            return RedirectToAction("Index");

        }


        public IActionResult Apagar(int id)
        {
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }


    }
}

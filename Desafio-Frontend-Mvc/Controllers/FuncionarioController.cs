using Desafio_Core.Models;
using Desafio_Frontend_Mvc.Interfaces;
using Desafio_Frontend_Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Frontend_Mvc.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _funcionarioService.GetAllAsync();
            return View(produtos);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _funcionarioService.GetAllAsync();
            if (!funcionario.Any(m => m.Id == id))
            {
                return NotFound();
            }

            var entrevistaHistorico = await _funcionarioService.RetornarHistoricoEntrevistaAsync(id);

            var viewModel = new FuncionarioDetalhes
            {
                Funcionario = funcionario.FirstOrDefault(m => m.Id == id),
                EntrevistaHistorico = entrevistaHistorico
            };

            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Idade, Mae, Pai")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _funcionarioService.CreateAsync(funcionario);
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _funcionarioService.GetAllAsync();
            var funcionario = resultado.FirstOrDefault(x => x.Id == id);

            if (funcionario is null || funcionario.Id.Equals(0))
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Idade, Mae, Pai")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _funcionarioService.UpdateByIdAsync(funcionario);
                }
                catch
                {
                    if (!await FuncionarioExiste(funcionario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();

            var resultado = await _funcionarioService.GetAllAsync();
            var funcionario = resultado.FirstOrDefault(x => x.Id == id);

            if (funcionario == null) return NotFound();

            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id, [Bind("Id,Nome,Idade,Mae,Pai")] Funcionario funcionario)
        {
            await _funcionarioService.DeleteAsync(funcionario);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FuncionarioExiste(long id)
        {
            var resultado = await _funcionarioService.GetAllAsync();
            return resultado.Any(e => e.Id == id);
        }
    }
}
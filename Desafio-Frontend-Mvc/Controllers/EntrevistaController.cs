using Desafio_Core.Models;
using Desafio_Frontend_Mvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Frontend_Mvc.Controllers
{
    public class EntrevistaController : Controller
    {
        private readonly IEntrevistaService _entrevistaService;

        public EntrevistaController(IEntrevistaService entrevistaService)
        {
            _entrevistaService = entrevistaService;
        }

        // GET: EntrevistaController
        public async Task<IActionResult> Index()
        {
            var entrevistas = await _entrevistaService.GetAllAsync();
            return View(entrevistas);
        }

        // GET: EntrevistaController/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: EntrevistaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntrevistaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,FuncionarioId,Empresa,DataEntrevista,Salario,Responsavel")] Entrevista entrevista)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _entrevistaService.CreateAsync(entrevista);
                    return RedirectToAction(nameof(Index));
                }
                return View(entrevista);
            }
            catch
            {
                return View();
            }
        }

        // GET: EntrevistaController/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            if (id <= 0) return NotFound();

            var resultado = await _entrevistaService.GetAllAsync();
            var entrevista = resultado.FirstOrDefault(x => x.Id == id);

            if (entrevista is null || entrevista.Id.Equals(0)) return NotFound();

            return View(entrevista);
        }

        // POST: EntrevistaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long id, [Bind("Id,FuncionarioId,Empresa,DataEntrevista,Salario,Responsavel")] Entrevista entrevista)
        {
            try
            {
                if (id != entrevista.Id) return NotFound();

                if (ModelState.IsValid)
                {
                    try
                    {
                        _entrevistaService.UpdateByIdAsync(entrevista);
                    }
                    catch
                    {
                        if (!await EntrevistaExiste(entrevista.Id)) 
                            return NotFound();
                        else
                            throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(entrevista);
            }
            catch
            {
                return View();
            }
        }

        // GET: EntrevistaController/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            if (id <= 0) return NotFound();

            var resultado = await _entrevistaService.GetAllAsync();
            var entrevista = resultado.FirstOrDefault(x => x.Id == id);

            if (entrevista == null) return NotFound();

            return View(entrevista);
        }

        // POST: EntrevistaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id, [Bind("Id,FuncionarioId,Empresa,DataEntrevista,Salario,Responsavel")] Entrevista entrevista)
        {
            try
            {
                await _entrevistaService.DeleteAsync(entrevista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private async Task<bool> EntrevistaExiste(long id)
        {
            var resultado = await _entrevistaService.GetAllAsync();
            return resultado.Any(e => e.Id == id);
        }
    }
}

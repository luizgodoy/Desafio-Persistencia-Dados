using Desafio_Core.Models;
using Desafio_Frontend_Mvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Frontend_Mvc.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService; 
        }

        // GET: Endereco
        public async Task<IActionResult> Index()
        {
            var enderecos = await _enderecoService.GetAllAsync();
            return View(enderecos);
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FuncionarioId,Rua,Numero,CEP,Cidade,Estado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoService.CreateAsync(endereco);
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // GET: Endereco/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            if (id <= 0) return NotFound();

            var resultado = await _enderecoService.GetAllAsync();
            var endereco = resultado.FirstOrDefault(x => x.Id == id);

            if (endereco is null || endereco.Id.Equals(0)) return NotFound();

            return View(endereco);
        }

        // POST: Endereco/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FuncionarioId,Rua,Numero,CEP,Cidade,Estado")] Endereco endereco)
        {
            if (id != endereco.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _enderecoService.UpdateByIdAsync(endereco);
                }
                catch
                {
                    if (!await EnderecoExiste(endereco.Id)) 
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            if (id <= 0) return NotFound();

            var resultado = await _enderecoService.GetAllAsync();
            var endereco = resultado.FirstOrDefault(x => x.Id == id);

            if (endereco == null) return NotFound();

            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,FuncionarioId,Rua,Numero,CEP,Cidade,Estado")] Endereco endereco)
        {
            await _enderecoService.DeleteAsync(endereco);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EnderecoExiste(long id)
        {
            var resultado = await _enderecoService.GetAllAsync();
            return resultado.Any(e => e.Id == id);
        }
    }
}
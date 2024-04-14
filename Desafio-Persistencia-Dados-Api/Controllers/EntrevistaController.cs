using Desafio_Core.Models;
using Desafio_Persistencia_Dados_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Persistencia_Dados_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrevistaController : ControllerBase
    {
        private readonly IEntrevistaService _entrevistaService;
        public EntrevistaController(IEntrevistaService entrevistaService)
        {
            _entrevistaService = entrevistaService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var resultado = await _entrevistaService.GetAllAsync();

            if (resultado is null || !resultado.Any())
            {
                return Ok(new List<Entrevista>());
            }

            return Ok(resultado);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(Entrevista entrevista)
        {
            await _entrevistaService.CreateAsync(entrevista);
            return Created();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(Entrevista entrevista, string descricao)
        {
            await _entrevistaService.AtualizarHistoricoEntrevista(entrevista, descricao);
            return Ok(entrevista);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> DeleteAsync([FromQuery] long id)
        {
            await _entrevistaService.DeleteAsync(id);
            return NoContent();
        }        

        [HttpGet("RetornaHistorico")]
        public async Task<IActionResult> RetornarHistoricoEntrevista([FromQuery] long funcionarioId)
        {
            var resultado = await _entrevistaService.ObterHistoricoEntrevistaPorFuncionarioId(funcionarioId);
            return Ok(resultado);
        }
    }
}
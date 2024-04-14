using Desafio_Core.Models;
using Desafio_Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Persistencia_Dados_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var resultado = await _funcionarioRepository.GetAllAsync();

            if (resultado is null || !resultado.Any())
            {
                return Ok(new List<Funcionario>());
            }

            return Ok(resultado);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(Funcionario funcionario)
        {
            await _funcionarioRepository.CreateAsync(funcionario);
            return Created();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(Funcionario funcionario)
        {
            await _funcionarioRepository.UpdateAsync(funcionario);
            return Ok(funcionario);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> DeleteAsync([FromQuery] long id)
        {
            await _funcionarioRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

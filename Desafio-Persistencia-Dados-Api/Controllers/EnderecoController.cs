using Desafio_Core.Models;
using Desafio_Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Persistencia_Dados_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        public readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var resultado = await _enderecoRepository.GetAllAsync();

            if (resultado is null || !resultado.Any())
            {
                return Ok(new List<Endereco>());
            }

            return Ok(resultado);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(Endereco endereco)
        {
            await _enderecoRepository.CreateAsync(endereco);
            return Created();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(Endereco endereco)
        {
            await _enderecoRepository.UpdateAsync(endereco);
            return Ok(endereco);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> DeleteAsync([FromQuery] long id)
        {
            await _enderecoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
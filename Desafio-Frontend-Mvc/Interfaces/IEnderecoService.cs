using Desafio_Core.Models;

namespace Desafio_Frontend_Mvc.Interfaces
{
    public interface IEnderecoService
    {
        public Task<IList<Endereco>> GetAllAsync();

        public void CreateAsync(Endereco endereco);

        public void UpdateByIdAsync(Endereco endereco);

        public Task DeleteAsync(Endereco endereco);
    }
}
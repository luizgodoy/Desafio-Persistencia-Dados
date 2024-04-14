using Desafio_Core.Models;

namespace Desafio_Data.Interfaces
{
    public interface IEnderecoRepository
    {
        public Task<IList<Endereco>> GetAllAsync();

        public Task CreateAsync(Endereco endereco);

        public Task UpdateAsync(Endereco endereco);

        public Task DeleteAsync(long id);
    }
}
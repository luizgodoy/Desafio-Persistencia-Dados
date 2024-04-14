using Desafio_Core.Models;

namespace Desafio_Data.Interfaces
{
    public interface IEntrevistaRepository
    {
        public Task<IList<Entrevista>> GetAllAsync();

        public Task CreateAsync(Entrevista entrevista);

        public Task UpdateAsync(Entrevista entrevista);

        public Task DeleteAsync(long id);
    }
}
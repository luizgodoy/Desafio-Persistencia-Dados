using Desafio_Core.Models;

namespace Desafio_Frontend_Mvc.Interfaces
{
    public interface IEntrevistaService
    {
        public Task<IList<Entrevista>> GetAllAsync();

        public void CreateAsync(Entrevista entrevista);

        public void UpdateByIdAsync(Entrevista entrevista);

        public Task DeleteAsync(Entrevista entrevista);
    }
}
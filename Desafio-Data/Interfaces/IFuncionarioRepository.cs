using Desafio_Core.Models;

namespace Desafio_Data.Interfaces
{
    public interface IFuncionarioRepository
    {
        public Task<IList<Funcionario>> GetAllAsync();

        public Task CreateAsync(Funcionario funcionario);

        public Task UpdateAsync(Funcionario funcionario);

        public Task DeleteAsync(long id);
    }
}

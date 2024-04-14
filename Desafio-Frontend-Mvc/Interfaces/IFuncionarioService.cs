using Desafio_Core.Models;

namespace Desafio_Frontend_Mvc.Interfaces
{
    public interface IFuncionarioService
    {
        public Task<IList<Funcionario>> GetAllAsync();
        public void CreateAsync(Funcionario funcionario);
        public void UpdateByIdAsync(Funcionario funcionario);
        public Task DeleteAsync(Funcionario funcionario);
        public Task<List<EntrevistaHistorico>> RetornarHistoricoEntrevistaAsync(long? id);
    }
}
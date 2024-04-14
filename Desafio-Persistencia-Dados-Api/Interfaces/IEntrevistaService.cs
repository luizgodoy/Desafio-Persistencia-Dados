using Desafio_Core.Models;

namespace Desafio_Persistencia_Dados_Api.Interfaces
{
    public interface IEntrevistaService
    {
        public Task<IList<Entrevista>> GetAllAsync();

        public Task CreateAsync(Entrevista entrevista);

        public Task UpdateAsync(Entrevista entrevista);

        public Task DeleteAsync(long id);

        public Task AtualizarHistoricoEntrevista(Entrevista entrevista, string descricao);

        public Task<List<EntrevistaHistorico>> ObterHistoricoEntrevistaPorFuncionarioId(long funcionarioId);
    }
}

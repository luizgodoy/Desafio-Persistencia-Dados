using Desafio_Core.Models;

namespace Desafio_Data.Interfaces
{
    public interface IEntrevistaHistoricoService
    {
        public Task RegistrarHistoricoEntrevista(long funcionarioId, double salarioAntigo, double salarioAtual, string descricao);
        public Task<List<EntrevistaHistorico>> ObterHistoricoEntrevistaPorFuncionario(long funcionarioId);
    }
}
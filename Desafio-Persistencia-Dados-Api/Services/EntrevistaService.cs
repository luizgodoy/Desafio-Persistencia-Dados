using Desafio_Core.Models;
using Desafio_Data.Interfaces;
using Desafio_Persistencia_Dados_Api.Interfaces;

namespace Desafio_Persistencia_Dados_Api.Services
{
    public class EntrevistaService : IEntrevistaService
    {
        private readonly IEntrevistaRepository _entrevistaRepository;
        private readonly IEntrevistaHistoricoService _entrevistaHistoricoService;

        public EntrevistaService(IEntrevistaRepository entrevistaRepository, IEntrevistaHistoricoService entrevistaHistoricoService)
        {
            _entrevistaRepository = entrevistaRepository;
            _entrevistaHistoricoService = entrevistaHistoricoService;
        }
        public async Task<IList<Entrevista>> GetAllAsync()
        {
            return await _entrevistaRepository.GetAllAsync();
        }
        public async Task CreateAsync(Entrevista entrevista)
        {
            await _entrevistaRepository.CreateAsync(entrevista);
        }
        public async Task DeleteAsync(long id)
        {
            await _entrevistaRepository.DeleteAsync(id);
        }        
        public async Task UpdateAsync(Entrevista entrevista)
        {
            await _entrevistaRepository.UpdateAsync(entrevista);
        }
        public async Task AtualizarHistoricoEntrevista(Entrevista entrevista, string descricao)
        {
            // Lógica para atualizar dados de entrevista
            var entrevistaAnterior = (await GetAllAsync()).FirstOrDefault(x => x.Id.Equals(entrevista.Id));

            if (entrevistaAnterior != null)
            {
                var salarioAntigo = entrevistaAnterior.Salario;
                await UpdateAsync(entrevista);

                // Registra um log de alteração salário
                await _entrevistaHistoricoService.RegistrarHistoricoEntrevista(entrevista.FuncionarioId, salarioAntigo, entrevista.Salario, descricao);
            }
        }
        public async Task<List<EntrevistaHistorico>> ObterHistoricoEntrevistaPorFuncionarioId(long funcionarioId)
        {
            return await _entrevistaHistoricoService.ObterHistoricoEntrevistaPorFuncionario(funcionarioId);
        }
    }
}
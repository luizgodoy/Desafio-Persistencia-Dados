using Desafio_Core.Models;
using Desafio_Data.Interfaces;
using MongoDB.Driver;

namespace Desafio_Data.Services
{
    public class EntrevistaHistoricoService : IEntrevistaHistoricoService
    {
        private readonly IMongoCollection<EntrevistaHistorico> _logCollection;

        public EntrevistaHistoricoService(IMongoClient mongoClient)
        {
            _logCollection = mongoClient.GetDatabase("4NETTDB").GetCollection<EntrevistaHistorico>("EntrevistaHistorico");
        }

        public async Task<List<EntrevistaHistorico>> ObterHistoricoEntrevistaPorFuncionario(long funcionarioId)
        {
            var filter = Builders<EntrevistaHistorico>.Filter.Eq(l => l.FuncionarioId, funcionarioId);
            return await _logCollection.Find(filter).ToListAsync();
        }

        public async Task RegistrarHistoricoEntrevista(long funcionarioId, double salarioAntigo, double salarioAtual, string descricao)
        {
            var log = new EntrevistaHistorico
            {
                FuncionarioId = funcionarioId,
                Descricao = descricao,
                SalarioAntigo = salarioAntigo,    
                SalarioAtual = salarioAtual,
                DataAlteracao = DateTime.Now
            };

            await _logCollection.InsertOneAsync(log);
        }
    }
}
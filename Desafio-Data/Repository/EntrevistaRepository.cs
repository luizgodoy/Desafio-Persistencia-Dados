using Dapper;
using Dapper.Contrib.Extensions;
using Desafio_Core.Models;
using Desafio_Data.Interfaces;
using System.Data;

namespace Desafio_Data.Repository
{
    public class EntrevistaRepository : IEntrevistaRepository
    {
        private readonly IDbConnection _context;

        public EntrevistaRepository(IDbConnection context)
        {
            _context = context;
        }

        public async Task CreateAsync(Entrevista entrevista)
        {
            var comandoSql = @"INSERT INTO ""FIAP"".""Entrevistas"" (""FuncionarioId"", ""Empresa"", ""DataEntrevista"", ""Salario"", ""Responsavel"") VALUES (@FuncionarioID, @Empresa, @DataEntrevista, @Salario, @Responsavel)";
            await _context.ExecuteAsync(comandoSql, entrevista);
        }

        public async Task DeleteAsync(long id)
        {
            var listaRegistros = await GetAllAsync();
            var entrevista = listaRegistros.FirstOrDefault(x => x.Id.Equals(id));

            if (entrevista != null)
            {
                await _context.DeleteAsync(entrevista);
            }
        }

        public async Task<IList<Entrevista>> GetAllAsync()
        {
            var resultado = await _context.GetAllAsync<Entrevista>();
            return resultado.ToList();
        }

        public async Task UpdateAsync(Entrevista entrevista)
        {
            var listaRegistros = await GetAllAsync();
            var entrevistaExistente = listaRegistros.FirstOrDefault(x => x.Id.Equals(entrevista.Id));

            if (entrevistaExistente != null)
            {
                entrevistaExistente.Empresa = entrevista.Empresa;
                entrevistaExistente.DataEntrevista = entrevista.DataEntrevista;
                entrevistaExistente.Salario = entrevista.Salario;
                entrevistaExistente.Responsavel = entrevista.Responsavel;

                await _context.UpdateAsync<Entrevista>(entrevistaExistente);
            }
        }
    }
}

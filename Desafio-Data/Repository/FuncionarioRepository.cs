using Dapper;
using Dapper.Contrib.Extensions;
using Desafio_Core.Models;
using Desafio_Data.Interfaces;
using System.Data;

namespace Desafio_Data.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IDbConnection _context;

        public FuncionarioRepository(IDbConnection context)
        {
            _context = context;
        }

        public async Task CreateAsync(Funcionario funcionario)
        {
            var comandoSql = @"INSERT INTO ""FIAP"".""Funcionarios"" (""Nome"", ""Idade"", ""Mae"", ""Pai"") VALUES (@Nome, @Idade, @Mae, @Pai)";
            await _context.ExecuteAsync(comandoSql, funcionario);
        }

        public async Task DeleteAsync(long id)
        {
            var listaRegistros = await GetAllAsync();
            var funcionario = listaRegistros.FirstOrDefault(x => x.Id.Equals(id));

            if (funcionario != null)
            {
                await _context.DeleteAsync(funcionario);
            }
        }

        public async Task<IList<Funcionario>> GetAllAsync()
        {
            var resultado = await _context.GetAllAsync<Funcionario>();
            return resultado.ToList();
        }

        public async Task UpdateAsync(Funcionario funcionario)
        {
            var listaRegistros = await GetAllAsync();
            var funcionarioExistente = listaRegistros.FirstOrDefault(x => x.Id.Equals(funcionario.Id));

            if (funcionarioExistente != null)
            {
                funcionarioExistente.Nome = funcionario.Nome;
                funcionarioExistente.Idade = funcionario.Idade;
                funcionarioExistente.Mae = funcionario.Mae;
                funcionarioExistente.Pai = funcionario.Pai;

                await _context.UpdateAsync<Funcionario>(funcionarioExistente);
            }
        }
    }
}

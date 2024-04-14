using Dapper;
using Dapper.Contrib.Extensions;
using Desafio_Core.Models;
using Desafio_Data.Interfaces;
using System.Data;

namespace Desafio_Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IDbConnection _context;

        public EnderecoRepository(IDbConnection context)
        {
            _context = context;
        }

        public async Task CreateAsync(Endereco endereco)
        {
            var comandoSql = @"INSERT INTO ""FIAP"".""Enderecos"" (""FuncionarioId"", ""Rua"", ""Numero"", ""Cep"", ""Cidade"", ""Estado"") VALUES (@FuncionarioId, @Rua, @Numero, @CEP, @Cidade, @Estado)";
            await _context.ExecuteAsync(comandoSql, endereco);
        }

        public async Task DeleteAsync(long id)
        {
            var listaRegistros = await GetAllAsync();
            var endereco = listaRegistros.FirstOrDefault(x => x.Id.Equals(id));

            if (endereco != null)
            {
                await _context.DeleteAsync(endereco);
            }
        }

        public async Task<IList<Endereco>> GetAllAsync()
        {
            var resultado = await _context.GetAllAsync<Endereco>();
            return resultado.ToList();
        }

        public async Task UpdateAsync(Endereco endereco)
        {
            var listaRegistros = await GetAllAsync();
            var enderecoExistente = listaRegistros.FirstOrDefault(x => x.Id.Equals(endereco.FuncionarioId));

            if (enderecoExistente != null)
            {
                enderecoExistente.Rua = endereco.Rua;
                enderecoExistente.Numero = endereco.Numero;
                enderecoExistente.CEP = endereco.CEP;
                enderecoExistente.Cidade = endereco.Cidade;
                enderecoExistente.Estado = endereco.Estado;

                await _context.UpdateAsync<Endereco>(enderecoExistente);
            }
        }
    }
}

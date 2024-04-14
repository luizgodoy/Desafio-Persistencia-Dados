
using Desafio_Data.Interfaces;
using Desafio_Data.Repository;
using Desafio_Data.Services;
using Desafio_Persistencia_Dados_Api.Interfaces;
using Desafio_Persistencia_Dados_Api.Services;
using MongoDB.Driver;
using Npgsql;
using System.Data;

namespace Desafio_Persistencia_Dados_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Realização a injeção de dependência do nosso BD
            var connectionString = configuration.GetValue<string>("ConnectionStringPostregres");
            builder.Services.AddScoped<IDbConnection>((connection) => new NpgsqlConnection(connectionString));
            
            // Configuração para MongoDB
            var connectionStringMongo = configuration.GetValue<string>("ConnectionStringMongo");
            builder.Services.AddScoped<IMongoClient>(serviceProvider => new MongoClient(connectionStringMongo));

            builder.Services.AddScoped<IEntrevistaService, EntrevistaService>();
            builder.Services.AddScoped<IEntrevistaHistoricoService, EntrevistaHistoricoService>();

            builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<IEntrevistaRepository, EntrevistaRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

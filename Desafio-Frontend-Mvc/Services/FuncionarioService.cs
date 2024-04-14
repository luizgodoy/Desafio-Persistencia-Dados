using Desafio_Core.Models;
using Desafio_Frontend_Mvc.Interfaces;

namespace Desafio_Frontend_Mvc.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string URL_API = "https://localhost:7132/api/Funcionario/";

        public FuncionarioService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<Funcionario>> GetAllAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<Funcionario[]>(URL_API + "GetAll");

            if (response != null)
            {
                return response.ToList();
            }
            else
            {
                return new List<Funcionario>();
            }
        }

        public async void CreateAsync(Funcionario funcionario)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API + "Create", funcionario);
        }

        public async void UpdateByIdAsync(Funcionario funcionario)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API + "Update", funcionario);
        }

        public async Task DeleteAsync(Funcionario funcionario)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.DeleteAsync(URL_API + $"Remove?id={funcionario.Id}");
        }

        public async Task<List<EntrevistaHistorico>> RetornarHistoricoEntrevistaAsync(long? id)
        {
            string URL_API_ENTREVISTA = "https://localhost:7132/api/Entrevista/";

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(URL_API_ENTREVISTA + $"RetornaHistorico?funcionarioId={id}");

            if (response != null && response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<EntrevistaHistorico>>();
            }
            else
            {
                return new List<EntrevistaHistorico>();
            }
        }
    }
}
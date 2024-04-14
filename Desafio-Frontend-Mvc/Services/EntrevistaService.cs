using Desafio_Core.Models;
using Desafio_Frontend_Mvc.Interfaces;

namespace Desafio_Frontend_Mvc.Services
{
    public class EntrevistaService : IEntrevistaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string URL_API = "https://localhost:7132/api/Entrevista/";

        public EntrevistaService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async void CreateAsync(Entrevista entrevista)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API + "Create", entrevista);
        }

        public async Task DeleteAsync(Entrevista entrevista)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.DeleteAsync(URL_API + $"Remove?id={entrevista.Id}");
        }

        public async Task<IList<Entrevista>> GetAllAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<Entrevista[]>(URL_API + "GetAll");

            if (response != null)
            {
                return response.ToList();
            }
            else
            {
                return new List<Entrevista>();
            }
        }

        public async void UpdateByIdAsync(Entrevista entrevista)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API + "Update", entrevista);
        }
    }
}

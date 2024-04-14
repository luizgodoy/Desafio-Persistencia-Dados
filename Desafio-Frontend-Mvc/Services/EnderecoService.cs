using Desafio_Core.Models;
using Desafio_Frontend_Mvc.Interfaces;

namespace Desafio_Frontend_Mvc.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string URL_API = "https://localhost:7132/api/Endereco/";

        public EnderecoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async void CreateAsync(Endereco endereco)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API + "Create", endereco);
        }

        public async Task DeleteAsync(Endereco endereco)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.DeleteAsync(URL_API + $"Remove?id={endereco.Id}");
        }

        public async Task<IList<Endereco>> GetAllAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<Endereco[]>(URL_API + "GetAll");

            if (response != null)
            {
                return response.ToList();
            }
            else
            {
                return new List<Endereco>();
            }
        }

        public async void UpdateByIdAsync(Endereco endereco)
        {
            var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(URL_API + "Update", endereco);
        }
    }
}

using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using PontoEletronico.Domain.Aggregates.Colaborador.Interfaces;
using PontoEletronico.Domain.Commands.Response;

namespace PontoEletronico.Domain.Aggregates.Colaborador
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ColaboradorService( IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<ColaboradorResponse> FindColaboradorByMatricula(string matricula)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://localhost:5000/colaborador/matricula/{matricula}");//colocar em variaveis de ambiente

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var post = await JsonSerializer.DeserializeAsync<ColaboradorResponse>(responseStream);

                return post;//.ativo ? post : null;
            }
            else return null;
        }

    }

}

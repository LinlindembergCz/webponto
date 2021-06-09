using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using PontoEletronico.Domain.Aggregates.Colaborador.Interfaces;
using PontoEletronico.Domain.Commands.Response;
using System;

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
        {   //colocar a rota em variaveis de ambiente 
            //caso mude, desta forma não precisará fazer manutenção e em seguida um novo deploy.
            //variavel : RotaFindColaboradorByMatricula: http://localhost:5000/colaborador/matricula/
            var rota = Environment.GetEnvironmentVariable("RotaFindColaboradorByMatricula",
                                                            EnvironmentVariableTarget.User);     

            var request = new HttpRequestMessage(HttpMethod.Get,$"{rota}{matricula}");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var post = await JsonSerializer.DeserializeAsync<ColaboradorResponse>(responseStream);

                return post;//.Ativo ? post : null;
            }
            else return null;
        }

    }

}

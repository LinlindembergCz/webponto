using AutoMapper;
using PontoEletronico.Application.Interfaces;
using PontoEletronico.Application.Commands.Request;
using PontoEletronico.Application.Commands.Response;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Text.Json;

namespace PontoEletronico.Application.Facade
{
    public class PontoFacade : IPontoFacade
    {
        private readonly IPontoService _Service;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;

        public PontoFacade(IPontoService service, IMapper mapper, IHttpClientFactory clientFactory)
        {
            _Service = service;
            _mapper = mapper;
            _clientFactory = clientFactory;
        }

        public async Task<List<PontoResponse>> FindAllAsync()
        {
            var result = await _Service.FindAllAsync();
            var response = new List<PontoResponse>();
            //response.ColaboradorObjects = new List<ColaboradorDto>();
            response.AddRange(result.Select(x => _mapper.Map<PontoResponse>(x)));
            return response;
        }

        private async Task<ColaboradorResponse> FindColaboradorByMatricula(string matricula)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://localhost:5000/colaborador/matricula/{matricula}");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {         
               using var responseStream = await response.Content.ReadAsStreamAsync();
               var post = await JsonSerializer.DeserializeAsync<ColaboradorResponse>(responseStream);
               return post;       
            }
            else return null;
        }

        public void CreateEntrada(string matricula)
        {
            var objeto = FindColaboradorByMatricula(matricula);

            PontoRequest newEntity = new PontoRequest
            {                
                ColaboradorId = objeto.Result.id,
                Nome = objeto.Result.nome
            };

            var entityMappered = _mapper.Map<Ponto>(newEntity);
            _Service.CreateEntrada(entityMappered);
        }

        public void CreateSaida(string matricula)
        {
            var objeto = FindColaboradorByMatricula(matricula);

            PontoRequest newEntity = new PontoRequest
            {
                ColaboradorId = objeto.Result.id,
                Nome = objeto.Result.nome
            };               

            var entityMappered = _mapper.Map<Ponto>(newEntity);
            _Service.CreateSaida(entityMappered);
        }

    }
}

using AutoMapper;
using PontoEletronico.Application.Interfaces;
using PontoEletronico.Domain.Commands.Request;
using PontoEletronico.Domain.Commands.Response;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PontoEletronico.Domain.Aggregates.Colaborador.Interfaces;

namespace PontoEletronico.Application.Facade
{
    public class PontoFacade : IPontoFacade
    {
        private readonly IPontoService _Service;
        private readonly IColaboradorService _ColaboradorService;  
        private readonly IMapper _mapper;

        public PontoFacade(IPontoService service, IColaboradorService colaboradorService , IMapper mapper)
        {
            _Service = service;
            _ColaboradorService = colaboradorService;
            _mapper = mapper;
        }

        public async Task<List<PontoResponse>> FindAllAsync()
        {
            var result = await _Service.FindAllAsync();
            var response = new List<PontoResponse>();
            //response.ColaboradorObjects = new List<ColaboradorDto>();
            response.AddRange(result.Select(x => _mapper.Map<PontoResponse>(x)));
            return response;
        }       
        public void CreateEntrada(string matricula)
        {
            var objeto = _ColaboradorService.FindColaboradorByMatricula(matricula);

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
            var objeto = _ColaboradorService.FindColaboradorByMatricula(matricula);

            PontoRequest newEntity = new PontoRequest
            {
                ColaboradorId = objeto.Result.id,
                Nome = objeto.Result.nome
            };               

            var entityMappered = _mapper.Map<Ponto>(newEntity);
            _Service.CreateSaida(entityMappered);
        }

        public async Task<List<PontosColaboradorResponse>> ListPontosColaborador(string matricula)
        {
            var result = await _Service.ListPontosColaborador(matricula);
            var response = new List<PontosColaboradorResponse>();
            response.AddRange(result.Select(x => _mapper.Map<PontosColaboradorResponse>(x)));
            return response;
        }

    }
}

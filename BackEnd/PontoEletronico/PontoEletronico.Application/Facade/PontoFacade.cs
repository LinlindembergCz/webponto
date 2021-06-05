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

namespace PontoEletronico.Application.Facade
{
    public class PontoFacade : IPontoFacade
    {
        private readonly IPontoService _Service;
        private readonly IMapper _mapper;

        public PontoFacade(IPontoService service, IMapper mapper)
        {
            _Service = service;
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


        public void CreateEntrada(PontoRequest entity)
        {
            var entityMappered = _mapper.Map<Ponto>(entity);
            _Service.CreateEntrada(entityMappered);
        }

        public void CreateSaida(PontoRequest entity)
        {
            var entityMappered = _mapper.Map<Ponto>(entity);
            _Service.CreateSaida(entityMappered);
        }

    }
}

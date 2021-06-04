using AutoMapper;
using WebPonto.Application.Interfaces;
using WebPonto.Application.Commands.Request;
using WebPonto.Application.Commands.Response;
using WebPonto.Domain.Aggregates.ColaboradorAggregate;
using WebPonto.Domain.Aggregates.ColaboradorAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace WebPonto.Application.Facade
{
    public class ColaboradorFacade : IColaboradorFacade
    {
        private readonly IColaboradorService _colaboradorService;
        private readonly IMapper _mapper;

        public ColaboradorFacade(IColaboradorService colaboradorService, IMapper mapper)
        {
            _colaboradorService = colaboradorService;
            _mapper = mapper;
        }

        public async Task<List<ColaboradorResponse>> FindAllAsync()
        {
            var result = await _colaboradorService.FindAllAsync();
            var response = new List<ColaboradorResponse>();
            //response.ColaboradorObjects = new List<ColaboradorDto>();
            response.AddRange(result.Select(x => _mapper.Map<ColaboradorResponse>(x)));
            return response;
        }

        public ColaboradorResponse FindById(Guid id)
        {
            var result = _colaboradorService.FindById(id);
            var response = new ColaboradorResponse();
            response = _mapper.Map<ColaboradorResponse>(result);
            return response;
        }

        public void CreateRequest(ColaboradorRequest entity)
        {
            var entityMappered = _mapper.Map<Colaborador>(entity);
            _colaboradorService.Create(entityMappered);
        }

        public void ModifyRequest(ColaboradorRequest entity)
        {
            var entityMappered = _mapper.Map<Colaborador>(entity);
            _colaboradorService.Modify(entityMappered);
        }

        public void Delete(Guid id)
        {
            _colaboradorService.Delete(id);
        }
    }
}

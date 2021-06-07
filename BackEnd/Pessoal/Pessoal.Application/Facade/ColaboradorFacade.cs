using AutoMapper;
using Pessoal.Application.Interfaces;
using Pessoal.Application.Commands.Request;
using Pessoal.Application.Commands.Response;
using Pessoal.Domain.Aggregates.ColaboradorAggregate;
using Pessoal.Domain.Aggregates.ColaboradorAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Pessoal.Application.Facade
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
        public async Task<ColaboradorResponse> FindByMatricula(string matricula)
        {
            var result = await  _colaboradorService.FindByMatricula(matricula);
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
        public void Ativar(Guid id)
        {
            _colaboradorService.Ativar(id);
        }
        public void Inativar(Guid id)
        {
            _colaboradorService.Inativar(id);
        }
    }
}

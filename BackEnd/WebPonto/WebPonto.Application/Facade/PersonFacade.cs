using AutoMapper;
using WebPonto.Application.Dtos;
using WebPonto.Application.Interfaces;
using WebPonto.Application.Messages.Request;
using WebPonto.Application.Messages.Response;
using WebPonto.Domain.Aggregates.PersonAggregate;
using WebPonto.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace WebPonto.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public PersonDto FindById(Guid id)
        {
            var result = _personService.FindById(id);
            var response = new PersonDto();
            response = _mapper.Map<PersonDto>(result);
            return response;
        }

        public void CreateRequest(PersonRequest entity)
        {
            var entityMappered = _mapper.Map<Person>(entity);
            _personService.Create(entityMappered);
        }

        public void ModifyRequest(PersonRequest entity)
        {
            var entityMappered = _mapper.Map<Person>(entity);
            _personService.Modify(entityMappered);
        }

        public void Delete(Guid id)
        {           
            _personService.Delete(id);
        }
    }
}

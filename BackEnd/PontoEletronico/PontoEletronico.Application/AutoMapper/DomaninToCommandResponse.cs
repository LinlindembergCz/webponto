using AutoMapper;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Application.Commands.Response;

namespace PontoEletronico.Application.Mappings
{
    public class DomaninToCommandResponse : Profile
    {

        public DomaninToCommandResponse()
        {
            CreateMap< Ponto, PontoResponse>();
        }
    }
}

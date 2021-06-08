using AutoMapper;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Domain.Commands.Response;

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

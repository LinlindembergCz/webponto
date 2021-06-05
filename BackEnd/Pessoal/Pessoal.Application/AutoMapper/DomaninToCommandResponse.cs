using AutoMapper;
using Pessoal.Domain.Aggregates.ColaboradorAggregate;
using Pessoal.Application.Commands.Response;

namespace Pessoal.Application.Mappings
{
    public class DomaninToCommandResponse : Profile
    {

        public DomaninToCommandResponse()
        {
            CreateMap< Colaborador, ColaboradorResponse>();
        }
    }
}

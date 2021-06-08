using AutoMapper;
using Pessoal.Domain.Aggregates.ColaboradorAggregate;
using Pessoal.Domain.Commands.Response;

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

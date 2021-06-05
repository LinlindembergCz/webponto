using AutoMapper;
using Pessoal.Domain.Aggregates.ColaboradorAggregate;
using Pessoal.Application.Commands.Request;

namespace Pessoal.Application.Mappings
{
    public class DomaninToCommandRequest : Profile
    {

        public DomaninToCommandRequest()
        {
            CreateMap< Colaborador, ColaboradorRequest>();
        }
    }
}

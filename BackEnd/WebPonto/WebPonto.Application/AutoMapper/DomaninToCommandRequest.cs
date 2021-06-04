using AutoMapper;
using WebPonto.Domain.Aggregates.ColaboradorAggregate;
using WebPonto.Application.Commands.Request;

namespace WebPonto.Application.Mappings
{
    public class DomaninToCommandRequest : Profile
    {

        public DomaninToCommandRequest()
        {
            CreateMap< Colaborador, ColaboradorRequest>();
        }
    }
}

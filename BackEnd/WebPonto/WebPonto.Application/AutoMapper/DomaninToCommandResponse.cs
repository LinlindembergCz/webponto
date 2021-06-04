using AutoMapper;
using WebPonto.Domain.Aggregates.ColaboradorAggregate;
using WebPonto.Application.Commands.Response;

namespace WebPonto.Application.Mappings
{
    public class DomaninToCommandResponse : Profile
    {

        public DomaninToCommandResponse()
        {
            CreateMap< Colaborador, ColaboradorResponse>();
        }
    }
}

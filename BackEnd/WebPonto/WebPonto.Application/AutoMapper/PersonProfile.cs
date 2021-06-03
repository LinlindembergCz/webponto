using AutoMapper;
using WebPonto.Application.Dtos;
using WebPonto.Application.Messages.Request;
using WebPonto.Domain.Aggregates.PersonAggregate;

namespace WebPonto.Application.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id,  opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));
        }
    }
}

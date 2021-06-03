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
               .ForMember(dest => dest.BusinessEntityID,  opt => opt.MapFrom(src => src.BusinessEntityID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}

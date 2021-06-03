using AutoMapper;
using WebPonto.Application.Messages.Request;
using WebPonto.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPonto.Application.Mappings
{
    public class CommandRequestToDomanin : Profile
    {

        public CommandRequestToDomanin()
        {
            CreateMap<PersonRequest, Person>();

        }
    }
}

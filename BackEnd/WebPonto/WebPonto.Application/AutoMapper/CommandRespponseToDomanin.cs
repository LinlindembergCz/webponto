using AutoMapper;
using WebPonto.Domain.Aggregates.ColaboradorAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPonto.Application.Commands.Response;

namespace WebPonto.Application.Mappings
{
    public class CommandResponseToDomanin : Profile
    {
        public CommandResponseToDomanin()
        {
            CreateMap<ColaboradorResponse, Colaborador>();

        }
    }
}

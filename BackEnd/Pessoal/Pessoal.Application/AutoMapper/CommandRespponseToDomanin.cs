using AutoMapper;
using Pessoal.Domain.Aggregates.ColaboradorAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pessoal.Application.Commands.Response;

namespace Pessoal.Application.Mappings
{
    public class CommandResponseToDomanin : Profile
    {
        public CommandResponseToDomanin()
        {
            CreateMap<ColaboradorResponse, Colaborador>();

        }
    }
}

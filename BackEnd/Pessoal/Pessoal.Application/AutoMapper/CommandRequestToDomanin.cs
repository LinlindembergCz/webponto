using AutoMapper;
using Pessoal.Domain.Aggregates.ColaboradorAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pessoal.Application.Commands.Request;

namespace Pessoal.Application.Mappings
{
    public class CommandRequestToDomanin : Profile
    {
        public CommandRequestToDomanin()
        {
            CreateMap<ColaboradorRequest, Colaborador>();

        }
    }
}

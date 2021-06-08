using AutoMapper;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PontoEletronico.Domain.Commands.Request;

namespace PontoEletronico.Application.Mappings
{
    public class CommandRequestToDomanin : Profile
    {
        public CommandRequestToDomanin()
        {
            CreateMap<PontoRequest, Ponto>();

        }
    }
}

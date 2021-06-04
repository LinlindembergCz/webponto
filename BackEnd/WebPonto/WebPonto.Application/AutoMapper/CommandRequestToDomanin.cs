﻿using AutoMapper;
using WebPonto.Domain.Aggregates.ColaboradorAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPonto.Application.Commands.Request;

namespace WebPonto.Application.Mappings
{
    public class CommandRequestToDomanin : Profile
    {
        public CommandRequestToDomanin()
        {
            CreateMap<ColaboradorRequest, Colaborador>();

        }
    }
}

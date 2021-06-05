using PontoEletronico.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace PontoEletronico.Application.MappinConfig
{
    public static class AutoMapperConfig
    {
        public static void  AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw 
              new ArgumentException(nameof(services));

            services.AddAutoMapper(typeof(DomaninToCommandResponse), typeof(CommandRequestToDomanin));
        }

    }
}

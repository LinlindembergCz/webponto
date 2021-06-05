using Pessoal.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace Pessoal.Application.MappinConfig
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

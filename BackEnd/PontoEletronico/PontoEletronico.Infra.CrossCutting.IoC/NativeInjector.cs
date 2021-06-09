using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using PontoEletronico.Application.Facade;
using PontoEletronico.Application.Interfaces;
using PontoEletronico.Domain.Aggregates.Colaborador;
using PontoEletronico.Domain.Aggregates.Colaborador.Interfaces;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces;
using PontoEletronico.Infra.Data.Repositories;
using System;

namespace PontoEletronico.Infra.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void Setup(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterAutoMapper(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPontoFacade, PontoFacade>();
            services.AddScoped<IPontoService, PontoService>();
            services.AddScoped<IColaboradorService, ColaboradorService>();
            
            services.AddScoped<IPontoRepository, PontoRepository>();

            services.AddHttpClient<IColaboradorService, ColaboradorService>()
                    .AddPolicyHandler(HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                               retryAttempt)))).
                    SetHandlerLifetime(TimeSpan.FromMinutes(5));
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {

        }
    }
}

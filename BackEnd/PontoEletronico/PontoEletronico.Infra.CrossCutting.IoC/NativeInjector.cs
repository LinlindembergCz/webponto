using Microsoft.Extensions.DependencyInjection;
using PontoEletronico.Application.Facade;
using PontoEletronico.Application.Interfaces;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces;
using PontoEletronico.Infra.Data.Repositories;

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
            //como são serviços leves, opto por AddTransient
            services.AddTransient<IPontoFacade, PontoFacade>();
            services.AddTransient<IPontoService, PontoService>();
            services.AddTransient<IPontoRepository, PontoRepository>();

           // services.AddScoped<IColaboradorFacade, ColaboradorFacade>();
           // services.AddScoped<IColaboradorService, ColaboradorService>();
           // services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {

        }
    }
}

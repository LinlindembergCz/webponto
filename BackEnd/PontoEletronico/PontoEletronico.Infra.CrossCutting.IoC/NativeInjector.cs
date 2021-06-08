using Microsoft.Extensions.DependencyInjection;
using PontoEletronico.Application.Facade;
using PontoEletronico.Application.Interfaces;
using PontoEletronico.Domain.Aggregates.Colaborador;
using PontoEletronico.Domain.Aggregates.Colaborador.Interfaces;
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
            services.AddScoped<IPontoFacade, PontoFacade>();
            services.AddScoped<IPontoService, PontoService>();
            services.AddScoped<IColaboradorService, ColaboradorService>();
            
            services.AddScoped<IPontoRepository, PontoRepository>();
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {

        }
    }
}

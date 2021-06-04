using Microsoft.Extensions.DependencyInjection;
using WebPonto.Application.Facade;
using WebPonto.Application.Interfaces;
using WebPonto.Domain.Aggregates.ColaboradorAggregate;
using WebPonto.Domain.Aggregates.ColaboradorAggregate.Interfaces;
using WebPonto.Infra.Data.Repositories;

namespace WebPonto.Infra.CrossCutting.IoC
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
            services.AddScoped<IColaboradorFacade, ColaboradorFacade>();
            services.AddScoped<IColaboradorService, ColaboradorService>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {

        }
    }
}

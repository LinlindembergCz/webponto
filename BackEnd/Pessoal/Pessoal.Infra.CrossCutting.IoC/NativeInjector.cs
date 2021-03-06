using Microsoft.Extensions.DependencyInjection;
using Pessoal.Application.Facade;
using Pessoal.Application.Interfaces;
using Pessoal.Domain.Aggregates.ColaboradorAggregate;
using Pessoal.Domain.Aggregates.ColaboradorAggregate.Interfaces;
using Pessoal.Infra.Data.Repositories;

namespace Pessoal.Infra.CrossCutting.IoC
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

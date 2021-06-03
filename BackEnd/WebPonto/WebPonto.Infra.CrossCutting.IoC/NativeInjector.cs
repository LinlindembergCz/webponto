using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebPonto.Application.AutoMapper;
using WebPonto.Application.Dtos;
using WebPonto.Application.Facade;
using WebPonto.Application.Interfaces;
using WebPonto.Domain.Aggregates.PersonAggregate;
using WebPonto.Domain.Aggregates.PersonAggregate.Interfaces;
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
            services.AddScoped<IPersonFacade, PersonFacade>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IPersonPhoneService, PersonPhoneService>();
            services.AddScoped<IPersonPhoneRepository, PersonPhoneRepository>();
            
            services.AddScoped<IPhoneNumberTypeService, PhoneNumberTypeService>();
            services.AddScoped<IPhoneNumberTypeRepository, PhoneNumberTypeRepository>();
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {

        }
    }
}

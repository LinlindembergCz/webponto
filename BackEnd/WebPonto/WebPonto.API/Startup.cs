using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebPonto.Infra.CrossCutting.IoC;
using WebPonto.Infra.Data.Context;
using System;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace WebPonto.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc();
            services.AddDbContext<ExampleContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                    b => b.MigrationsAssembly("WebPonto.Infra.Data.Configuration"));
            });

            NativeInjector.Setup(services);
            services.AddAutoMapper();

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);

                options.CustomOperationIds(e =>
                {
                    return $"{e.ActionDescriptor.RouteValues["controller"]}_{e.HttpMethod}{e.ActionDescriptor.Parameters?.Select(a => a.Name).ToString()}";
                });
               // options.SwaggerDoDescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebPonto Api",
                    Description = "WebPonto Api.",
                 });

                var xmlWebApiFile = Path.Combine(AppContext.BaseDirectory, $"WebPonto.Api.xml");
                if (File.Exists(xmlWebApiFile))
                {
                    options.IncludeXmlComments(xmlWebApiFile);
                }
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1/swagger.json", "WebPonto Api");
                options.DisplayRequestDuration();
            });

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


           app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

           app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}


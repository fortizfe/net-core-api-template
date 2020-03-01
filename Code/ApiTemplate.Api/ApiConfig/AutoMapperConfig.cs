using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ApiTemplate.Api.ApiConfig
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services, IConfiguration config)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains(config.GetValue<string>("ProjectPrefix")));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assemblies);

                // Custom profiles here
            }).CreateMapper());

            return services;
        }
    }
}
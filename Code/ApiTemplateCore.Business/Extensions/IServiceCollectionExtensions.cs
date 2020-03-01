using ApiTemplate.Core.Business.ApplicationServices;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.Core.Business.Extensions
{
    public static class ServiceInjectorExtensions
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            // Add services to dependency injection here
            services.AddScoped<IWorkerService, WorkerService>();

            return services;
        }
    }
}
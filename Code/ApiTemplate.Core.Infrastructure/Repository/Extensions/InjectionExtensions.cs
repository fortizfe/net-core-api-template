using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.Core.Infrastructure.Repository.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Add repositories injection here
            services.AddScoped<IWorkerRepositoryService, WorkerRepositoryService>();

            return services;
        }
    }
}
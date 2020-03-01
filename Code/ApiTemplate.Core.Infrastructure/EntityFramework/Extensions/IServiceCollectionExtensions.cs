using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.Core.Infrastructure.EntityFramework.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddContext<TContext>(this IServiceCollection services, string connectionString)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
                options.UseMySql(connectionString));

            return services;
        }
    }
}
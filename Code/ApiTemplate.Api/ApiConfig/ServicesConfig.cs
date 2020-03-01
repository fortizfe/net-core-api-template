using ApiTemplate.Core.Business.Extensions;
using ApiTemplate.Core.Infrastructure.Repository.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ApiTemplate.Api.ApiConfig
{
    public static class ServicesConfig
    {
        public static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddBusinessService();

            #region General services

            // General services here
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion General services
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiTemplate.Api.Utils;

namespace ApiTemplate.Api.ApiConfig
{
    public static class IdentityConfig
    {
        public static void AddIdentityAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddPolicies();

            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = Configuration.GetSection("IdentityServerConfig").GetValue<string>("BaseUrl");
                options.ApiName = Configuration.GetSection("IdentityServerConfig").GetValue<string>("ApiResource");
                options.RequireHttpsMetadata = false;
            });
        }

        public static void AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                // Add required policies here
                options.AddPolicy(ApiTemplateApiPolicies.ApiTemplateApiPolicy, policy => policy.RequireClaim("scope", ApiTemplateApiScopes.ApiTemplateApi));
            });
        }
    }
}
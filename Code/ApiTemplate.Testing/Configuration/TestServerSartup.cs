using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiTemplate.Api;
using System.Reflection;

namespace ApiTemplate.Testing.Configuration
{
    public class TestServerStartup : Startup
    {
        public TestServerStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override void AddAditionalconfiguration(IServiceCollection services)
        {
            base.AddAditionalconfiguration(services);
            services.AddControllers().AddApplicationPart(Assembly.Load(new AssemblyName("ApiTemplate.Api")));
        }

        protected override void ConfigureAdditionalMiddleware(IApplicationBuilder app)
        {
            base.ConfigureAdditionalMiddleware(app);
            app.UseMiddleware<AuthenticatedTestRequestMiddleware>();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiTemplate.Api.ApiConfig;
using ApiTemplate.Core.Infrastructure.EntityFramework.Contexts;
using ApiTemplate.Core.Infrastructure.EntityFramework.Extensions;

namespace ApiTemplate.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContext<ApiTemplateContext>(Configuration.GetConnectionString("ApiTemplate.Api.ConnectionString"));

            services.AddServiceDependencies();

            services.AddSwagerConfig();

            services.AddAutoMapperConfig(Configuration);

            services.AddIdentityAuthentication(Configuration);

            services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                });

            services.AddControllers(opts =>
            {
                opts.Filters.Add(typeof(TransactionActionFilter));
                opts.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = ErrorsConfig.CustomizeInvalidModelErrors;
            });

            AddAditionalconfiguration(services);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDebug())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseSwagerConfig();

            ConfigureAdditionalMiddleware(app);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlingMiddleware>();


            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        protected virtual void ConfigureAdditionalMiddleware(IApplicationBuilder app)
        {
            // Intentionally empty
        }

        protected virtual void AddAditionalconfiguration(IServiceCollection services)
        {
            // Intentionally empty
        }
    }
}

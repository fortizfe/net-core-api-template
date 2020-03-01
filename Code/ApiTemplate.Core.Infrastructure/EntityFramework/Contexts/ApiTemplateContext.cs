using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ApiTemplate.Core.Infrastructure.EntityFramework.Contexts
{
    public class ApiTemplateContext : DbContext
    {
        #region Public Constructors

        private readonly IConfiguration _config;

        public ApiTemplateContext(DbContextOptions<ApiTemplateContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var prefix = _config.GetValue<string>("ProjectPrefix");

            var assembgliesToRegister = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains(prefix)
                    && a.GetTypes().Any(t => t.GetInterfaces()
                    .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))));

            foreach (var assembly in assembgliesToRegister)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            }
        }

        #endregion Protected Methods
    }
}
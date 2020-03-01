using Microsoft.EntityFrameworkCore;
using ApiTemplate.Core.Infrastructure.EntityFramework.Contexts;

namespace ApiTemplate.Testing.Configuration
{
    public static class DatabaseInitializer
    {
        public static void EnsureCreatedAndMigrateToLatest(ApiTemplateContext context)
        {
            context.Database.Migrate();
        }
    }
}
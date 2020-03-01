using Microsoft.Extensions.Configuration;
using System;

namespace ApiTemplate.Testing.Configuration
{
    public class TestConfigurationBuilder
    {
        public IConfigurationRoot Build()
        {
            var basePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf("\\bin"));

            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.testing.json", optional: false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
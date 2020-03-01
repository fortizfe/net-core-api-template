using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace ApiTemplate.Testing.Configuration
{
    public class TestServerFixture
    {
        public readonly TestServer Server;
        private IConfigurationRoot Configuration;

        public TestServerFixture()
        {
            Server = CreateServer();
        }

        public TestServer CreateServer()
        {
            Configuration = new TestConfigurationBuilder().Build();

            var builder = new WebHostBuilder()
                .UseConfiguration(Configuration)
                .UseTestServer()
                .UseStartup<TestServerStartup>();

            var build = builder.Build();
            build.StartAsync();
            return build.GetTestServer();
        }
    }
}
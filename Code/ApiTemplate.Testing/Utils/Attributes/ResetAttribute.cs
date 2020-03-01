using MySql.Data.MySqlClient;
using ApiTemplate.Testing.Configuration;
using System.Reflection;
using Xunit.Sdk;

namespace ApiTemplate.Testing.Utils.Attributes
{
    public class ResetAttribute : BeforeAfterTestAttribute
    {
        private readonly string _connectionString;

        public ResetAttribute()
        {
            var configuration = new TestConfigurationBuilder().Build();
            _connectionString = configuration["ConnectionStrings:ApiTemplate.Api.ConnectionString"];
        }

        public override void Before(MethodInfo methodUnderTest)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.OpenAsync().Wait();

            DbFixture.Reset(conn);
        }
    }
}
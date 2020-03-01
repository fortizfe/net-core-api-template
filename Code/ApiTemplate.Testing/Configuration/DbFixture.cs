using Respawn;
using System.Data.Common;

namespace ApiTemplate.Testing.Configuration
{
    public static class DbFixture
    {
        private static readonly Checkpoint Checkpoint = new Checkpoint
        {
            TablesToIgnore = new[]
            {
                "__EFMigrationsHistory",
                "Devices"
            },
            DbAdapter = DbAdapter.MySql
        };

        public static void Reset(DbConnection connection)
        {
            Checkpoint.Reset(connection).Wait();
        }
    }
}
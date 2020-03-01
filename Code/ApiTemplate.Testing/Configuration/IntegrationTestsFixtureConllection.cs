using ApiTemplate.Testing.Utils.Constants;
using Xunit;

namespace ApiTemplate.Testing.Configuration
{
    [CollectionDefinition(FixtureCollections.IntegrationTests)]
    public class IntegrationTestsFixtureConllection : ICollectionFixture<TestServerFixture>
    {
    }
}
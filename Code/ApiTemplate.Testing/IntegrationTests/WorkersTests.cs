using ApiTemplate.Api.Dtos.Generic;
using ApiTemplate.Core.Business.Dtos.WorkerDtos;
using ApiTemplate.Testing.Configuration;
using ApiTemplate.Testing.Utils.Attributes;
using ApiTemplate.Testing.Utils.Constants;
using ApiTemplate.Testing.Utils.Endpoints;
using FluentAssertions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace ApiTemplate.Testing.IntegrationTests
{
    [Collection(FixtureCollections.IntegrationTests)]
    public class WorkersTests : BaseTest
    {
        public WorkersTests(TestServerFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        [Reset]
        [Description("Comprobar que se obtienen los trabajadores")]
        public async Task Get_Workers_Should_Return_All_Workers()
        {
            // Arrange
            await AddWorkersToContext();

            // Act
            var response = await GetAsync(WorkersEndpoints.Get.GetAll);
            response.EnsureSuccessStatusCode();
            var apiResponse = await DeserializeResponse<ResponseDto<List<WorkerDto>>>(response);

            // Assert
            apiResponse.Succeeded.Should().BeTrue();
            apiResponse.Errors.Should().BeNullOrEmpty();
            apiResponse.Result.Should()
                .NotBeNull()
                .And.BeOfType(typeof(List<WorkerDto>))
                .And.HaveCount(2);
        }
    }
}
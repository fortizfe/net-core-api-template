using ApiTemplate.Core.Domain.Models;
using ApiTemplate.Core.Infrastructure.EntityFramework.Contexts;
using ApiTemplate.Core.Infrastructure.Repository;
using ApiTemplate.Testing.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTemplate.Testing.IntegrationTests
{
    public class BaseTest
    {
        protected readonly TestServerFixture _fixture;
        protected readonly HttpClient _testServerClient;
        protected readonly IWorkerRepositoryService _workerRepoSvc;
        protected readonly ApiTemplateContext _context;

        public BaseTest(TestServerFixture fixture)
        {
            _fixture = fixture;
            _testServerClient = _fixture.Server.CreateClient();
            _workerRepoSvc = fixture.Server.Services.GetService(typeof(IWorkerRepositoryService)) as IWorkerRepositoryService;
            _context = fixture.Server.Services.GetService(typeof(ApiTemplateContext)) as ApiTemplateContext;

            ConfigureHttpClient();

            DatabaseInitializer.EnsureCreatedAndMigrateToLatest(_context);
        }

        private void ConfigureHttpClient()
        {
            _testServerClient.DefaultRequestHeaders.Add("X-Integration-Testing", "X-Integration-Testing");
        }

        #region HTTP Requests

        internal async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _testServerClient.GetAsync(endpoint);
        }

        protected async Task<HttpResponseMessage> PostAsync<TData>(string endpoint, TData payload)
        {
            var content = SerializePayload(payload);
            return await _testServerClient.PostAsync(endpoint, content);
        }

        protected async Task<HttpResponseMessage> PutAsync<TData>(string endpoint, TData payload)
        {
            var content = SerializePayload(payload);
            return await _testServerClient.PutAsync(endpoint, content);
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            return await _testServerClient.DeleteAsync(endpoint);
        }

        #endregion HTTP Requests

        #region HTTP UTILS

        internal async Task<TData> DeserializeResponse<TData>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TData>(json);
        }

        internal StringContent SerializePayload<TData>(TData payload)
        {
            return new StringContent(JsonConvert.SerializeObject(payload), UTF8Encoding.UTF8, "application/json");
        }

        #endregion HTTP UTILS

        #region DATABASE UTILS

        internal async Task AddWorkersToContext(int numberToInsert = 1)
        {
            if (numberToInsert < 1) throw new InvalidOperationException("Can't insert less than one worker");

            var workersToInsert = new List<Worker>();
            for (int i = 1; i <= numberToInsert; i++)
            {
                workersToInsert.Add(
                    new Worker
                    {
                        Name = $"Test{i}",
                        Username = $"test{i}",
                        Tagid = $"tag{1}",
                        Enabled = true
                    });
            }

            await _workerRepoSvc.AddAsync(workersToInsert);
        }

        internal async Task AddDisabledWorker()
        {
            await _workerRepoSvc.AddAsync(new Worker
            {
                Name = $"Test1",
                Username = $"test1",
                Tagid = $"tag1",
                Enabled = false
            });
        }

        #endregion DATABASE UTILS
    }
}
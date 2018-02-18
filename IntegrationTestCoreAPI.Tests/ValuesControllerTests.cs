using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Xunit;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace IntegrationTestCoreAPI.Tests
{
    public class ValuesControllerTests
    {
        private readonly TestServer _testServer;
        private readonly HttpClient _testClient;
        public ValuesControllerTests()
        {
            //Initializing the test environment
            _testServer = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            //Test client creation
            _testClient = _testServer.CreateClient();
        }

        [Fact]
        public async Task TestGetRequestAsync()
        {
            var response = await _testClient.GetAsync("/api/values/");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            
            Assert.Equal("[\"value1\",\"value2\"]", result);
        }

        [Fact]
        public async Task TestGetByIdRequestAsync()
        {
            var response = await _testClient.GetAsync("/api/values/1");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal("value", result);
        }
    }
}

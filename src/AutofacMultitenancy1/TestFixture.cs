using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace AutofacMultitenancy1
{
    public class TestFixture
    {
        [Fact]
        public async Task TestMultiple()
        {
            var hostBuilder = new WebHostBuilder()
                .UseStartup<Startup>();
            var testServer = new TestServer(hostBuilder);

            var client = testServer.CreateClient();
            var result = await client.GetAsync("http://tenant1.local");
            var tenant1Result = await result.Content.ReadAsStringAsync();

            result = await client.GetAsync("http://tenant2.local");
            var tenant2Result = await result.Content.ReadAsStringAsync();

            Console.WriteLine(tenant1Result);
            Console.WriteLine(tenant2Result);

            Assert.NotEqual(tenant1Result, tenant2Result);
        }
    }
}
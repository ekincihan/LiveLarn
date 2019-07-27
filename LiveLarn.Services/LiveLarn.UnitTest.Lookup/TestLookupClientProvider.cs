using LiveLarn.Service.Lookup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LiveLarn.UnitTest.Lookup
{
    class TestLookupClientProvider
    {
        public HttpClient Client { get; private set; }
        public TestLookupClientProvider()
        {
            var projectDir = System.IO.Directory.GetCurrentDirectory();

            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}

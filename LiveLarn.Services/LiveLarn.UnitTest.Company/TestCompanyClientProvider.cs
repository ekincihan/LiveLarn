using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using LiveLarn.Service.Company;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace LiveLarn.UnitTest.Company
{
    class TestCompanyClientProvider
    {
        public HttpClient Client { get; private set; }
        public TestCompanyClientProvider()
        {
            var projectDir = System.IO.Directory.GetCurrentDirectory();

            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = server.CreateClient();
        }
    }
}

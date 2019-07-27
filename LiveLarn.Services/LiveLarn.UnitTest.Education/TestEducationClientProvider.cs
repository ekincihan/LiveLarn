using LiveLarn.Service.Education;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LiveLarn.UnitTest.Education
{
    class TestEducationClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestEducationClientProvider()
        {
            var projectDir = System.IO.Directory.GetCurrentDirectory();

            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}

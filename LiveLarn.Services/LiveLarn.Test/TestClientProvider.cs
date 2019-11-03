using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LiveLarn.Test
{
    public class TestClientProvider<TStartUp>  where  TStartUp : class
    {
        public HttpClient Client { get; private set; }
        public TestClientProvider()
        {
            try
            {
                var projectDir = System.IO.Directory.GetCurrentDirectory();

                var server = new TestServer(new WebHostBuilder().UseStartup<TStartUp>());

                Client = server.CreateClient();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

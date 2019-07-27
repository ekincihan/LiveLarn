using Bogus;
using LiveLarn.Service.Lookup.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LiveLarn.UnitTest.Lookup
{
    public class DistrictUnitTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            var client = new TestLookupClientProvider().Client;
            var response = await client.GetAsync("api/District");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Get_OData()
        {
            var client = new TestLookupClientProvider().Client;
            var response = await client.GetAsync("api/District?$select=name,id");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Post_OData()
        {
            Faker faker = new Faker("tr");
            District district = new District()
            {
                Name = faker.Address.County(), Code = "", IsActive = true, CreateDate = DateTime.Now 
            };

            var client = new TestLookupClientProvider().Client;
            var response = await client.PostAsync("api/District", new StringContent(JsonConvert.SerializeObject(district), UnicodeEncoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

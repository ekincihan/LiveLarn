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
    public class CityUnitTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            var client = new TestLookupClientProvider().Client;
            var response = await client.GetAsync("api/City");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Get_OData()
        {
            var client = new TestLookupClientProvider().Client;
            var response = await client.GetAsync("api/City?$select=name,id");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Post_OData()
        {
            try
            {
                Random rd = new Random();

                Faker faker = new Faker("tr");
                City city = new City
                {
                    Name = faker.Address.City(),
                    Code = rd.Next(1, 81).ToString(),
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    Districts = new List<District> {
                                new District { Name=faker.Address.County(), Code="", IsActive = true, CreateDate = DateTime.Now },
                                new District { Name=faker.Address.County(), Code="", IsActive = true, CreateDate = DateTime.Now },
                                new District { Name=faker.Address.County(), Code="", IsActive = true, CreateDate = DateTime.Now }
                            }
                };


                var client = new TestLookupClientProvider().Client;
                var response = await client.PostAsync("api/City", new StringContent(JsonConvert.SerializeObject(city), UnicodeEncoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

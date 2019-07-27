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
    public class CountryUnitTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            var client = new TestLookupClientProvider().Client;
            var response = await client.GetAsync("api/Country");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Get_OData()
        {
            var client = new TestLookupClientProvider().Client;
            var response = await client.GetAsync("api/Country?$select=name,id");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Post_OData()
        {
            Random rd = new Random();
            
            Faker faker = new Faker("tr");
            Country country = new Country()
            {
                Name = faker.Address.Country(),
                CreateDate = DateTime.UtcNow,
                Code = faker.Address.CountryCode(Bogus.DataSets.Iso3166Format.Alpha2),
                Cities = new List<City>{
                    new City { Name = faker.Address.City(), Code = rd.Next(1,81).ToString().PadLeft(2, '0'), CreateDate =DateTime.Now, IsActive = true,
                    Districts = new List<District> {
                                new District { Name=faker.Address.County(), Code="", IsActive = true, CreateDate = DateTime.Now },
                                new District { Name=faker.Address.County(), Code="", IsActive = true, CreateDate = DateTime.Now },
                                new District { Name=faker.Address.County(), Code="", IsActive = true, CreateDate = DateTime.Now }
                                }
                            },
                    new City { Name = faker.Address.City(), Code = rd.Next(1,81).ToString().PadLeft(2, '0'), CreateDate =DateTime.Now, IsActive = true,
                    Districts = new List<District> {
                                new District { Name=faker.Address.County(), Code="", IsActive = true, CreateDate = DateTime.Now },
                                new District { Name=faker.Address.County(), Code="", IsActive = true, CreateDate = DateTime.Now },
                                new District { Name=faker.Address.County(), Code="", IsActive = true, CreateDate = DateTime.Now }
                                }
                            }
                        }
            };
            

            var client = new TestLookupClientProvider().Client;
            var response = await client.PostAsync("api/Country", new StringContent(JsonConvert.SerializeObject(country), UnicodeEncoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

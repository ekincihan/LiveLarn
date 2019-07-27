using Bogus;
using LiveLarn.Service.Education.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LiveLarn.UnitTest.Education
{
    public class CategoryUnitTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            var client = new TestEducationClientProvider().Client;
            var response = await client.GetAsync("api/Category");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_Get_OData()
        {
            var client = new TestEducationClientProvider().Client;
            var response = await client.GetAsync("api/Category?$select=name,id");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_Post_OData()
        {
            Faker faker = new Faker("tr");
            Category category = new Category()
            {
                Name = faker.Commerce.Categories(1)[0],
                CreateDate = DateTime.Now,
                IsActive = true
            };

            var client = new TestEducationClientProvider().Client;
            var response = await client.PostAsync("api/Category", new StringContent(JsonConvert.SerializeObject(category), UnicodeEncoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

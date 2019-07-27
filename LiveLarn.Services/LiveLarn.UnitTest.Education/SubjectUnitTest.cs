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
    public class SubjectUnitTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            var client = new TestEducationClientProvider().Client;
            var response = await client.GetAsync("api/Subject");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_Get_OData()
        {
            var client = new TestEducationClientProvider().Client;
            var response = await client.GetAsync("api/Subject?$select=name,id");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_Post_OData()
        {
            Faker faker = new Faker("tr");
            Subject subject = new Subject()
            {
                Name = faker.Lorem.Sentence(3),
                CreateDate = DateTime.Now,
                IsActive = true
            };

            var client = new TestEducationClientProvider().Client;
            var response = await client.PostAsync("api/Subject", new StringContent(JsonConvert.SerializeObject(subject), UnicodeEncoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

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
    public class ClassLevelUnitTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            var client = new TestEducationClientProvider().Client;
            var response = await client.GetAsync("api/ClassLevel");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_Get_OData()
        {
            var client = new TestEducationClientProvider().Client;
            var response = await client.GetAsync("api/ClassLevel?$select=name,id");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_Post_OData()
        {
            Random random = new Random();

            Faker faker = new Faker("tr");
            ClassLevel classLevel = new ClassLevel()
            {
                Name = faker.Lorem.Sentence(3),
                EducationLevel = random.Next(1, 81),
                CreateDate = DateTime.Now,
                IsActive = true
            };

            var client = new TestEducationClientProvider().Client;
            var response = await client.PostAsync("api/ClassLevel", new StringContent(JsonConvert.SerializeObject(classLevel), UnicodeEncoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

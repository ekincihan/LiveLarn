using Bogus;
using LiveLarn.Service.User;
using LiveLarn.Service.User.Models;
using LiveLarn.Test;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LiveLarn.UnitTest.User
{
    public class UserUnitTest
    {
        [Fact]
        public async Task Test_User_Register()
        {
            Faker faker = new Faker("tr");
            RegisterDto registerDto = new RegisterDto()
            {
                Email = faker.Internet.Email(faker.Name.FirstName(), faker.Name.LastName()),
                Password = "Ekincihanduman2233!"
            };
            var client = new TestClientProvider<Startup>().Client;
            var response = await client.PostAsync("api/Account/Register", new StringContent(JsonConvert.SerializeObject(registerDto), UnicodeEncoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Create_Role()
        {
            var client = new TestClientProvider<Startup>().Client;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("name", "admin");
            var response = await client.PostAsync("api/Account/CreateRole", new FormUrlEncodedContent(parameters));
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Add_To_Role()
        {
            var client = new TestClientProvider<Startup>().Client;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("email", "e.cihanduman@gmail.com");
            parameters.Add("role", "manager");
            var response = await client.PostAsync("api/Account/AddToRole", new FormUrlEncodedContent(parameters));
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

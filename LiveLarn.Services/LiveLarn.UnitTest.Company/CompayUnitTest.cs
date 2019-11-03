using Bogus;
using LiveLarn.Service.Company;
using LiveLarn.Test;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LiveLarn.UnitTest.Company
{
    public class CompayUnitTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            var client = new TestClientProvider<Startup>().Client;
            var response = await client.GetAsync("api/company");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Get_OData()
        {
            var client = new TestClientProvider<Startup>().Client;
            var response = await client.GetAsync("api/Company?$select=name,id");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Test_Post_OData()
        {

            Faker faker = new Faker("tr");
            Service.Company.Model.Entity.Company company = new Service.Company.Model.Entity.Company()
            {
                Name = faker.Company.CompanyName(1),
                IsActive = true,
                Branches = new System.Collections.Generic.List<Service.Company.Model.Entity.Branch>()
                {
                    { new Service.Company.Model.Entity.Branch { Name = faker.Company.CompanyName(2), AddressLine1 = faker.Address.FullAddress(), AddressLine2 = faker.Address.SecondaryAddress(), CountryId = 1, CityId=faker.PickRandom<int>(1,2,3,4), DistrictId=faker.PickRandom<int>(1,2,3,4), PhoneNumber = faker.Phone.PhoneNumber("(###) ###-####"), Mail = faker.Internet.Email(faker.Name.FirstName(), faker.Name.LastName()), Code="T001", CreateDate = DateTime.UtcNow } },
                    { new Service.Company.Model.Entity.Branch { Name = faker.Company.CompanyName(2), AddressLine1 = faker.Address.FullAddress(), AddressLine2 = faker.Address.SecondaryAddress(), CountryId = 1, CityId=faker.PickRandom<int>(1,2,3,4), DistrictId=faker.PickRandom<int>(1,2,3,4), PhoneNumber = faker.Phone.PhoneNumber("(###) ###-####"), Mail = faker.Internet.Email(faker.Name.FirstName(), faker.Name.LastName()), Code="T001", CreateDate = DateTime.UtcNow } },
                }
            };

            var client = new TestClientProvider<Startup>().Client;
            company.Name = "Fake.Company";
            var response = await client.PostAsync("api/Company", new StringContent(JsonConvert.SerializeObject(company), UnicodeEncoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

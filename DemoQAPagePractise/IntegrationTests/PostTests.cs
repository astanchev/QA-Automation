namespace IntegrationTests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Factories;
    using Models;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class PostTests : BaseTest
    {
        [Test]
        public async Task CreateHousehold()
        {
            var houseHold = HouseholdFactory.CreateHousehold();
            var requestHouseholdJSON = houseHold.ToJson();


            var requestBody = new StringContent(requestHouseholdJSON, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("/households", requestBody);

            //Check If Response code is 200 OK
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseHousehold = JsonConvert.DeserializeObject<Household>(responseAsString);

            //Check if houshold is created correctly
            Assert.NotNull(responseHousehold);
            Assert.AreEqual(houseHold.Name, responseHousehold.Name);
            Assert.True(responseHousehold.Id > 0);
        }

        [Test]
        public async Task CreateHouseholdWithInvalidNameShouldReturnInternalServerError()
        {
            var houseHold = HouseholdFactory.CreateHousehold();
            houseHold.Name = null;
            var requestHouseholdJSON = houseHold.ToJson();


            var requestBody = new StringContent(requestHouseholdJSON, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("/households", requestBody);

            //Check If Response code is Internal Server Error
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Test]
        public async Task CreateUser()
        {
            var user = UserFactory.CreateUser();
            var requestUserJSON = user.ToJson();

            var requestBody = new StringContent(requestUserJSON, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("/users", requestBody);

            //Check If Response code is 200 OK
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseUser = JsonConvert.DeserializeObject<User>(responseAsString);

            //Check if household is created correctly
            Assert.NotNull(responseUser);
            Assert.AreEqual(user.FirstName + " " + user.LastName, responseUser.FirstName + " " + responseUser.LastName);
            Assert.True(responseUser.Id > 0);
        }

        [Test]
        public async Task CreateUserWithInvalidNameShouldReturnInternalServerError()
        {
            var user = UserFactory.CreateUser();
            user.HouseholdId = 50;
            var requestUserJSON = user.ToJson();

            var requestBody = new StringContent(requestUserJSON, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("/users/", requestBody);
            
            //Check If Response code is Internal Server Error
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Test]
        [TestCase(5)]
        public async Task TestDeleteExistingBookShouldReturnUnauthorized(int bookId)
        {
            var response = await Client.DeleteAsync($"/books/{bookId}");

            //Check If Response code is 401 Unauthorized
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
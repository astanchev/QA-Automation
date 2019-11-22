namespace IntegrationTests
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using ModelFactories;
    using Models;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class GetTests : BaseTest
    {
        [Test]
        public async Task GetAuthorById()
        {
            //Arange
            var expectedId = await GetExpectedAutorId();

            //Act
            var responseGet = await Client.GetAsync($"/api/authors/{expectedId}");

            //Check If Response code is 200 OK
            responseGet.EnsureSuccessStatusCode();
            var responseAsStringGet = await responseGet.Content.ReadAsStringAsync();

            var authorGet = JsonConvert.DeserializeObject<Author>(responseAsStringGet);

            //Assert
            //Check if response author id is same as Get request id
            Assert.AreEqual(expectedId, authorGet.Id);
        }

        private async Task<Guid?> GetExpectedAutorId()
        {
            var author = AuthorFactory.CreateAuthor();
            var requestAuthorJSON = author.ToJson();

            var requestBody = new StringContent(requestAuthorJSON, Encoding.UTF8, "application/json");

            var responsePost = await Client.PostAsync("/api/authors", requestBody);

            var statusCode = responsePost.StatusCode;

            var responseAsStringPost = await responsePost.Content.ReadAsStringAsync();
            var responseAuthor = JsonConvert.DeserializeObject<Author>(responseAsStringPost);

            var expectedId = responseAuthor.Id;
            return expectedId;
        }
    }
}
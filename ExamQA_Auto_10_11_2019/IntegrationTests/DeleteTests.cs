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

    public class DeleteTests : BaseTest
    {
        [Test]
        public async Task GetAuthorById()
        {
            //Arange
            var expectedId = await GetExpectedAutorId();

            //Act
            var responseDelete = await Client.DeleteAsync($"/api/authors/{expectedId}");
            
            //Assert
            responseDelete.EnsureSuccessStatusCode();
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
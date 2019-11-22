namespace IntegrationTests
{
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using ModelFactories;
    using Models;
    using Newtonsoft.Json;
    using NUnit.Framework;

    public class PostTests : BaseTest
    {
        [Test]
        public async Task PostAuthor()
        {
            //Arange
            var author = AuthorFactory.CreateAuthor();
            var requestAuthorJSON = author.ToJson();

            //Act
            var requestBody = new StringContent(requestAuthorJSON, Encoding.UTF8, "application/json");

            var responsePost = await Client.PostAsync("/api/authors", requestBody);

            var statusCode = responsePost.StatusCode;


            //Assert
            Assert.AreEqual(HttpStatusCode.Created, statusCode);
        }
    }
}
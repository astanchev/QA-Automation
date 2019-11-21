namespace IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class GetTests : BaseTest
    {
        private List<long> wishlistIds = new List<long>();
        List<Book> books = new List<Book>();
        List<User> users = new List<User>();
        List<Household> households = new List<Household>();

        [Test]
        public async Task GetAllBooks()
        {
            var response = await Client.GetAsync("/books");

            //Check If Response code is 200 OK
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            books = JsonConvert.DeserializeObject<IEnumerable<Book>>(responseAsString).ToList();

            //Check if book collection is not empty
            Assert.True(books.Count > 0);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetBookById(int bookId)
        {
            var response = await Client.GetAsync($"/books/{bookId}");

            //Check If Response code is 200 OK
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            var book = JsonConvert.DeserializeObject<Book>(responseAsString);

            //Check if response book id is same as Get request id
            Assert.AreEqual(bookId, book.Id);
        }

        [Test]
        [TestCase(10)]
        public async Task GetBookByWrongIdReturnsNotFound(int bookId)
        {
            var response = await Client.GetAsync($"/books/{bookId}");

            //Check If Response code is Not Found
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task GetBookByQuery()
        {
            var query = @"?author=Greg Bahnsen";

            var response = await Client.GetAsync($"/books/search{query}");

            //Check If Response code is 200 OK
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            var book = JsonConvert.DeserializeObject<IEnumerable<Book>>(responseAsString).FirstOrDefault();

            //Check if book is not null
            Assert.NotNull(books);

            //Check if book match the query
            Assert.AreEqual("Greg Bahnsen", book.Author);
        }

        [Test]
        public async Task GetAllUsers()
        {
            var response = await Client.GetAsync("/users");

            //Check If Response code is 200 OK
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            users = JsonConvert.DeserializeObject<IEnumerable<User>>(responseAsString).ToList();

            //Check if user collection is not empty
            Assert.True(users.Count > 0);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task GetUserById(int userId)
        {
            var response = await Client.GetAsync($"/users/{userId}");

            //Check If Response code is 200 OK
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<User>(responseAsString);

            //Check if response user id is same as Get request id
            Assert.AreEqual(userId, user.Id);
        }

        [Test]
        [TestCase(10)]
        public async Task GetUserByWrongIdReturnsNotFound(int userId)
        {
            var response = await Client.GetAsync($"/users/{userId}");

            //Check If Response code is Not Found
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task GetAllBooksByHouseholdId(int householdId)
        {
            var response = await Client.GetAsync($"/households/{householdId}/wishlistBooks");

            //Check If Response code is 200 OK
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            var responseBooks = JsonConvert.DeserializeObject<IEnumerable<Book>>(responseAsString).ToList();

            //Check if household wishlist is not empty
            Assert.True(responseBooks.Count > 0);

            var uniqueResponseBooks = responseBooks.Distinct();

            //Check if household wishlist doesn't have duplicate books
            CollectionAssert.AreEqual(uniqueResponseBooks, responseBooks);
        }

        [Test]
        [TestCase(10)]
        public async Task GetHouseholdByIdReturnsNotFound(int householdId)
        {
            var response = await Client.GetAsync($"/households/{householdId}");

            //Check If Response code is Not Found
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
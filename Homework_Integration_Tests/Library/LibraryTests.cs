namespace Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;

    using Newtonsoft.Json;

    using NUnit.Framework;

    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    [TestFixture]
    public class LibraryTests : BaseTest
    {
        private long targetHousehold;
        private List<long> wishlistIds = new List<long>();
        List<Book> books = new List<Book>();
        Random random = new Random();

        [Test]
        [Order(1)]
        public async Task CreateHouseholds()
        {
            var houseHold = HouseholdFactory.CreateHousehold();
            var requestHouseholdJSON = JsonConvert.SerializeObject(houseHold);
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

            targetHousehold = (long)responseHousehold.Id;
        }

        [Test]
        [Order(2)]
        public async Task CreateUsers()
        {
            var firstUser = User1Factory.CreateUser1();
            var secondUser = User2Factory.CreateUser2();

            List<User> users = new List<User>(){firstUser, secondUser};

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                user.HouseholdId = targetHousehold;

                var requestUserJSON = JsonConvert.SerializeObject(user);
                var requestUserBody = new StringContent(requestUserJSON, Encoding.UTF8, "application/json");

                var response = await Client.PostAsync("/users", requestUserBody);

                //Check If Response code is 200 OK
                response.EnsureSuccessStatusCode();

                var responseAsString = await response.Content.ReadAsStringAsync();
                var responseUser = JsonConvert.DeserializeObject<User>(responseAsString);

                var responseUserWishlistId = (long) responseUser.WishlistId;
                wishlistIds.Add(responseUserWishlistId);

                //Check if user is created correctly
                Assert.NotNull(responseUser);
                Assert.True(responseUser.Id > 0);
                Assert.AreEqual(user.FirstName, responseUser.FirstName);
            }
        }

        [Test]
        [Order(3)]
        public async Task GetBooks()
        {
            var response = await Client.GetAsync("/books");

            //Check If Response code is 200 OK
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            books = JsonConvert.DeserializeObject<IEnumerable<Book>>(responseAsString).ToList();

            //Check if book collection is not empty
            Assert.True(books.Count > 0);
            //Make sure that we will have at least 2 books for next test
            Assert.True(books.Count > 1);
        }

        [Test]
        [Order(4)]
        public async Task AddBookToWishlists()
        {
            foreach (var wishlistId in wishlistIds)
            {
                long currentBookId = 0;
                for (int i = 1; i <= 2; i++)
                {
                    var bookId = books[random.Next(0, books.Count)].Id;

                    //Make sure that same user doesn't receive same book again
                    //But different users can receive same book
                    while (true)
                    {
                        if (bookId == currentBookId)
                        {
                            bookId = books[random.Next(0, books.Count)].Id;
                        }
                        else
                        {
                            var requestBody = new StringContent("", Encoding.UTF8, "application/json");
                            
                            var response = await Client.PostAsync($"/wishlists/{wishlistId}/books/{bookId}", requestBody);

                            //Check If Response code is 200 OK
                            response.EnsureSuccessStatusCode();

                            currentBookId = bookId;
                            break;
                        }
                    }
                }
            }
        }

        [Test]
        [Order(5)]
        public async Task GetHouseholdBooks()
        {
            var response = await Client.GetAsync($"/households/{targetHousehold}/wishlistBooks");

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
    }
}

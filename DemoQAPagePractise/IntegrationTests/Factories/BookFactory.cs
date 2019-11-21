namespace IntegrationTests.Factories
{
    using System;
    using Models;

    public class BookFactory
    {
        public static Book CreateBook()
        {
            return new Book
            {
                Title = "AAAAAA",
                Author = "AAAAAA",
                PublicationDate = DateTimeOffset.Now,
                Isbn = "666666"
            };
        }
    }
}
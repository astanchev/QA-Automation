namespace IntegrationTests.ModelFactories
{
    using Models;

    public static class AuthorFactory
    {
        public static Author CreateAuthor()
        {
            return new Author
            {
                FirstName = "AAAAAA",
                LastName = "AAAAAA",
                Genre = "AAAAAA"
            };
        }
    }
}
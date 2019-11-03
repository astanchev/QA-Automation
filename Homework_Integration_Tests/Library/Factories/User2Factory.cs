namespace Library.Factories
{
    using Models;

    public static class User2Factory
    {
        public static User CreateUser2()
        {
            return new User()
            {
                Email = "ivan.ivanov@iii.com",
                FirstName =  "Ivan",
                LastName = "Ivanov"
            };
        }
    }
}
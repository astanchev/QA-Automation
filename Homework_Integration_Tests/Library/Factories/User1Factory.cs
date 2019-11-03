namespace Library.Factories
{
    using Models;

    public static class User1Factory
    {
        public static User CreateUser1()
        {
            return new User()
            {
                Email = "george.georgiev@ggg.com",
                FirstName =  "George",
                LastName = "Georgiev"
            };
        }
    }
}
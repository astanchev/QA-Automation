namespace IntegrationTests.Factories
{
    using Models;

    public class UserFactory
    {
        public static User CreateUser()
        {
            return new User()
            {
                Email = "george.georgiev@ggg.com",
                FirstName =  "George",
                LastName = "Georgiev",
                HouseholdId = 1
            };
        }
    }
}
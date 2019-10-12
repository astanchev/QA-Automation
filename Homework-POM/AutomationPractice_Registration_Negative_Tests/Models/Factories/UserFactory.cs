namespace AutomationPractice_Registration_Negative_Tests.Models.Factories
{
    public static class UserFactory
    {
        public static User CreateUser()
        {
            return new User()
            {
                FirstName = "AAAAAA",
                LastName = "BBBBBB",
                EMail = "aaaaaaaaa@aaa.aaa",
                Password = "pass123456",
                Day = "3",
                Month = "3",
                Year = "2016",
                AddressFirstName = "AAAAAA",
                AddressLastName = "BBBBBB",
                Address = "Neshto",
                City = "Sofia",
                State = "Arizona",
                Postalcode = "85001",
                MobilePhone = "999999",
                Alias = "Home"
            };
        }
    }
}
namespace AutomationPractice_Registration_Negative_Tests.Tests
{
    using Extensions;

    using Models;
    using Models.Factories;

    using NUnit.Framework;

    using Pages.LoginPage;
    using Pages.RegistrationPage;

    [TestFixture]
    public class RegistrationFormNegativeTests : BaseTest
    {
        private RegistrationPage registrationPage;
        private User user;
        
        [SetUp]
        public void SetUp()
        {
            user = UserFactory.CreateUser();

            var loginPage = new LoginPage(Driver);
            loginPage.Navigate();

            registrationPage = loginPage.CreateAccount();
            registrationPage.FillForm(user);
        }
        
        [Test]
        public void TestEmptyFirstNameShouldShowError()
        {
            registrationPage.FirstName.Type("");

            registrationPage.RegisterButton.Click();

            registrationPage.AssertErrorDisplayed();
            registrationPage.AssertErrorMessage("<b>firstname</b> is required.");
        }


        [Test]
        public void TestEmptyLastNameShouldShowError()
        {
            registrationPage.LastName.Type("");

            registrationPage.RegisterButton.Click();

            registrationPage.AssertErrorDisplayed();
            registrationPage.AssertErrorMessage("<b>lastname</b> is required.");
        }


        [Test]
        public void TestEmptyFirstAndLastNameShouldShowsTwoErrors()
        {
            registrationPage.FirstName.Type("");
            registrationPage.LastName.Type("");

            registrationPage.RegisterButton.Click();

            registrationPage.AssertErrorDisplayed();
            registrationPage.AssertTwoErrorMessages("There are 2 errors");
        }


        [Test]
        public void TestEmptyEmptyMobilePhoneShouldShowError()
        {
            registrationPage.Phone.Type("");

            registrationPage.RegisterButton.Click();

            registrationPage.AssertErrorDisplayed();
            registrationPage.AssertErrorMessage("You must register at least one phone number.");
        }


        [Test]
        public void TestEmptyPasswordShouldShowError()
        {
            registrationPage.Password.Type("");

            registrationPage.RegisterButton.Click();

            registrationPage.AssertErrorDisplayed();
            registrationPage.AssertErrorMessage("<b>passwd</b> is required.");
        }


        [Test]
        public void TestIncorrectPostCodeFormatShouldShowError()
        {
            registrationPage.PostCode.Type("");

            registrationPage.RegisterButton.Click();

            registrationPage.AssertErrorDisplayed();
            registrationPage.AssertErrorMessage("The Zip/Postal code you've entered is invalid. It must follow this format: 00000");
        }

        [Test]
        public void TestEmptyAddressShouldShowError()
        {
            registrationPage.Address.Type("");

            registrationPage.RegisterButton.Click();

            registrationPage.AssertErrorDisplayed();
            registrationPage.AssertErrorMessage("<b>address1</b> is required.");
        }


        [Test]
        public void TestEmptyCityShouldShowError()
        {
            registrationPage.City.Type("");

            registrationPage.RegisterButton.Click();

            registrationPage.AssertErrorDisplayed();
            registrationPage.AssertErrorMessage("<b>city</b> is required.");
        }


        [Test]
        public void TestEmptyEmailShouldShowError()
        {
            registrationPage.Email.Type("");

            registrationPage.RegisterButton.Click();

            registrationPage.AssertErrorDisplayed();
            registrationPage.AssertErrorMessage("<b>email</b> is required.");
        }
    }
}

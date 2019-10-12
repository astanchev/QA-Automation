namespace AutomationPractice_Registration_Page
{
    using System.IO;
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using Pages.HomePage;

    [TestFixture]
    public class AutomationPracticeRegistrationTests
    {
        private HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            homePage.ClosePage();
        }

        [Test]
        public void TestEmailFieldInRegistrationFormShouldBeFilledCorrectly()
        {
            homePage.Navigate();
            var loginPage = homePage.GoToLogin();

            var registrationPage = loginPage.CreateAccount("aaaaaa@aaaaaa.aaa");

            registrationPage.AssertCorrectEmailInRegForm("aaaaaa@aaaaaa.aaa");

        }
    }
}

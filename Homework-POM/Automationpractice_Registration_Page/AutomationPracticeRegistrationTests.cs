namespace AutomationPractice_Registration_Page
{
    using NUnit.Framework;

    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    using Pages.HomePage;

    using System;

    [TestFixture]
    public class AutomationPracticeRegistrationTests
    {
        private HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();

            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";


            var driver = new RemoteWebDriver(new Uri("http://192.168.100.5:21928/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
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

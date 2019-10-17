namespace Google_Search
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    using Pages.GoogleSearchPage;

    using System;

    [TestFixture]
    public class GoogleSearchTests
    {
        private IWebDriver driver;
        private GoogleSearchPage searchPage;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();

            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";


            driver = new RemoteWebDriver(new Uri("http://192.168.100.5:21928/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            searchPage = new GoogleSearchPage(driver);

        }

        [TearDown]
        public void TearDown()
        {
            searchPage.ClosePage();
        }

        [Test]
        public void SearchGoogleForSelenium()
        {
            searchPage.Navigate();
            var resultPage = searchPage.Search("Selenium");
            var expectedPage = resultPage.GoToFirstLink();

            var expectedTitle = "Selenium - Web Browser Automation";
            var actualTitle = expectedPage.Title;

            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}

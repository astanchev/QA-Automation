namespace Google_Search
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using Pages.GoogleSearchPage;

    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class GoogleSearchTests
    {
        private IWebDriver driver;
        private GoogleSearchPage searchPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();

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

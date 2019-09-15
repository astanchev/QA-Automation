namespace Task1
{
    using System;
    using System.IO;
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class GoogleSearchTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void SearchGoogleForSelenium()
        {
            driver.Navigate().GoToUrl("http://www.google.com");

            var searchBoxInput = wait.Until((w) => w.FindElement(By.XPath(@"//*[@id=""tsf""]/div[2]/div[1]/div[1]/div/div[2]/input")));

            searchBoxInput.SendKeys("Selenium" + Environment.NewLine);

            var firstLink = wait.Until((w) => w.FindElement(By.ClassName(@"ellip")));
            firstLink.Click();

            var expectedWebPageTitleText = "Selenium - Web Browser Automation";
            var actualWebPageTitleText = driver.Title;
            
            Assert.AreEqual(expectedWebPageTitleText, actualWebPageTitleText);
        }
    }
}

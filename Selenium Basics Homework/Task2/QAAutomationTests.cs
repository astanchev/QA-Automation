namespace Task2
{
    using System;
    using System.IO;
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class QAAutomationTests
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
        public void CheckQAAutomationCourseHeading()
        {
            driver.Navigate().GoToUrl("https://softuni.bg/");

            var courseButton = wait.Until((w) => w.FindElement(By.XPath("//*[@id='header-nav']/div[1]/ul/li[2]/a")));
            courseButton.Click();

            var qaAutomationLink = wait.Until((w) => w.FindElement(By.PartialLinkText("QA Automation - септември 2019")));
            qaAutomationLink.Click();

            var qaAutomationHeader = wait.Until((w) => w.FindElement(By.XPath("/html/body/div[2]/header/h1")));

            var actualTagName = qaAutomationHeader.TagName;
            var expectedTagName = "h1";

            Assert.AreEqual(expectedTagName, actualTagName);

            var expectedHeading = "QA Automation - септември 2019";
            var actualHeading = qaAutomationHeader.GetAttribute("innerHTML");

            StringAssert.Contains(expectedHeading, actualHeading);

        }
    }
}

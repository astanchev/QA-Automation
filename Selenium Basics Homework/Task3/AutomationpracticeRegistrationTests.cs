namespace Task3
{
    using System;
    using System.IO;
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class AutomationpracticeRegistrationTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void EmailFieldInRegistrationFormShouldBeFilledCorrectly()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            var signInButton = wait.Until((w) => w.FindElement(By.ClassName("login")));
            signInButton.Click();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);
            var emailInput = wait.Until((w) => w.FindElement(By.Id("email_create")));
            emailInput.SendKeys("aaaaaa@aaa.aaa");

            var createAccButton = wait.Until((w) => w.FindElement(By.Id("SubmitCreate")));
            createAccButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);
            wait.Until(w => w.FindElement(By.Id("email")).GetAttribute("value") != string.Empty);

            var expectedValueString = "aaaaaa@aaa.aaa";
            var actualValueString = wait.Until(w => w.FindElement(By.Id("email")).GetAttribute("value"));

            //var emailText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//form[@id='account-creation_form']//input[@id='email']")));
            //var actualValueString = emailText.GetAttribute("value");
            
            Assert.AreEqual(expectedValueString, actualValueString);
        }
    }
}

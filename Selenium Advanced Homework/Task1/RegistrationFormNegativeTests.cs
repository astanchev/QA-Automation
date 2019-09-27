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
    public class RegistrationFormNegativeTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private RegistrationFormFiller regFormFiller;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            regFormFiller = new RegistrationFormFiller(driver, wait);
            regFormFiller.FillRegistrationForm();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestEmptyFirstNameShouldShowError()
        {
            var firstName = driver.FindElement(By.Id("customer_firstname"));
            firstName.Clear();

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            Assert.IsTrue(IsErrorDisplayed());

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='center_column']/div/ol/li")).GetAttribute("innerHTML");

            Assert.AreEqual("<b>firstname</b> is required.", errorMessage);

        }


        [Test]
        public void TestEmptyLastNameShouldShowError()
        {
            var lastName = driver.FindElement(By.Id("customer_lastname"));
            lastName.Clear();

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            Assert.IsTrue(IsErrorDisplayed());

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='center_column']/div/ol/li")).GetAttribute("innerHTML");

            Assert.AreEqual("<b>lastname</b> is required.", errorMessage);

        }


        [Test]
        public void TestEmptyFirstAndLastNameShouldShowsTwoErrors()
        {
            var firstName = driver.FindElement(By.Id("customer_firstname"));
            firstName.Clear();

            var lastName = driver.FindElement(By.Id("customer_lastname"));
            lastName.Clear();

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            Assert.IsTrue(IsErrorDisplayed());

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='center_column']/div/p")).GetAttribute("innerHTML");

            Assert.AreEqual("There are 2 errors", errorMessage);

        }


        [Test]
        public void TestEmptyEmptyMobilePhoneShouldShowError()
        {
            var phone = driver.FindElement(By.Id("phone_mobile"));
            phone.Clear();

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            Assert.IsTrue(IsErrorDisplayed());

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='center_column']/div/ol/li")).GetAttribute("innerHTML");

            Assert.AreEqual("You must register at least one phone number.", errorMessage);
        }


        [Test]
        public void TestEmptyPasswordShouldShowError()
        {
            var password = driver.FindElement(By.Id("passwd"));
            password.Clear();

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            Assert.IsTrue(IsErrorDisplayed());

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='center_column']/div/ol/li")).GetAttribute("innerHTML");

            Assert.AreEqual("<b>passwd</b> is required.", errorMessage);

        }


        [Test]
        public void TestIncorrectPostCodeFormatShouldShowError()
        {
            var postcode = driver.FindElement(By.Id("postcode"));
            postcode.Clear();
            postcode.SendKeys("8500156");

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            Assert.IsTrue(IsErrorDisplayed());

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='center_column']/div/ol/li")).GetAttribute("innerHTML");

            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", errorMessage);
        }

        [Test]
        public void TestEmptyAddressShouldShowError()
        {
            var address = driver.FindElement(By.Id("address1"));
            address.Clear();

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            Assert.IsTrue(IsErrorDisplayed());

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='center_column']/div/ol/li")).GetAttribute("innerHTML");

            Assert.AreEqual("<b>address1</b> is required.", errorMessage);
        }


        [Test]
        public void TestEmptyCityShouldShowError()
        {
            var city = driver.FindElement(By.Id("city"));
            city.Clear();

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            Assert.IsTrue(IsErrorDisplayed());

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='center_column']/div/ol/li")).GetAttribute("innerHTML");

            Assert.AreEqual("<b>city</b> is required.", errorMessage);
        }


        [Test]
        public void TestEmptyEmailShouldShowError()
        {
            var email = driver.FindElement(By.Id("email"));
            email.Clear();

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            Assert.IsTrue(IsErrorDisplayed());

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='center_column']/div/ol/li")).GetAttribute("innerHTML");

            Assert.AreEqual("<b>email</b> is required.", errorMessage);
        }


        private bool IsErrorDisplayed()
        {
            try
            {
                var visibleError = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(@"//*[@id='center_column']/div")));
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }
    }
}

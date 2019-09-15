namespace FirstTests
{
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestFixture]
    public class FirstTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Manage().Window.Maximize();

            driver.Url = "https://softuni.bg";

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void LogoSrc()
        {
            //*[@id="page-header"]/div[1]/div/div/div[1]/a/img[1]
            var logo = driver.FindElement(By.XPath(@"//*[@id=""page-header""]/div[1]/div/div/div[1]/a/img[1]"));

            // List of all img in that div
            //var elements = driver.FindElements(By.XPath(@"//*[@id=""page-header""]/div[1]/div/div/div[1]/a/img")).ToList();

            var actualImageSrc = logo.GetAttribute("src");

            var expectedString = @"https://softuni.bg/content/images/svg-logos/software-university-logo.svg";
            
            Assert.AreEqual(expectedString, actualImageSrc);
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            var loginButton = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[2]/ul/li[2]/span/a"));
            loginButton.Click();

            var userNameInput = driver.FindElement(By.Id(@"username"));
            userNameInput.SendKeys("***User Name***");

            var passwordInput = driver.FindElement(By.Id(@"password"));
            passwordInput.SendKeys("***Password***");

            var buttonLogIn =
                driver.FindElement(By.XPath(@"/html/body/main/div[2]/div/div[2]/div[1]/form/div[4]/input"));
            buttonLogIn.Click();

            var imgProfile = driver.FindElement(By.XPath(@"//*[@id=""show-profile-menu""]/span/span[1]/span/img"));
            imgProfile.Click();

            var actualProfileName = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[2]/ul/li[2]/div/div[1]/div[1]"));
            

            var expectedProfileName = @"@***User Name***";


            Assert.AreEqual(expectedProfileName, actualProfileName.Text);
        }


        [Test]
        public void logos()
        {
            var loginButton = driver.FindElement(By.XPath(@"//*[@id='header-nav']/div[2]/ul/li[2]/span/a"));
            loginButton.Click();

            var logos = driver.FindElements(By.XPath(@"/html/body/main/div[2]/div/div[1]/div/div[2]/div"));

            Assert.AreEqual(6, logos.Count);

        }

    }
}

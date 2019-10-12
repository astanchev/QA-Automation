namespace AutomationPractice_Registration_Negative_Tests.Tests
{
    using System.IO;
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestFixture]
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }

        [OneTimeSetUp]
        public void SetUpTests()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            Driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Driver.Close();
        }
    }
}
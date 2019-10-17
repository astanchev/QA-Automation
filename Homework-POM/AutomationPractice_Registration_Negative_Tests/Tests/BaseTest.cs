namespace AutomationPractice_Registration_Negative_Tests.Tests
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    using System;

    [TestFixture]
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }

        [OneTimeSetUp]
        public void SetUpTests()
        {
            ChromeOptions options = new ChromeOptions();

            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";


            Driver = new RemoteWebDriver(new Uri("http://192.168.100.5:21928/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(10));
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            Driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Driver.Close();
        }
    }
}
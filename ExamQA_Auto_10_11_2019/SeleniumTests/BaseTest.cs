using NUnit.Framework;

namespace SeleniumTests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }

        [SetUp]
        public void SetUpTests()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                if (IsAlertPresent())
                {
                    Driver.SwitchTo().Alert().Accept();
                    Driver.SwitchTo().Window(Driver.WindowHandles.Last());
                }

                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var path = Path.GetFullPath(Directory.GetCurrentDirectory()
                                            + @"\..\..\..\Screenshots\") +
                           TestContext.CurrentContext.Test.Name + ".png";
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            }

            Driver.Quit();
        }

        private bool IsAlertPresent()
        {
            try
            {
                Driver.SwitchTo().Alert();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
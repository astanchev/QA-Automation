namespace PresentationTasks
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(@"http://toolsqa.com/automation-practice-switch-windows/");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestBrowserWindow()
        {
            var newBrWindowButton =
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(@"button1")));
            newBrWindowButton.Click();

            //WindowHandles returns collection of window names
            string newPopUpWindowName = driver.WindowHandles.Last();

            var newPopUpWindow = driver.SwitchTo().Window(newPopUpWindowName); 

            var logo =  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id=""page""]/div[1]/div[2]/div[3]/a/img")));

            var expectedSrc = @"https://www.toolsqa.com/wp-content/uploads/2014/08/Toolsqa.jpg";
            var actualSrc = logo.GetProperty("src");

            Assert.AreEqual(expectedSrc, actualSrc);

            newPopUpWindow.Close();
            
            Assert.IsTrue(driver.WindowHandles.Count == 1);
            
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Test]
        public void TestNewBrowserTab()
        {
            var newNewBrowserTabButton =
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(@"//*[@id='content']/div[1]/div[2]/div/div/div/div/p[5]/button")));
            newNewBrowserTabButton.Click();

            string newBrowserTabName = driver.WindowHandles.Last();

            var newBrowserTab = driver.SwitchTo().Window(newBrowserTabName);

            var actualNewBrowserTabTitle = driver.Title;
            var expectedNewBrowserTabTitle = @"Free QA Automation Tools Tutorial for Beginners with Examples";

            Assert.AreEqual(expectedNewBrowserTabTitle, actualNewBrowserTabTitle);

            newBrowserTab.Close();

            Assert.IsTrue(driver.WindowHandles.Count == 1);

            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Test]
        public void TestAlertBox()
        {
            var newAlertButton =
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(@"alert")));
            newAlertButton.Click();

            var alert = driver.SwitchTo().Alert();

            var message = "Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.";
           
            Assert.AreEqual(message, alert.Text);
            
            alert.Dismiss();

            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

    }
}

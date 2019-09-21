namespace DragAndDropGuru99
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class DragAndDropTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Actions builder;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(@"http://demo.guru99.com/test/drag_drop.html");

            builder = new Actions(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestDragLoanDisplaysErrorMessage()
        {
            var loanBox =
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='credit4']/a")));


            builder.MoveToElement(loanBox).ClickAndHold().MoveByOffset(1, 1).Perform();

            var errorMessage = driver.FindElement(By.XPath(@"//*[@id='e1']"));

            Assert.AreEqual("Please select another block", errorMessage.Text);

        }


        [Test]
        public void TestDragSalesToCreditSideAccount()
        {
            var salesBox =
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='credit1']/a")));

            var placeToDropInCreditSideAccount = driver.FindElement(By.XPath(@"//*[@id='loan']/li"));


            builder.DragAndDrop(salesBox, placeToDropInCreditSideAccount).Perform();

            var placeSalesIsShownInCreditSideAccount = driver.FindElement(By.XPath(@"//*[@id='loan']/li"));

            Assert.AreEqual("SALES", placeSalesIsShownInCreditSideAccount.Text);

        }


        [Test]
        public void TestPerfectButtonIsDisplayed()
        {
            var salesBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='credit1']/a")));
            var placeToDropInCreditSideAccount =  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='loan']/li")));
            builder.DragAndDrop(salesBox, placeToDropInCreditSideAccount).Build().Perform();


            builder = new Actions(driver);
            var bankBox =  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='credit2']/a")));
            var placeToDropInDebitSideAccount = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='bank']/li")));
            builder.DragAndDrop(bankBox, placeToDropInDebitSideAccount).Build().Perform();
            

            builder = new Actions(driver);
            var fiveThousandBoxFirst = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='fourth'][1]/a")));
            var placeToDropInDebitSideAmount =  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='amt7']/li")));
            builder.DragAndDrop(fiveThousandBoxFirst, placeToDropInDebitSideAmount).Build().Perform();
            

            builder = new Actions(driver);
            var fiveThousandBoxSecond =  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='fourth'][2]/a")));
            var placeToDropInCreditSideAmount =  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(@"//*[@id='amt8']/li")));
            builder.DragAndDrop(fiveThousandBoxSecond, placeToDropInCreditSideAmount).Build().Perform();


            var perfectButton = driver.FindElement(By.XPath(@"//*[@id='equal']/a"));

            Assert.IsTrue(perfectButton.Displayed);
        }

    }
}

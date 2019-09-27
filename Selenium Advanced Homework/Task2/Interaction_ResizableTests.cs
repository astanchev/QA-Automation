namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class Interaction_ResizableTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IList<IWebElement> interactions;
        private IList<IWebElement> handlesElements;
        private Actions builder;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/");

            interactions = wait.Until(d => d.FindElements(By.CssSelector("#sidebar li")));

            var resizable = interactions[2];
            resizable.Click();

            handlesElements =
                wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(
                        By.XPath(@"//*[@id='resizable']/div")));

            builder = new Actions(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestResizable_ResizeElementWithEastHandleWorksCorrectly()
        {
            var eastHandle = handlesElements[0];
            var eastHandleX = eastHandle.Location.X;
            var eastHandleY = eastHandle.Location.Y;

            builder
                .MoveToElement(eastHandle)
                .ClickAndHold()
                .MoveByOffset(100, 0)
                .Release()
                .Build()
                .Perform();

            var newEastHandleX = eastHandle.Location.X;
            var newEastHandleY = eastHandle.Location.Y;

            Assert.AreEqual(eastHandleY, newEastHandleY, 2);

            //Gives -17px deviation on X
            var expectedHandleX = eastHandleX + 83;
            Assert.AreEqual(expectedHandleX, newEastHandleX, 2);
        }

        [Test]
        public void TestResizable_ResizeElementWithSouthHandleWorksCorrectly()
        {
            var southHandle = handlesElements[1];
            var southHandleX = southHandle.Location.X;
            var southHandleY = southHandle.Location.Y;

            builder
                .MoveToElement(southHandle)
                .ClickAndHold()
                .MoveByOffset(0, 100)
                .Release()
                .Build()
                .Perform();

            
            var newSouthHandleX = southHandle.Location.X;
            var newSouthHandleY = southHandle.Location.Y;

            Assert.AreEqual(southHandleX, newSouthHandleX, 2);

            //Gives -17px deviation on Y
            var expectedHandleY = southHandleY + 83;
            Assert.AreEqual(expectedHandleY, newSouthHandleY, 2);
        }

        [Test]
        public void TestResizable_ResizeDiagonalWorksCorrectly()
        {
            var diagonalHandle = handlesElements[2];
            var diagonalHandleX = diagonalHandle.Location.X;
            var diagonalHandleY = diagonalHandle.Location.Y;

            builder
                .MoveToElement(diagonalHandle)
                .ClickAndHold()
                .MoveByOffset(100, 100)
                .Release()
                .Build()
                .Perform();
            
            var newDiagonalHandleX = diagonalHandle.Location.X;
            var newDiagonalHandleY = diagonalHandle.Location.Y;

            //Gives -17px deviation on X
            var expectedHandleX = diagonalHandleX + 83;
            Assert.AreEqual(expectedHandleX, newDiagonalHandleX, 2);

            //Gives -17px deviation on Y
            var expectedHandleY = diagonalHandleY + 83;
            Assert.AreEqual(expectedHandleY, newDiagonalHandleY, 2);
        }
    }
}
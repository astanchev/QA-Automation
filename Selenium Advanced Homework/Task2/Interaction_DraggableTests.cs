namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    [TestFixture()]
    public class Interaction_DraggableTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IList<IWebElement> interactions;
        private Actions builder;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/");

            interactions = wait.Until(d => d.FindElements(By.CssSelector("#sidebar li")));

            var draggable = interactions[4];
            draggable.Click();

            builder = new Actions(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void TestDraggable_DragMovesOnXAxis()
        {
            var draggable = driver.FindElement(By.Id("draggable"));

            var beforeDragX = draggable.Location.X;
            var beforeDragY = draggable.Location.Y;

            builder.DragAndDropToOffset(draggable, 300, 0).Perform();

            var afterDragX = draggable.Location.X;
            var afterDragY = draggable.Location.Y;


            Assert.AreEqual(beforeDragY, afterDragY);
            Assert.IsTrue(afterDragX > beforeDragX);
        }

        [Test]
        public void TestDraggable_DragMovesOnYAxis()
        {
            var draggable = driver.FindElement(By.Id("draggable"));

            var beforeDragX = draggable.Location.X;
            var beforeDragY = draggable.Location.Y;

            builder
                .MoveToElement(draggable)
                .ClickAndHold()
                .MoveByOffset(0, 300)
                .Release()
                .Build()
                .Perform();

            var afterDragX = draggable.Location.X;
            var afterDragY = draggable.Location.Y;


            Assert.AreEqual(beforeDragX, afterDragX);
            Assert.IsTrue(afterDragY > beforeDragY);
            
        }

        [Test]
        public void TestDraggable_DragMovesOnDiagonal()
        {
            var draggable = driver.FindElement(By.Id("draggable"));

            var beforeDragX = draggable.Location.X;
            var beforeDragY = draggable.Location.Y;

            builder
                .MoveToElement(draggable)
                .ClickAndHold()
                .MoveByOffset(300, 300)
                .Release()
                .Build()
                .Perform();

            var afterDragX = draggable.Location.X;
            var afterDragY = draggable.Location.Y;


            Assert.IsTrue(afterDragX > beforeDragX);
            Assert.IsTrue(afterDragY > beforeDragY);
            
        }
    }
}
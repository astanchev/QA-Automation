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

    [TestFixture]
    public class Interaction_DropableTests
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

            var droppable = interactions[3];
            droppable.Click();

            builder = new Actions(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void TestDroppable_DropInTargetChangeTargetColor()
        {
            var draggable = driver.FindElement(By.Id("draggable"));
            var target = driver.FindElement(By.Id("droppable"));
            
            var targetColor = target.GetCssValue("color");

            builder
                .MoveToElement(draggable)
                .ClickAndHold()
                .MoveToElement(target)
                .Release()
                .Build()
                .Perform();

            var afterColor = target.GetCssValue("color");
            
            Assert.AreNotEqual(targetColor, afterColor);
        }

        [Test]
        public void TestDroppable_DropInTargetChangeTargetText()
        {
            var draggable = driver.FindElement(By.Id("draggable"));
            var target = driver.FindElement(By.Id("droppable"));
            
            var targetText = target.Text;

            builder.DragAndDrop(draggable, target).Perform();

            var afterText = target.Text;
            
            Assert.AreNotEqual(targetText, afterText);
            Assert.AreEqual("Dropped!", afterText);
        }

        [Test]
        public void TestDroppable_DropSmallPartInTargetDoesNotChangeTargetTextAndColor()
        {
            var draggable = driver.FindElement(By.Id("draggable"));
            var target = driver.FindElement(By.Id("droppable"));

            var targetColor = target.GetCssValue("color");
            var targetText = target.Text;

            builder.DragAndDropToOffset(draggable, 80, 120).Perform();

            var afterColor = target.GetCssValue("color");
            var afterText = target.Text;
            
            Assert.AreEqual(targetColor, afterColor);
            Assert.AreEqual(targetText, afterText);
        }

    }
}
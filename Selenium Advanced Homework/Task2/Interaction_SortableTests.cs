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
    public class Interaction_SortableTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IList<IWebElement> interactions;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/");

            interactions = wait.Until(d => d.FindElements(By.CssSelector("#sidebar li")));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestSortable_Item1MovesCorrectlyToPositionFive()
        {
            Move_Item1_To_Item5_Position();

            var elementAtPositinFive = driver.FindElement(By.XPath(@"//*[@id='sortable']/li[5]"));

            string expectedText = @"Item 1";
            string actualText = elementAtPositinFive.Text;

            Assert.AreEqual(expectedText, actualText);
        }


        [Test]
        public void TestSortable_Item2BecomesFirstElement()
        {
            Move_Item1_To_Item5_Position();

            var elementAtPositinOne = driver.FindElement(By.XPath(@"//*[@id='sortable']/li[1]"));

            string expectedText = @"Item 2";
            string actualText = elementAtPositinOne.Text;

            Assert.AreEqual(expectedText, actualText);
        }


        [Test]
        public void TestSortable_Item5MovesToPositionFour()
        {
            Move_Item1_To_Item5_Position();

            var elementAtPositinFour = driver.FindElement(By.XPath(@"//*[@id='sortable']/li[4]"));

            string expectedText = @"Item 5";
            string actualText = elementAtPositinFour.Text;

            Assert.AreEqual(expectedText, actualText);
        }

        private void Move_Item1_To_Item5_Position()
        {
            var sortable = interactions[0];
            sortable.Click();

            IList<IWebElement> sortableItems =
                wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(
                        By.CssSelector("#content ul li")));

            var item1 = sortableItems[0];
            var item5 = sortableItems[4];

            Actions builder = new Actions(driver);

            builder
                .Click(item1)
                .ClickAndHold()
                .MoveToElement(item5)
                .MoveByOffset(0, 10)
                .Release()
                .Build()
                .Perform();
        }
    }
}

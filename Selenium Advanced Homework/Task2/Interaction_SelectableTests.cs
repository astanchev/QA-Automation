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
    public class Interaction_SelectableTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IList<IWebElement> interactions;
        private IList<IWebElement> selectableItems;
        private Actions builder;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/");

            interactions = wait.Until(d => d.FindElements(By.CssSelector("#sidebar li")));

            var selectable = interactions[1];
            selectable.Click();

            selectableItems =
                wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(
                        By.XPath(@"//*[@id='selectable']//li")));

            builder = new Actions(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void TestSelectable_Item1ChangeColorAfterSelect()
        {
            var item1 = selectableItems[0];

            var itemColorBeforeClick = item1.GetCssValue("background-color");

            builder.Click(item1).Perform();

            var itemColorAfterClick = item1.GetCssValue("background-color");

            Assert.AreNotEqual(itemColorBeforeClick, itemColorAfterClick);
            Assert.AreEqual("rgba(243, 152, 20, 1)", itemColorAfterClick);
        }

        [Test]
        public void TestSelectable_TwoItemsCanBeSelectedByPressingCtrlButton()
        {
            var item1 = selectableItems[0];
            var item1ColorBeforeClick = item1.GetCssValue("background-color");
            builder.Click(item1).Build();

            var item5 = selectableItems[4];
            var item5ColorBeforeClick = item5.GetCssValue("background-color");
            builder.KeyDown(Keys.Control).Click(item5).KeyUp(Keys.Control).Build();

            builder.Perform();

            var item1ColorAfterClick = item1.GetCssValue("background-color");
            var item5ColorAfterClick = item5.GetCssValue("background-color");

            Assert.AreNotEqual(item1ColorBeforeClick, item1ColorAfterClick);
            Assert.AreNotEqual(item5ColorBeforeClick, item5ColorAfterClick);

            Assert.AreEqual("rgba(243, 152, 20, 1)", item1ColorAfterClick);
            Assert.AreEqual("rgba(243, 152, 20, 1)", item5ColorAfterClick);
        }

        [Test]
        public void TestSelectable_SelectedItem1ChangeColorBackAfterControlAndClick()
        {
            var item1 = selectableItems[0];
            var itemColorBeforeClick = item1.GetCssValue("background-color");
            builder.Click(item1).Perform();

            var itemColorAfterFirstClick = item1.GetCssValue("background-color");

            builder.KeyDown(Keys.Control).Click(item1).KeyUp(Keys.Control).Build().Perform();

            var itemColorAfterControlAndClick = item1.GetCssValue("background-color");


            Assert.AreEqual(itemColorBeforeClick, itemColorAfterControlAndClick);
            Assert.AreNotEqual(itemColorBeforeClick, itemColorAfterFirstClick);
            Assert.AreEqual("rgba(243, 152, 20, 1)", itemColorAfterFirstClick);
            Assert.AreEqual("rgba(255, 255, 255, 1)", itemColorAfterControlAndClick);
        }
    }
}
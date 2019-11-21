namespace Autocomplete
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Pages.AutocompletePage;

    [TestFixture]
    public class AutocompleteTests : BaseTest
    {
        private AutocompletePage page;

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/");

            page = new AutocompletePage(Driver);
            page.AutocompleteButton.Click();
        }

        [Test]
        public void TestAutocompleteListIsDisplayed()
        {
            page.TagInput.Click();
            
            Assert.IsFalse(page.FullList.Displayed);

            page.TagInput.SendKeys("a");
            page.TagInput.SendKeys(Keys.ArrowDown);
            string expectedSuggestion = page.WholeListOfSuggestions[0];

            Assert.IsTrue(page.FullList.Displayed);

            page.AutocompleteDropList[1].Click();
            
            string actualSuggestion = page.TagInput.GetProperty("value");

            Assert.AreEqual(expectedSuggestion, actualSuggestion);

        }
    }
}
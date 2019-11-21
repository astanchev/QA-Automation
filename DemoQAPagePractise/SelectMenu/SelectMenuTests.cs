namespace SelectMenu
{
    using System.Linq;
    using NUnit.Framework;
    using Pages.SelectMenuPage;

    [TestFixture]
    public class SelectMenuTests : BaseTest
    {

        private SelectMenuPage page;

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/");

            page = new SelectMenuPage(Driver);
            page.SelectMenuLink.Click();
        }

        [Test]
        public void TestAutocompleteListIsDisplayed()
        {
            page.SelectSpeed.Click();

            var expectedText = page.SpeedOptions[1].Text;

            page.ClickElement(page.SpeedOptions[1]);

            var actualText = page.SelectSpeed.Text;

            Assert.IsTrue(!page.SpeedOptions[1].Displayed);
            Assert.AreEqual(expectedText, actualText);

        }
    }
}
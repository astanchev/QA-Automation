namespace Menu
{
    using NUnit.Framework;
    using Pages.MenuPage;

    [TestFixture]
    public class MenuTests : BaseTest
    {
        private MenuPage page;

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/");

            page = new MenuPage(Driver);
            page.MenuLink.Click();
        }

        [Test]
        public void TestChooseAlternativeRock()
        {
            page.ClickElement(page.Menu);

            var isBeginingDisplayed = page.MusicRockElements[0].Displayed;

            Assert.IsFalse(isBeginingDisplayed);

            page.Hover(page.MainMenuElements[5]);
            page.Hover(page.MusicElements[0]);
            page.Hover(page.MusicRockElements[0]);
            page.ClickElement(page.MusicRockElements[0]);

            var isEndDisplayed = page.MusicRockElements[0].Displayed;

            Assert.IsTrue(isEndDisplayed);
        }
    }
}
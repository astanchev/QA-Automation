namespace Google_Search.Pages.GoogleResultPage
{
    using Contracts;
    using OpenQA.Selenium;

    public class GoogleResultPage : BasePage
    {
        public GoogleResultPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public IWebElement FirstLink => Wait.Until((w) => w.FindElement(By.ClassName(@"LC20lb")));

        public IWebPage GoToFirstLink()
        {
            FirstLink.Click();

            return this;
        }
    }
}
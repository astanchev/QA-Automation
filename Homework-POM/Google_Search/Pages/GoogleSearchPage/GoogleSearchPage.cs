namespace Google_Search.Pages.GoogleSearchPage
{
    using GoogleResultPage;
    using OpenQA.Selenium;

    public class GoogleSearchPage : BasePage
    {
        private const string URL = @"https://www.google.com/";
        public GoogleSearchPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public IWebElement SearchInput => Driver.FindElement(By.XPath(@"//input[@class='gLFyf gsfi']"));
        public IWebElement Logo => Driver.FindElement(By.Id("hplogo"));
        public IWebElement SearchButton => Driver.FindElement(By.XPath(@"//*[@id='tsf']/div[2]/div[1]/div[3]/center/input[1]"));
        
        public void Navigate()
        {
            Driver.Url = URL;
        }

        public GoogleResultPage Search(string text)
        {
            SearchInput.SendKeys(text);
            Logo.Click();
            SearchButton.Click();

            return new GoogleResultPage(Driver);
        }
    }
}
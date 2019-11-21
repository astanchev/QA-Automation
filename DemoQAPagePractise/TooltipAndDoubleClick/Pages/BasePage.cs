namespace TooltipAndDoubleClick.Pages
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public abstract class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(2));
        }

        public IWebDriver Driver => driver;
        public WebDriverWait Wait => wait;

    }
}
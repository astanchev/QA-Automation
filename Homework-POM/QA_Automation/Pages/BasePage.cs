namespace QA_Automation.Pages
{
    using System;
    using Contracts;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public abstract class BasePage : IWebPage
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

        public void ClosePage()
        {
            Driver.Quit();
        }
    }
}
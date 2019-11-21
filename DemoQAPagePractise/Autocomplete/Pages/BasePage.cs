using System;
using System.Collections.Generic;
using System.Text;

namespace Autocomplete.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class BasePage
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

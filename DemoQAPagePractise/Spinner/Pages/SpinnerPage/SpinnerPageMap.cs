namespace Spinner.Pages.SpinnerPage
{
    using System;
    using OpenQA.Selenium;

    partial class SpinnerPage
    {
        ////*[@id="sidebar"]/aside[2]/ul/li[8]/a

        public IWebElement SpinnerButton => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[8]/a"));

        public IWebElement InputBox => Driver.FindElement(By.Id("spinner"));

        public double? InputBoxValue
        {
            get
            {
                if (InputBox.GetAttribute("aria-valuenow") == null)
                {
                    return null;
                }

                return double.Parse(InputBox.GetAttribute("aria-valuenow"));
            }
        }

        public IWebElement EnableDisable => Driver.FindElement(By.Id("disable"));

        public IWebElement ToggleWidget => Driver.FindElement(By.Id("destroy"));

        public IWebElement GetValue => Driver.FindElement(By.Id("getvalue"));

        public IWebElement SetValueTo5 => Driver.FindElement(By.Id("setvalue"));
        public IWebElement WidgetUp
        {
            get
            {
                try
                {
                    return Driver.FindElement(By.XPath("//*[@id='content']/div[2]/p[1]/span/a[1]"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
        }

        public IWebElement WidgetDown => Driver.FindElement(By.XPath("//*[@id='content']/div[2]/p[1]/span/a[2]/span[1]"));
    }
}
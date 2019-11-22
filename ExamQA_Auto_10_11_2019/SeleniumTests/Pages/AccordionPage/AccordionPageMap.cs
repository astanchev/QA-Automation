namespace SeleniumTests.Pages.AccordionPage
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;

    public partial class AccordionPage
    {
        ////*[@id="sidebar"]/aside[2]/ul/li[19]/a
        public IWebElement AccordionButton => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[19]/a"));
        public IWebElement Accordion => Driver.FindElement(By.Id("accordion"));
        public List<IWebElement> Sections => Accordion.FindElements(By.TagName("h3")).ToList();
    }
}
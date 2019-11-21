namespace HTMLcontactForm.Pages.HTMLcontactFormPage
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;

    public partial class HTMLcontactFormPage
    {
        //*[@id="sidebar"]/aside[2]/ul/li[1]/a
        public IWebElement HTMLcontactFormButton => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[1]/a"));
        public string PageTitle => Driver.Title;
        public string PageSource => Driver.PageSource;
        public string PageUrl => Driver.Url;
        
        //*[@id="content"]/div[2]/div/form/input[1]
        public IWebElement FirstNameInput =>
            Driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/form/input[1]"));

        //*[@id="lname"]
        public IWebElement LastNameInput => Driver.FindElement(By.Id("lname"));

        //*[@id="content"]/div[2]/div/form/input[3]
        public IWebElement CountryInput =>
            Driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/form/input[3]"));

        public List<IWebElement> GoogleLinks => Driver.FindElements(By.PartialLinkText("Google Link")).ToList();

        //*[@id="subject"]
        public IWebElement TextAreaInput => Driver.FindElement(By.Id("subject"));

        //*[@id="content"]/div[2]/div/form/input[4]
        public IWebElement SubmitBUtton => Driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/form/input[4]"));

    }
}
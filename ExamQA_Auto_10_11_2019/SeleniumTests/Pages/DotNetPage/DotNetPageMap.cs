namespace SeleniumTests.Pages.DotNetPage
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;

    public partial class DotNetPage
    {
        ////*[@id="dotnetguides"]/li[2]/div/div/div/div[2]/h3/a
        public IWebElement NetCoreGuideLink => Driver.FindElement(By.XPath(@"//*[@id='dotnetguides']/li[2]/div/div/div/div[2]/h3/a"));
        
        ////*[@id="affixed-left-container"]/ul/li[17]/span
        public IWebElement UnitTestingLink => Driver.FindElements(By.ClassName("tree-expander")).FirstOrDefault(u => u.Text == "Unit Testing");

        ////*[@id="affixed-left-container"]/ul/li[17]/ul/li[4]/a
        public IWebElement CSharpNUnitLink => Driver.FindElements(By.XPath(@"//*[@class='tree-item is-expanded']/ul/li")).FirstOrDefault(u => u.Text == "C# unit testing with NUnit");

        public List<IWebElement> artickles => Driver.FindElements(By.XPath("//*[@id='affixed-right-container']/nav/ol/li")).Where(t => t.Text != "").ToList();


        ////*[@id="affixed-right-container"]/div/div[1]/div/div/button[1]/span[1]
        public IWebElement YesLink => Driver.FindElement(By.XPath(@"//*[@id='affixed-right-container']/div/div[1]/div/div/button[1]/span[1]"));

        ////*[@id="rating-feedback-mobile"]
        public IWebElement Feedback => Driver.FindElement(By.Id(@"rating-feedback-mobile"));

        ////*[@id="affixed-right-container"]/div/div[1]/form/div[2]/button[2]
        public IWebElement Submit => Driver.FindElement(By.XPath(@"//*[@id='affixed-right-container']/div/div[1]/form/div[2]/button[2]"));

        ////*[@id="affixed-right-container"]/div/div[2]/p
        public IWebElement ThankYou => Driver.FindElement(By.XPath(@"//*[@id='affixed-right-container']/div/div[2]/p"));

        public List<string> HeadersTwo => Driver
            .FindElements(By.TagName("h2"))
            .ToList()
            .FindAll(t => t.Text != "")
            .Select(h => h.Text)
            .ToList();
    }
}
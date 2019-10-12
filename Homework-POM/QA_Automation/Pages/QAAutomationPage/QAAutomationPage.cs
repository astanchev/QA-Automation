namespace QA_Automation.Pages.QAAutomationPage
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    public class QAAutomationPage : BasePage
    {
        public QAAutomationPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public IWebElement QaAutomationHeader => Wait.Until((w) => w.FindElement(By.XPath("/html/body/div[2]/header/h1")));

        public string Heading => QaAutomationHeader.GetAttribute("innerHTML");

        public void AssertHeading(string text)
        {
            StringAssert.Contains(text, this.Heading);
        }
    }
}
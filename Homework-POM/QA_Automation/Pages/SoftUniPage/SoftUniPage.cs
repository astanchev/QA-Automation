namespace QA_Automation.Pages.SoftUniPage
{
    using OpenQA.Selenium;
    using QAAutomationPage;

    public class SoftUniPage : BasePage
    {
        private const string URL = @"https://softuni.bg/";
        public SoftUniPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public IWebElement CourseButton => Wait.Until((w) => w.FindElement(By.XPath("//*[@id='header-nav']/div[1]/ul/li[2]/a")));

        public IWebElement QAAutomationLink => Wait.Until((w) => w.FindElement(By.PartialLinkText("QA Automation - септември 2019")));

        public void Navigate()
        {
            Driver.Url = URL;
        }

        public QAAutomationPage GoToQACoursePage()
        {
            CourseButton.Click();
            QAAutomationLink.Click();

            return new QAAutomationPage(Driver);
        }
    }
}
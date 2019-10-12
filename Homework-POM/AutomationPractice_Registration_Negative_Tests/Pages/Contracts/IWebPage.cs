namespace AutomationPractice_Registration_Negative_Tests.Pages.Contracts
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public interface IWebPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        string Url { get; }
        void ClosePage();

    }
}
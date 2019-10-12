namespace AutomationPractice_Registration_Page.Pages.Contracts
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public interface IWebPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }

        void ClosePage();

        void Navigate();
    }
}
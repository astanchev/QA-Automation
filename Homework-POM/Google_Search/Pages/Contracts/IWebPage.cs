namespace Google_Search.Pages.Contracts
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public interface IWebPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        string Title { get; }

        void ClosePage();
    }
}
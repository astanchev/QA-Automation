namespace Spinner.Pages.SpinnerPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class SpinnerPage : BasePage
    {
        private Actions action;
        public SpinnerPage(IWebDriver driver) 
            : base(driver)
        {
            action = new Actions(Driver);
        }

        public void ClickUpWidget()
        {
            if (this.WidgetUp.Displayed && this.WidgetUp != null)
            {
                action.MoveToElement(this.WidgetUp).Click().Build().Perform();
            }
        }

    }
}
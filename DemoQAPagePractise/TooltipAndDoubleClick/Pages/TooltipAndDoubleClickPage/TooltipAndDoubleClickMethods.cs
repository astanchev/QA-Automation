namespace TooltipAndDoubleClick.Pages.TooltipAndDoubleClickPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class TooltipAndDoubleClickPage : BasePage
    {
        private Actions builder;
        public TooltipAndDoubleClickPage(IWebDriver driver) 
            : base(driver)
        {
            builder = new Actions(Driver);
        }

        public void Hover(IWebElement element)
        {
            builder.MoveToElement(element).Perform();
        }

        public void DoubleClick(IWebElement element)
        {
            builder.MoveToElement(element).DoubleClick().Build().Perform();
        }

        public void RightClick(IWebElement element)
        {
            builder.MoveToElement(element).ContextClick().Build().Perform();
        }
    }
}
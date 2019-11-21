namespace Controlgroup.Pages.ControlgroupPage
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class ControlgroupPage : BasePage
    {
        private Actions builder;
        private IJavaScriptExecutor executor;
        public ControlgroupPage(IWebDriver driver) 
            : base(driver)
        {
            builder = new Actions(Driver);
            executor = (IJavaScriptExecutor) Driver;
        }

        public void Hover(IWebElement element)
        {
            builder.MoveToElement(element).Perform();
        }

        public void DoubleClick(IWebElement element)
        {
            builder.MoveToElement(element).DoubleClick().Build().Perform();
        }

        public void ClickAndHold(IWebElement element)
        {
            builder.MoveToElement(element).ClickAndHold().Build().Perform();
        }

        public void ReleaseHold(IWebElement element)
        {
            builder.Release();
        }
        public void ClickElement(IWebElement element)
        {
            builder.MoveToElement(element).Click().Build().Perform();
        }

        public void RightClick(IWebElement element)
        {
            builder.MoveToElement(element).ContextClick().Build().Perform();
        }

        public void MoveHandle(IWebElement element)
        {
            builder.DragAndDropToOffset(element, 0, -20);
        }

        public double Position
        {
            get
            {
                double value = Convert.ToDouble(executor.ExecuteScript("return window.pageYOffset;"));
                return value;
            }
        }

        public void ScrollTo(IWebElement element)
        {
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ScrollToTop()
        {
            executor.ExecuteScript("window.scrollTo(0, 0)");
        }

        public void ScrollBelowNavigation()
        {
            executor.ExecuteScript("window.scrollBy(0, -120)");
        }
    }
}
namespace TooltipAndDoubleClick.Pages.TooltipAndDoubleClickPage
{
    using OpenQA.Selenium;

    public partial class TooltipAndDoubleClickPage
    {
        ////*[@id="sidebar"]/aside[2]/ul/li[5]/a
        public IWebElement TooltipAndDoubleClickLink => Driver.FindElement(By.XPath("//*[@id='sidebar']/aside[2]/ul/li[5]/a"));
        public IWebElement DoubleClickBox => Driver.FindElement(By.Id("doubleClickBtn"));
        public IWebElement RightClickBox => Driver.FindElement(By.Id("rightClickBtn"));

        ////*[@id="tooltipDemo"]
        public IWebElement ToolTipInput => Driver.FindElement(By.Id("tooltipDemo"));

        ////*[@id="tooltipDemo"]/span
        public IWebElement ToolTipMessage => Driver.FindElement(By.ClassName("tooltiptext"));
        public IWebElement RightClickMenu => Driver.FindElement(By.Id("rightclickItem"));


    }
}
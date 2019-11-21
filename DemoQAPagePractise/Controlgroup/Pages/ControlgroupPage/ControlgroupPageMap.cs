namespace Controlgroup.Pages.ControlgroupPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class ControlgroupPage
    {
        //*[@id="sidebar"]/aside[2]/ul/li[15]/a
        public IWebElement ControlgroupLink => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[15]/a"));

        //*[@id="ui-id-8-button"]
        public IWebElement RentalCar => Driver.FindElement(By.XPath("//*[@id='ui-id-8-button']"));

        //the attribute style is set to style="display: none;"
        public SelectElement NotDisplayedSelectMenu => new SelectElement(Driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/fieldset[2]/div/select")));

    }
}
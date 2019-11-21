namespace SelectMenu.Pages.SelectMenuPage
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class SelectMenuPage
    {
        //*[@id="sidebar"]/aside[2]/ul/li[10]/a
        public IWebElement SelectMenuLink => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[10]/a"));

        public List<IWebElement> SelectableMenus => Driver.FindElements(By.ClassName("ui-selectmenu-text")).ToList();

        //*[@id="speed-menu"]
        public IWebElement SelectSpeed => this.SelectableMenus[0];
        public List<IWebElement> SpeedOptions => Driver.FindElements(By.XPath(@"//*[contains(@id, 'ui-id-')]")).ToList();
        public IWebElement SelectFile => this.SelectableMenus[1];
        public IWebElement SpeSelectNumberedMenu => this.SelectableMenus[2];
        public IWebElement SelectTitle => this.SelectableMenus[3];
    }
}
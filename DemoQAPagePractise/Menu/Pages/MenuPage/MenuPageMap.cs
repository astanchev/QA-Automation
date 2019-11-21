namespace Menu.Pages.MenuPage
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;

    public partial class MenuPage
    {
        //*[@id="sidebar"]/aside[2]/ul/li[12]/a
        public IWebElement MenuLink => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[12]/a"));

        public IWebElement Menu => Driver.FindElement(By.Id("menu"));

        //*[@id="menu"]/li
        public List<IWebElement> MainMenuElements => Driver.FindElements(By.XPath("//*[@id='menu']/li")).ToList();

        //*[@id="menu"]/li[4]/ul/li
        public List<IWebElement> ElectronicsElements => Driver.FindElements(By.XPath("//*[@id='menu']/li[4]/ul/li")).ToList();

        //*[@id="menu"]/li[6]/ul/li
        public List<IWebElement> MusicElements => Driver.FindElements(By.XPath("//*[@id='menu']/li[6]/ul/li")).ToList();

        //*[@id="menu"]/li[6]/ul/li[1]/ul/li
        public List<IWebElement> MusicRockElements => Driver.FindElements(By.XPath("//*[@id='menu']/li[6]/ul/li[1]/ul/li")).ToList();

        //*[@id="menu"]/li[6]/ul/li[2]/ul/li
        public List<IWebElement> MusicJazzElements => Driver.FindElements(By.XPath("//*[@id='menu']/li[6]/ul/li[2]/ul/li")).ToList();
    }
}
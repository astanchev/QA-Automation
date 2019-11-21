namespace Autocomplete.Pages.AutocompletePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using SeleniumExtras.WaitHelpers;

    public partial class AutocompletePage
    {
        //*[@id="sidebar"]/aside[2]/ul/li[18]/a
        public IWebElement AutocompleteButton => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[18]/a"));

        public IWebElement TagInput => Driver.FindElement(By.Id("tags"));

        public List<IWebElement> AutocompleteDropList => Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(@"//*[contains(@id, 'ui-id-')]"))).ToList();

        public IWebElement FullList => this.AutocompleteDropList[0];
        public List<string> WholeListOfSuggestions => this.FullList
                                                          .Text
                                                          .Split(Environment.NewLine)
                                                          .OrderBy(s => s)
                                                          .ToList();
    }
}
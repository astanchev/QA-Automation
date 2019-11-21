namespace HTMLcontactForm.Pages.HTMLcontactFormPage
{
    using OpenQA.Selenium;

    public partial class HTMLcontactFormPage 
        : BasePage
    {
        public HTMLcontactFormPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public void FillAllFields()
        {
            this.FirstNameInput.SendKeys("AAAAAA");
            this.LastNameInput.SendKeys("AAAAAA");
            this.CountryInput.SendKeys("AAAAAA");
            this.TextAreaInput.SendKeys("AAAAAA");
            this.SubmitBUtton.Click();

        }
    }
}
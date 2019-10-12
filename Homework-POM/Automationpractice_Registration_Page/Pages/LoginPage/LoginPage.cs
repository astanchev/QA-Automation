namespace AutomationPractice_Registration_Page.Pages.LoginPage
{
    using Pages;
    using OpenQA.Selenium;
    using RegistrationPage;

    public class LoginPage : BasePage
    {
        private const string URL = @"http://automationpractice.com/index.php?controller=authentication&back=my-account";
        public LoginPage(IWebDriver driver) 
            : base(driver)
        {
        }
        public IWebElement Email => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("email_create")));

        public IWebElement Submit => Wait.Until((w) => w.FindElement(By.Id("SubmitCreate")));

        public override void Navigate()
        {
            Driver.Url = URL;
        }


        public RegistrationPage CreateAccount(string email)
        {
            this.Email.SendKeys(email);
            this.Submit.Click();

            return new RegistrationPage(Driver);
        }
    }
}
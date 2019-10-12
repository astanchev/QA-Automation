namespace AutomationPractice_Registration_Negative_Tests.Pages.LoginPage
{
    using OpenQA.Selenium;
    using RegistrationPage;
    using System;

    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) 
            : base(driver)
        {
        }
        
        public IWebElement Email => Wait.Until((w) => w.FindElement(By.Id("email_create")));

        public IWebElement Submit => Wait.Until((w) => w.FindElement(By.Id("SubmitCreate")));
        public override string Url => @"http://automationpractice.com/index.php?controller=authentication&back=my-account";


        public RegistrationPage CreateAccount()
        {
            string email = $"{Guid.NewGuid().ToString().Substring(0, 9)}@gmail.com";

            this.Email.SendKeys(email);
            this.Submit.Click();

            return new RegistrationPage(Driver);
        }
    }
}
namespace AutomationPractice_Registration_Page.Pages.RegistrationPage
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    public class RegistrationPage : BasePage
    {
        private const string URL = @"http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
        public RegistrationPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public IWebElement EmailText => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//form[@id='account-creation_form']//input[@id='email']")));

        public override void Navigate()
        {
            Driver.Url = URL;
        }

        public void AssertCorrectEmailInRegForm(string expectedText)
        {
            var actualValueString = this.EmailText.GetAttribute("value");

            Assert.AreEqual(expectedText, actualValueString);
        }
    }
}
namespace AutomationPractice_Registration_Page.Pages.HomePage
{
    using Pages;
    using LoginPage;
    using OpenQA.Selenium;

    public class HomePage : BasePage
    {
        private const string URL = @"http://automationpractice.com/index.php";
        public HomePage(IWebDriver driver) 
            : base(driver)
        {
        }

        public IWebElement SignInButton => Wait.Until((w) => w.FindElement(By.ClassName("login")));
        public override void Navigate()
        {
            Driver.Url = URL;
        }

        public LoginPage GoToLogin()
        {
            SignInButton.Click();

            return new LoginPage(Driver);
        }
    }
}
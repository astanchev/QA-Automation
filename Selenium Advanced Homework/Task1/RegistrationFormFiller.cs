namespace Task1
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class RegistrationFormFiller
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private User registrationUser;

        public RegistrationFormFiller(IWebDriver driverIN, WebDriverWait waitIN)
        {
            registrationUser = UserFactory.CreateUser();

            driver = driverIN;
            wait = waitIN;

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");
        }

        public void FillRegistrationForm()
        {
            var emailInput = driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys(registrationUser.EMail);

            var createAccountButton = driver.FindElement(By.Id("SubmitCreate"));
            createAccountButton.Click();

            var radioButtons = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='radio']//input")));
            radioButtons[0].Click();

            var firstName = driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys(registrationUser.FirstName);

            var lastName = driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys(registrationUser.LastName);

            var password = driver.FindElement(By.Id("passwd"));
            password.SendKeys(registrationUser.Password);

            var dateDD = wait.Until(d => d.FindElement(By.Id("days")));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue(registrationUser.Day);

            var monthDD = driver.FindElement(By.Id("months"));
            SelectElement months = new SelectElement(monthDD);
            months.SelectByValue(registrationUser.Month);

            var yearDD = driver.FindElement(By.Id("years"));
            SelectElement years = new SelectElement(yearDD);
            years.SelectByValue(registrationUser.Year);

            var realFirstName = driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys(registrationUser.AddressFirstName);

            var realLastName = driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys(registrationUser.AddressLastName);

            var address = driver.FindElement(By.Id("address1"));
            address.SendKeys(registrationUser.Address);

            var city = driver.FindElement(By.Id("city"));
            city.SendKeys(registrationUser.City);

            var stateDD = driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText(registrationUser.State);

            var postcode = driver.FindElement(By.Id("postcode"));
            postcode.SendKeys(registrationUser.Postalcode);

            var phone = driver.FindElement(By.Id("phone_mobile"));
            phone.SendKeys(registrationUser.MobilePhone);

            var alias = driver.FindElement(By.Id("alias"));
            Type(alias, registrationUser.Alias);
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}

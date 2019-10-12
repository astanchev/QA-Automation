namespace AutomationPractice_Registration_Negative_Tests.Pages.RegistrationPage
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    public partial class RegistrationPage
    {
        public void AssertErrorMessage(string expectedText)
        {
            var actualErrorString = ErrorMessage.GetAttribute("innerHTML");

            Assert.AreEqual(expectedText, actualErrorString);
        }

        public void AssertTwoErrorMessages(string expectedText)
        {
            var actualErrorString = ErrorMessageNumberErrors.GetAttribute("innerHTML");

            Assert.AreEqual(expectedText, actualErrorString);
        }

        public void AssertErrorDisplayed()
        {
            Assert.IsTrue(IsErrorDisplayed());
        }

        private bool IsErrorDisplayed()
        {
            try
            {
                var visibleError = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(@"//*[@id='center_column']/div")));
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }
    }
}
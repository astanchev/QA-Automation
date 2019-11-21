namespace TooltipAndDoubleClick.Pages.TooltipAndDoubleClickPage
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    public partial class TooltipAndDoubleClickPage
    {
        public void AssertDifferentBackgroundColors(string before, string after)
        {
            Assert.AreNotEqual(before, after);
        }

        public void AssertAlertIsDisplayed()
        {
            IAlert alert = Driver.SwitchTo().Alert();

            Assert.IsNotNull(alert);

            alert.Accept();
        }

        public void AssertAlertMessageIsDisplayedCorrectly(string expectedMessage)
        {
            IAlert alert = Driver.SwitchTo().Alert();

            string alertMessage = alert.Text.Substring(alert.Text.IndexOf("Hi"));

            Assert.AreEqual(alertMessage, expectedMessage);

            alert.Accept();
        }

        public void AssertElementIsDisplayed(IWebElement element)
        {
            Assert.IsTrue(element.Displayed);
        }
    }
}
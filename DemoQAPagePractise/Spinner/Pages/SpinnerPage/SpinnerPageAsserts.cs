namespace Spinner.Pages.SpinnerPage
{
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;

    partial class SpinnerPage
    {
        public void AssertWidgetUpIsNull(IWebElement widget)
        {
            Assert.IsNull(widget);
        }

        public void AssertOnPageLoadInputValueIsNull(double? inputBoxValue)
        {
            Assert.IsNull(inputBoxValue);
        }

        public void AssertValueinInputFieldShouldBeAsGiven(double? inputBoxValue, double givenValue)
        {
            Assert.AreEqual(givenValue, inputBoxValue);
        }

        public void AssertValueShownInPopUpIsSameAsInInputBox(string actualInputBoxValue)
        {
            IAlert alert = Driver.SwitchTo().Alert();

            var text = alert.Text;

            Assert.AreEqual(actualInputBoxValue, text);

            alert.Accept();
        }

        public void AssertDoubleValuesAreEqual(string expected, string actual)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
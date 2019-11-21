namespace TooltipAndDoubleClick
{
    using NUnit.Framework;
    using Pages.TooltipAndDoubleClickPage;

    [TestFixture]
    public class TooltipAndDoubleClickTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        public void TestHoverOverDoubleClickChangeColor()
        {
            var tipAndClick = new TooltipAndDoubleClickPage(Driver);
            tipAndClick.TooltipAndDoubleClickLink.Click();

            var startColor = tipAndClick.DoubleClickBox.GetCssValue("background-color");

            tipAndClick.Hover(tipAndClick.DoubleClickBox);
            var endColor = tipAndClick.DoubleClickBox.GetCssValue("background-color");

            tipAndClick.AssertDifferentBackgroundColors(startColor, endColor);
        }

        [Test]
        public void TestDoubleClickDisplayAlert()
        {
            var tipAndClick = new TooltipAndDoubleClickPage(Driver);
            tipAndClick.TooltipAndDoubleClickLink.Click();

            tipAndClick.DoubleClick(tipAndClick.DoubleClickBox);

            tipAndClick.AssertAlertIsDisplayed();
        }

        [Test]
        public void TestDoubleClickDisplayCorrectAlertMessage()
        {
            var tipAndClick = new TooltipAndDoubleClickPage(Driver);
            tipAndClick.TooltipAndDoubleClickLink.Click();

            tipAndClick.DoubleClick(tipAndClick.DoubleClickBox);

            var expectedMessage = "Hi,You are seeing this message as you have double cliked on the button";

            tipAndClick.AssertAlertMessageIsDisplayedCorrectly(expectedMessage);
        }

        [Test]
        public void TestHoverOverTooltipDisplaysMessage()
        {
            var tipAndClick = new TooltipAndDoubleClickPage(Driver);
            tipAndClick.TooltipAndDoubleClickLink.Click();

            tipAndClick.Hover(tipAndClick.ToolTipInput);

            tipAndClick.AssertElementIsDisplayed(tipAndClick.ToolTipMessage);
        }

        [Test]
        public void TestRightClickOnRightClickDisplaysMenu()
        {
            var tipAndClick = new TooltipAndDoubleClickPage(Driver);
            tipAndClick.TooltipAndDoubleClickLink.Click();

            tipAndClick.RightClick(tipAndClick.RightClickBox);

            tipAndClick.AssertElementIsDisplayed(tipAndClick.RightClickMenu);
        }
    }
}
namespace Spinner
{
    using NUnit.Framework;
    using Pages.SpinnerPage;

    [TestFixture]
    public class SpinnerTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        public void TestSpinnerWidgetUp()
        {
            var spinner = new SpinnerPage(Driver);

            spinner.SpinnerButton.Click();
            spinner.ToggleWidget.Click();

            spinner.AssertWidgetUpIsNull(spinner.WidgetUp);

        }

        [Test]
        public void TestClickSpinnerWidgetUpIncreaseValue()
        {
            var spinner = new SpinnerPage(Driver);
            spinner.SpinnerButton.Click();

            spinner.SetValueTo5.Click();
            var oldValue = GetActualInputBoxValue(spinner);
            var expectedValue = (double.Parse(oldValue) + 1).ToString();


            spinner.ClickUpWidget();
            var actualValue = GetActualInputBoxValue(spinner);

            spinner.AssertDoubleValuesAreEqual(expectedValue, actualValue);

        }


        [Test]
        public void TestSpinnerFirstInputValueShouldBeNull()
        {
            var spinner = new SpinnerPage(Driver);
            spinner.SpinnerButton.Click();

            spinner.AssertOnPageLoadInputValueIsNull(spinner.InputBoxValue);

        }

        [Test]
        public void TestSpinnerWhenSetValueIsPressedInputValueShouldBe5()
        {
            var spinner = new SpinnerPage(Driver);
            spinner.SpinnerButton.Click();

            spinner.SetValueTo5.Click();

            spinner.AssertValueinInputFieldShouldBeAsGiven(spinner.InputBoxValue, 5);

        }

        [Test]
        public void TestSpinnerGetValueInitialyShouldShowNull()
        {
            var spinner = new SpinnerPage(Driver);
            spinner.SpinnerButton.Click();
            var actualInputBoxValue = GetActualInputBoxValue(spinner);

            spinner.GetValue.Click();

            spinner.AssertValueShownInPopUpIsSameAsInInputBox(actualInputBoxValue);
        }

        [Test]
        public void TestSpinnerGetValueShouldShowValue()
        {
            var spinner = new SpinnerPage(Driver);
            spinner.SpinnerButton.Click();

            spinner.SetValueTo5.Click();
            var actualInputBoxValue = GetActualInputBoxValue(spinner);
            spinner.GetValue.Click();

            spinner.AssertValueShownInPopUpIsSameAsInInputBox(actualInputBoxValue);
        }

        private static string GetActualInputBoxValue(SpinnerPage spinner)
        {
            string actualInputBoxValue = spinner.InputBoxValue != null
                ? spinner.InputBoxValue.ToString()
                : "null";
            return actualInputBoxValue;
        }
    }
}
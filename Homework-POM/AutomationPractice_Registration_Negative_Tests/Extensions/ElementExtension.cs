namespace AutomationPractice_Registration_Negative_Tests.Extensions
{
    using OpenQA.Selenium;

    public static class ElementExtension
    {
        public static void Type(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }
    }
}
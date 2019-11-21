namespace HTMLcontactForm.Pages.HTMLcontactFormPage
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    public partial class HTMLcontactFormPage
    {
        public void AssertPlaceholderText(IWebElement element, string expectedText)
        {
            var actualText = element.GetAttribute("placeholder");

            Assert.AreEqual(expectedText, actualText);
        }

        public void AssertRedirectToPage(HTMLcontactFormPage page, string expectedTitle)
        {
            StringAssert.Contains(expectedTitle, page.PageTitle);
        }

        public void AssertCorrectUrl(HTMLcontactFormPage page, string url)
        {
            StringAssert.Contains(url, page.PageUrl);
        }
    }
}
namespace HTMLcontactForm
{
    using NUnit.Framework;
    using Pages.HTMLcontactFormPage;

    [TestFixture]
    public class HTMLcontactFormTests : BaseTest
    {
        private HTMLcontactFormPage page;

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/");

            page = new HTMLcontactFormPage(Driver);
            page.HTMLcontactFormButton.Click();
        }

        [Test]
        public void TestInputSubjectPlaceholder()
        {
            var placeholderText = @"Write something..";

            page.AssertPlaceholderText(page.TextAreaInput, placeholderText);
        }

        [Test]
        public void TestFillFormAndPressSubmitShouldRedirect()
        {
            page.FillAllFields();

            string expectedTitle = @"Page not found";
            page.AssertRedirectToPage(page, expectedTitle);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void TestGoogleLinkRedirectToGoogle(int link)
        {
            page.GoogleLinks[link].Click();

            string expectedTitle = "Google";
            string expectedUrl = "google.com";

            page.AssertRedirectToPage(page, expectedTitle);
            page.AssertCorrectUrl(page, expectedUrl);
        }
    }
}
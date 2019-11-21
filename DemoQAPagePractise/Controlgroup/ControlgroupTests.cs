namespace Controlgroup
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Pages.ControlgroupPage;

    public class ControlgroupTests : BaseTest
    {
        private ControlgroupPage page;

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/");

            page = new ControlgroupPage(Driver);
            page.ControlgroupLink.Click();
        }

        [Test]
        public void TestFillForm()
        { 
            page.ClickElement(page.RentalCar);
            //*[@id="content"]/div[2]/div/fieldset[2]/div
            SelectElement el = new SelectElement(Driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/fieldset[2]/div/select")));
            el.SelectByText("SUV");
        }

    }
}
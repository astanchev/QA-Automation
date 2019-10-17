namespace QA_Automation
{
    using NUnit.Framework;

    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    using Pages.SoftUniPage;

    using System;

    public class QAAutomationTests
    {
        private SoftUniPage softUniPage;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();

            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";


            var driver = new RemoteWebDriver(new Uri("http://192.168.100.5:21928/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            softUniPage = new SoftUniPage(driver);
        }


        [TearDown]
        public void TearDown()
        {
            softUniPage.ClosePage();
        }
        [Test]
        public void CheckQAAutomationCourseHeading()
        {
            softUniPage.Navigate();

            var coursePage = softUniPage.GoToQACoursePage();
            var expectedHeading = "QA Automation - септември 2019";

            coursePage.AssertHeading(expectedHeading);
        }
    }
}

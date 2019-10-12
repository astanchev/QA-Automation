namespace QA_Automation
{
    using NUnit.Framework;

    using OpenQA.Selenium.Chrome;

    using Pages.SoftUniPage;

    using System.IO;
    using System.Reflection;

    public class QAAutomationTests
    {
        private SoftUniPage softUniPage;

        [SetUp]
        public void SetUp()
        {
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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

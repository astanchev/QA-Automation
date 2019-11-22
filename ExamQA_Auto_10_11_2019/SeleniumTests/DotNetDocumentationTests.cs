namespace SeleniumTests
{
    using System;
    using System.Linq;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    using Pages.DotNetPage;
    using SeleniumExtras.WaitHelpers;

    [TestFixture]
    public class DotNetDocumentationTests : BaseTest
    {
        [Test]
        public void TestVerifyCorrectnesOfArticleSectionAndVoteMassage()
        {
            //Arrange
            Driver.Navigate().GoToUrl("https://docs.microsoft.com/en-us/dotnet/");
            var dotNetPage = new DotNetPage(Driver);

            //Act
            dotNetPage.NetCoreGuideLink.Click();
            dotNetPage.UnitTestingLink.Click();
            dotNetPage.CSharpNUnitLink.Click();

            for (int i = 0; i < dotNetPage.artickles.Count; i++)
            {
                //Arrange
                var article = dotNetPage.artickles[i];

                //Act
                var startPosition = dotNetPage.Position;

                article.Click();

                var endPosition = dotNetPage.Position;
                var expected = article.Text;

                //Assert
                Assert.That(dotNetPage.HeadersTwo, Has.Member(expected));

                if (i > 0)
                {
                    Assert.IsTrue(endPosition > startPosition);
                }
                else
                {
                    Assert.AreEqual(startPosition, endPosition);
                }

                dotNetPage.ScrollToTop();
            }


            dotNetPage.ClickElement(dotNetPage.YesLink);
            dotNetPage.Submit.Click();
            var input = Driver.SwitchTo().ActiveElement();
            input.SendKeys("Yes");
            dotNetPage.Submit.Click();


            //Assert
            Assert.IsTrue(dotNetPage.ThankYou.Displayed);
        }
    }
}
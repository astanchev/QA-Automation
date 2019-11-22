namespace SeleniumTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Pages.AccordionPage;

    [TestFixture]
    public class AccordionTests : BaseTest
    {
        [Test]
        [TestCase(0, 1, 2, 3)]
        [TestCase(1, 0, 2, 3)]
        [TestCase(2, 1, 0, 3)]
        [TestCase(3, 1, 2, 0)]
        public void OnlyClickedSectionShouldBeVisible(int clicked, int other1, int other2, int other3)
        {
            //Arrange
            Driver.Navigate().GoToUrl("http://demoqa.com/");
            var accordion = new AccordionPage(Driver);

            //Act
            accordion.AccordionButton.Click();

            //Assert ToggleIcons are presented
            accordion.AssertOneOpenTriangleIsPresent();
            accordion.AssertThreeClosedTrianglesArePresent();

            //Act
            accordion.Sections[clicked].Click();

            var sectionClickedExpandStatus = accordion.Sections[clicked].GetAttribute("aria-expanded");
            var sectionOther1ExpandStatus = accordion.Sections[other1].GetAttribute("aria-expanded");
            var sectionOther2ExpandStatus = accordion.Sections[other2].GetAttribute("aria-expanded");
            var sectionOther3ExpandStatus = accordion.Sections[other3].GetAttribute("aria-expanded");

            //Assert Expanded Status for all sections
            accordion.AssertExpandedStatus(sectionClickedExpandStatus, "true");
            accordion.AssertExpandedStatus(sectionOther1ExpandStatus, "false");
            accordion.AssertExpandedStatus(sectionOther2ExpandStatus, "false");
            accordion.AssertExpandedStatus(sectionOther3ExpandStatus, "false");

        }

    }
}
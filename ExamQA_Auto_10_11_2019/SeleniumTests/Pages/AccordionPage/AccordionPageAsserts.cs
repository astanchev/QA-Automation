namespace SeleniumTests.Pages.AccordionPage
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;

    public partial class AccordionPage
    {
        public void AssertOneOpenTriangleIsPresent()
        {
            var triangle = Driver.FindElement(By.XPath(@"//*[@class='ui-accordion-header-icon ui-icon ui-icon-triangle-1-s']"));

            Assert.IsTrue(triangle.Displayed);
        }

        public void AssertThreeClosedTrianglesArePresent()
        {
            var triangles = Driver.FindElements(By.XPath(@"//*[@class='ui-accordion-header-icon ui-icon ui-icon-triangle-1-e']"));

            Assert.IsTrue(triangles.Count == 3);
        }

        public void AssertExpandedStatus(string sectionStatus, string expectedStatus)
        {
            Assert.AreEqual(expectedStatus, sectionStatus);
        }

    }
}
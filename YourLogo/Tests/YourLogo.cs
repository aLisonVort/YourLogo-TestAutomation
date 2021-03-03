using DnsClient.Protocol;
using FluentAssertions;
using FluentAssertions.Execution;
using YourLogo.Framework.Constants;
using YourLogo.Interfaces;
using YourLogo.PageObjects;
using YourLogo.PageObjects.Sections;
using YourLogo.PageObjects.Sections.Decorators;
using YourLogo.Pages;
using YourLogo.Tests;
using YourLogo.TestsInfo;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;

namespace YourLogo.UI
{
    [TestFixture]
    public class SectionNavigation : UIBaseTest
    {
        YourLogoBasePage startPage;
        WomenSection womenSection;
        SectionsTypes sectionType;

        public override void SetUp()
        {
            startPage = new YourLogoBasePage(driver);
            womenSection = startPage.SelectWomenSection();
        }

        public override void ExtendedOneTimeTearDown()
        {
            SetDriverInstance(sectionType.GetDriver());
        }

        
        
        [Test]
        [TestCase("Women", "Tops")]

        public void NavigateToTopsSubSection(string section, string subSection)
        {
            sectionType = new WomenSectionType(driver, womenSection);
            sectionType.SelectSubSection();
            using (new AssertionScope())
            {

                sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(section);
                sectionType.GetCurrentURL().Should().BeEquivalentTo(Url.BaseUrl + Url.WomenSection);
            }

            sectionType = new WomenSubsectionTops(driver, sectionType);
            sectionType.SelectSubSection();
            using (new AssertionScope())
            {
                sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(subSection);
                sectionType.GetCurrentURL().Should().BeEquivalentTo(Url.BaseUrl + Url.TopsSubSection);
            }
        }

        [Test]
        [TestCase("Women", "Dresses")]

        public void NavigateToDressesSubSection(string section, string subSection)
        {
            sectionType = new WomenSectionType(driver, womenSection);
            sectionType.SelectSubSection();
            using (new AssertionScope())
            {

                sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(section);
                sectionType.GetCurrentURL().Should().BeEquivalentTo(Url.BaseUrl + Url.WomenSection);
            }

            sectionType = new WomenSubsectionDresses(driver, sectionType);
            sectionType.SelectSubSection();
            using (new AssertionScope())
            {
                sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(subSection);
                sectionType.GetCurrentURL().Should().BeEquivalentTo(Url.BaseUrl + Url.DressesSubSection);
            }
            
        }
    }
}

using YourLogo.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.PageObjects.Sections.Decorators
{
    class WomenSubsectionTops: WomenSectionType
    {
        public WomenSubsectionTops(IWebDriver driver, ISectionType section) : base(driver, section)
        {

        }

        public IWebElement topsSection
            => driver.FindElement(By.LinkText("Tops"));

        public override dynamic SelectSubSection()
        {
            try
            {
                topsSection.Click();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(nameof(topsSection) + $" element is not present on the {nameof(WomenSubsectionTops)}page");
            }
            return new TopsSubSection(driver);
        } 
    }
}

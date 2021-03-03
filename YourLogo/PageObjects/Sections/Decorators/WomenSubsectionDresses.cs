using YourLogo.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.PageObjects.Sections.Decorators
{
    class WomenSubsectionDresses: WomenSectionType
    {
        public WomenSubsectionDresses( IWebDriver driver, ISectionType section) : base(driver, section)
        {

        }

        public IWebElement dressesSection
            => driver.FindElement(By.LinkText("Dresses"));
        public override dynamic SelectSubSection()
        {
            try
            {

            dressesSection.Click();
            }catch(NoSuchElementException e)
            {
                Console.WriteLine(nameof(dressesSection) + $" element is not present on the {nameof(WomenSubsectionDresses)}page");
            }
            return new TopsSubSection(driver);
        }
    }
}

using YourLogo.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.PageObjects.Sections.Decorators
{
    public  class WomenSectionType : SectionsTypes
    {
        public WomenSectionType(IWebDriver driver ,ISectionType section) : base(section, driver)
        {

        }

    }
}

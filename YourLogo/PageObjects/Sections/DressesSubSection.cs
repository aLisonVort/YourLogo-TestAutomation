using YourLogo.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.PageObjects.Sections
{
    class DressesSubSection:BasePage
    {
        public DressesSubSection(IWebDriver driver): base(driver)
        {
            this.driver = driver;
        }
    }
}

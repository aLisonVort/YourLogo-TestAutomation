using YourLogo.Interfaces;
using YourLogo.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.PageObjects.Sections.Decorators
{
    public class SectionsTypes : BasePage, ISectionType
    {
        private readonly ISectionType _sectionType;
        //protected IWebDriver driver;

        public SectionsTypes(ISectionType section, IWebDriver driver): base(driver)
        {
            this.driver = driver;
            _sectionType = section;
        }
        public IWebElement sectionName
            => driver.FindElement(By.XPath("//span[@class = 'category-name']"));

        public virtual string GeTypeOfSelectedProductSection()
        {
            return sectionName.Text;
    }

        public virtual dynamic SelectSubSection()
        {
            return _sectionType.SelectSubSection();
        }
    }
}

using YourLogo.Interfaces;
using YourLogo.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.PageObjects.Sections
{
    public class WomenSection: BasePage, ISectionType
    {
        public WomenSection(IWebDriver driver): base(driver)
        {
            this.driver = driver;
        }

        public IWebElement sectionName
            => driver.FindElement(By.XPath("//span[@class = 'category-name']"));

        public string GeTypeOfSelectedProductSection()
        {
            string rtn;
            try
            {
                rtn = sectionName.Text;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                rtn = "";
            }
            return rtn; 
        }

        public dynamic SelectSubSection()
        {
            return new WomenSection(driver);
        }
    }
}

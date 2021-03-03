using YourLogo.Framework.Constants;
using YourLogo.Interfaces;
using YourLogo.PageObjects.Sections;
using YourLogo.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.PageObjects
{
    public class YourLogoBasePage : BasePage
    {
        public YourLogoBasePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(Url.BaseUrl);
        }

        public IWebElement womenSection
            => driver.FindElement(By.LinkText("Women"));
        

        public WomenSection SelectWomenSection()
        {
            Click(womenSection);
            return new WomenSection(driver);
        }
    }
}

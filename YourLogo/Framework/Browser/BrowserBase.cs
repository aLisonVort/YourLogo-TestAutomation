using YourLogo.Framework.Constants;
using YourLogo.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Framework.Browser
{
    public class Browser
    {
        private Browser _browser;
        public IWebDriver _driver { get; set; }
        protected static string browserType { get; set; }

        public Browser() { }
        public Browser(string browserT)
        {
            browserType = browserT;
            // Start the driver
            switch (browserType)
            {
                case Browsers.Chrome:
                     _browser = new Chrome();
                    break;

                case Browsers.FireFox:
                    _browser = new FireFox();
                    break;

                default:
                    throw new Exception("Browser type is not impletenmed: " + browserType);
            }

            _browser._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Const.ImplicitWait);
            _browser._driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Const.PageLoadWait);
            this._driver = _browser._driver;
        }

    }
}

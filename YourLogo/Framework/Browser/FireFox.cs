using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Framework.Browser
{
    class FireFox: Browser
    {
        public FireFox() 
        {
            _driver = StartFirefox();
        }
        private IWebDriver StartFirefox()
        {
            IWebDriver rtn = null;
            rtn = new FirefoxDriver();
            return rtn;
        }
    }
}

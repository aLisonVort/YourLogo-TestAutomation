using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Framework.Browser
{
    public class Chrome : Browser
    {
        public Chrome(bool headless = false, string workDir = "")
        {
            _driver = _StartChrome(headless, workDir);
        }
        private IWebDriver _StartChrome(bool headless = false, string workDir = "")
        {
            IWebDriver rtn = null;
            ChromeOptions options = new ChromeOptions();

            if (!string.IsNullOrEmpty(workDir))
                options.AddUserProfilePreference("download.default_directory", workDir);


            if (headless)
            {
                options.AddArgument("headless");
            }
            rtn = new ChromeDriver(options);

            return rtn;
        }
    }
}

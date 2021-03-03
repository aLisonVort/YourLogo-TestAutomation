using FluentAssertions;
using YourLogo.Interfaces;
using YourLogo.TestsInfo;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace YourLogo.Pages
{
    public abstract class BasePage : IPage
    {
        protected  WebDriverWait wait;
        protected IWebDriver driver { get; set; }
        protected Logger logger { get; set; }
        private Actions actions;

        private TimeSpan secondsToWait = TimeSpan.FromSeconds(10);

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetCurrentURL()
        {
            return driver.Url;
        }
        public string GetAttributeValue(IWebElement e, string attribute)
        {
              
            return e.GetAttribute(attribute);

        }

        public void WaitIntilCondition(Func<IWebDriver, object> condtionToWait, int sec)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while(stopwatch.Elapsed.TotalSeconds < sec)
            {
                 wait.Until(condtionToWait);
            }
        }

        public void SetLoggerInstance(Logger log)
        {
            logger = log;
        }
        public void Check(IWebElement element)
        {
            if (!element.Selected)
            {
                element.Click();
            }
        }

        public void ScrollToElement(IWebDriver driver, IWebElement elementToScroll)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", elementToScroll);
        }

        public  void Click(IWebElement el)
        {
            el.Click();
        }

        public void FillTheField(IWebElement fieldToFill, string dataToFillTheFieldWith)
        {
            wait = new WebDriverWait(driver, secondsToWait);
            if (fieldToFill.GetAttribute("value") != "")
                fieldToFill.Clear();
            fieldToFill.SendKeys(dataToFillTheFieldWith);
        }
        public void MouseHover(IWebDriver driver, IWebElement el)
        {
            actions = new Actions(driver);
            actions.MoveToElement(el).Build();
        }
        public IWebDriver GetDriver()
        {
            return driver;
        }
    }

}


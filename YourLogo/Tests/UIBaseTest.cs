using AventStack.ExtentReports.Model;
using YourLogo.Configurations;
using YourLogo.Framework;
using YourLogo.Framework.Browser;
using YourLogo.TestsInfo;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Tests
{
    public class UIBaseTest 
    {
        public IWebDriver driver;

        protected Logger logger;
        protected Reporter report;

        private TestConfigModel model;
        private Browser browser;

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            report = new Reporter();
            report.CreateReport();
            SetConfigData();
            browser = new Browser(model.Browser);
            driver = browser._driver;
            StandardOneTimeSetup();
            ExtendedOneTimeSetUp();

        }

        [SetUp]

        public virtual void SetUp()
        {
            StandardSetUp();
            ExtendedSetUp();

        }


        [TearDown]
        public void TearDown()
        {
            StandartTearDown();
            ExtendedTearDown();
        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            ExtendedOneTimeTearDown();
            StandardOneTimeTearDown(driver);

        }
        public void StandardSetUp()
        {
            
        }

        public virtual void ExtendedSetUp()
        {

        }
        public void StandardOneTimeSetup()
        {
            SetReporter()
            .SetLogger();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public virtual void ExtendedOneTimeSetUp()
        {
        }

        public void StandartTearDown()
        {
            report.GetTestName();
            logger.GetTestName();
            logger.AfterTest();
        }
        public virtual void ExtendedTearDown() { }

        public void StandardOneTimeTearDown(IWebDriver driver)
        {
            report.EndReport();
            EndTests(driver);
        }

        public virtual void ExtendedOneTimeTearDown() { }
        public void SetDriverInstance(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void EndTests(IWebDriver driver)
        {
            try
            {
                driver.Quit();
            }
            catch (System.Exception e)
            {
                logger.LogInfo(e.Message);
            }
        }

        private UIBaseTest SetReporter()
        {
            report = new Reporter();
            report.CreateReport();
            return this;
        }
        private UIBaseTest SetLogger()
        {
            logger = new Logger();
            logger.Initialize();
            return this;
        }
        private void SetConfigData()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory).Replace(@"\bin\Debug", @"\Configurations\TestConfig.json");
                path = path.Replace("TestConfig.json\\", "TestConfig.json");
                string data = File.ReadAllText(path);

                model = new TestConfigModel();
                model = DataHelper.DeserializeJson<TestConfigModel>(data);
            }catch (Exception e)
            {
                logger.LogInfo(e.Message);
                logger.LogInfo("Function: "+nameof(SetConfigData));
            }
        }
       
    }
}

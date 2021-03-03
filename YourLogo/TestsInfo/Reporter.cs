using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System.Configuration;

namespace YourLogo.TestsInfo
{
    public class Reporter
    {
        private ExtentReports extent;
        private ExtentHtmlReporter htmlReporter;
        private ExtentTest test;
        private readonly string path = ConfigurationManager.AppSettings["Guru99.Report.Path"];
        public void CreateReport()
        {
            extent = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent.AttachReporter(htmlReporter);
        }
        public void GetTestName()
        {
             test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test has been finished");
        }
        public void EndReport()
        {
            extent.Flush();
        }
    }
}

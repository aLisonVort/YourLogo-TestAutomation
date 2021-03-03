using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using NUnit.Framework;
using System.Configuration;

namespace YourLogo.TestsInfo
{
    public  class Logger
    {
        private  ILog logger { get; set; }
        private string testName = TestContext.CurrentContext.Test.Name;
        private readonly string logFilePath = ConfigurationManager.AppSettings["Guru99.Logger.LogFilePath"];
        public ILog SetUpLogger()
        {
            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = ConfigurationManager.AppSettings.Get("converionPattern");
            patternLayout.ActivateOptions();


            var fileAppender = new FileAppender()
            {
                Name = "fileAppender",
                Layout = patternLayout,
                Threshold = Level.All,
                AppendToFile = true,
                File = logFilePath,
            };
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);
            ILog _logger = LogManager.GetLogger(typeof(Logger));
            return _logger;
        }

        public void Initialize()
        {
            logger = SetUpLogger();
        }
        public void GetTestName()
        {
            logger.Info(TestContext.CurrentContext.Test.FullName);
        }
        public ILog GetLogger()
        {
            return logger;
        }
        public void AfterTest()
        {
            var getStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var status = getStatus.ToString();
            logger.Info(getStatus);

            var label = TestContext.CurrentContext.Result.Outcome.Label;
            logger.Info(TestContext.CurrentContext.Result.Outcome.Site);
            if (status == "Failed" && label == "empty")
                logger.Error($"Test assertion in  {testName} is failed");
            else if (status == "Failed" && label == "Error")
                logger.Error("Unexpected exception occurred");
            else if (status == "Passed")
                logger.Info($"{testName} result: passed");
            logger.Info(" Tear down is completed");
        }
        public void LogInfo(string message)
        {
            logger.Info(message);
        }
    }
}

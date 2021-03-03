using YourLogo.Pages;
using YourLogo.TestsInfo;
using OpenQA.Selenium;

namespace YourLogo.Interfaces
{
    public interface IPage
    {
        //IPage GetAttributeValue(IWebElement e, string attribute);
        //IPage FixFormat(string actual, string desired);
        //IPage ElementIsSelected(IWebElement e);
        //IPage True();
        void SetLoggerInstance(Logger logger);
    }
}

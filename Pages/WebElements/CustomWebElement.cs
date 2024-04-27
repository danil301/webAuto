using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Pages.WebElements
{
    public class CustomWebElement
    {
        protected IWebDriver _driver;
        protected WebDriverWait _driverWait;
        protected Actions _actions;

        public string _xPath;
        public IWebElement element;

        public CustomWebElement(string xPath, IWebDriver driver, WebDriverWait driverWait)
        {
            _driver = driver;
            _driverWait = driverWait;
            _actions = new Actions(driver);

            _xPath = xPath;
            element = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }

        public string GetTextFromField()
        {
            return element.GetAttribute("value");
        }
    }
}

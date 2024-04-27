using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Pages.WebElements
{
    public class Calendar
    {
        private WebDriverWait _driverWait;
        private string _xPath;

        private IWebElement _prev;
        private IWebElement _next;
        private IWebElement _yearButton;
        private IWebElement _element;

        public Calendar(string xPath, IWebDriver driver, WebDriverWait driverWait)
        {
            _xPath = xPath;
            _driverWait = driverWait;
            _yearButton = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//rui-icon[contains(@name, 'Calendar')]")));
        }

        private void OpenCalendar()
        {
            _yearButton.Click();
            _element = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath(_xPath)));
            _prev = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@aria-label, 'Previous 24 years')]")));
            _next = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@aria-label, 'Next 24 years')]")));
        }

        public void SetDate(string date)
        {
            OpenCalendar();

            DateTime parsedDate;
            if (!DateTime.TryParse(date, out parsedDate)) return;

            while (true)
            {
                var d = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@aria-label, 'Choose date')]"))).Text.Split(" – ");
                var low = int.Parse(d[0].Trim());
                var high = int.Parse(d[1].Trim());
                if (low <= parsedDate.Year && high >= parsedDate.Year) break;
                else
                {
                    if (low > parsedDate.Year) _prev.Click();
                    else _next.Click();
                }
            }

            _element.FindElement(By.XPath($"//div[contains(text(), '{parsedDate.Year}')]")).Click();
            var months = _element.FindElements(By.XPath("//td/div[string-length(text()) > 0]"));
            months[parsedDate.Month - 1].Click();
            var days = _element.FindElements(By.XPath("//td/div[string-length(text()) > 0]"));
            days[parsedDate.Day - 1].Click();
        }



    }
}

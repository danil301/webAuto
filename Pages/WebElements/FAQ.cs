using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages.WebElements
{
    public class FAQ : CustomWebElement
    {
        public string Question;

        private IWebElement _answerButton;

        public FAQ(string xPath, IWebDriver driver, WebDriverWait driverWait) : base(xPath, driver, driverWait)
        {
            Question = element.FindElement(By.XPath("./div[contains(@class, 'expansion-panel-title')]")).Text;
            _answerButton = element.FindElement(By.XPath("./div[contains(@class, 'expansion-panel-title')]/div[contains(@class, 'expansion-panel-title-arrow')]"));
        }

        /// <summary>
        /// Открывает и возвращает ответ.
        /// </summary>
        /// <returns>string</returns>
        public string ShowAnswer()
        {
            _answerButton.Click();
            return element.FindElement(By.XPath("./div[contains(@class, 'expansion-panel-body')]")).Text;
        }
    }
}

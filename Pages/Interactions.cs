using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pages.Helpers;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Interactions
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;

        public Interactions(IWebDriver driver, WebDriverWait driverWait)
        {
            _driver = driver;
            _driverWait = driverWait;
        }


        /// <summary>
        /// Нажимает на кнопку принятия куки, если есть сообщение.
        /// </summary>
        /// <returns>DebitCardYourCashBack</returns>
        public Interactions AcceptCookieIfExists()       
        {
            try
            {
                var cookieButton = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(), 'Хорошо')]")));
                _driverWait.Until(d =>
                {
                    cookieButton.Click();
                    return true;
                });
            }
            catch (Exception) { }

            return this;
        }      

        public Interactions FillCheckBox(bool check, IWebElement element, string xPath)
        {
            if (check && ! _driver.FindElement(By.XPath(xPath)).Selected)
            {
                element.Click();
            }
            else if (!check && _driver.FindElement(By.XPath(xPath)).Selected)
            {
                element.Click();
            }

            return this;
        }

        public Interactions FillActionFields(IWebElement element, string data)
        {
            element.Click();
            Actions actions = new Actions(_driver);
            actions.SendKeys(data).Perform();

            return this;
        }

        public Interactions FillTextFields(IWebElement element, string data)
        {
            element.SendKeys(data);
            return this;
        }

        public Interactions FillListBox(IWebElement element, string option)
        {
            element.Click();
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[text()='{option}']"))).Click();

            return this;
        }

        /// <summary>
        /// Нажимает на элемент
        /// </summary>
        public Interactions ClickElement(IWebElement element)
        {
            element.Click();
            return this;
        }

        


        //list
        public Interactions SetFieldByDropDownItems(IWebElement field, string input, string option)
        {
            field.SendKeys(input);

            var opt = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[contains(@text(), {option})]")));

            Actions actions = new Actions(_driver);
            actions.MoveToElement(opt).Click().Perform();
            //opt.Click();

            return this;
        }
    }
}

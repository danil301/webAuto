using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.WebElements
{
    public class ListBox : CustomWebElement
    {
        public List<IWebElement> Options { get => _driver.FindElements(By.XPath("//mat-option")).ToList(); }

        public ListBox(string xPath, IWebDriver driver, WebDriverWait driverWait) : base(xPath, driver, driverWait)
        {

        }


        /// <summary>
        /// Принимает опцию и выбирает её из списка по точному совпадению.
        /// </summary>
        /// <param name="option"></param>
        public void SelectOptionByName(string option)
        {
            Options.FirstOrDefault(x => x.Text.Trim() == option.Trim()).Click();
        }

        /// <summary>
        /// Принимает номер опции и выбирает её из списка доступных
        /// </summary>
        /// <param name="id"></param>
        public void SelectOptionById(int id)
        {
            Options[id].Click();
        }

        /// <summary>
        /// Метод для поля. Вводит значение в поле. Ожидает пока появятся опции.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>ListBox(этот же экземпляр)</returns>
        public ListBox SetField(string value)
        {
            element.SendKeys(value);
            _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//mat-option")));
            return this;
        }

        /// <summary>
        /// Метод для селекта. Открывает опции и ожидает пока они появятся. 
        /// </summary>
        /// <returns>ListBox(этот же экземпляр)</returns>
        public ListBox SetField()
        {
            element.Click();
            _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//mat-option")));
            return this;
        }
    }
}

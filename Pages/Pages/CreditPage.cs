using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.Helpers;
using Pages.WebElements;
using SeleniumExtras.WaitHelpers;

namespace Pages.Pages
{
    public class CreditPage : DebitCardYourCashBack
    {
        public CustomWebElement oficcialEmploymentInput;
        public CustomWebElement creditStoryCheckBox;

        public CreditPage(IWebDriver driver, WebDriverWait webDriverWait, bool cookie) : base(driver, webDriverWait, cookie)
        {
            FindScecialElements();
        }

        /// <summary>
        /// Находит поля, которые не инициализировала базовая страница.
        /// </summary>
        protected override void FindScecialElements()
        {
            oficcialEmploymentInput = new CustomWebElement("//mat-select[@name='RussianEmployment']", _driver, _driverWait);
            creditStoryCheckBox = new CustomWebElement("//a[@href='/res/i/td/ConsentBKI.pdf']/../../../span[@class='rui-checkbox__frame']", _driver, _driverWait);
        }


    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using Pages.Helpers;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Pages.Pages
{
    public class CheckDataPage
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;

        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Имя:')]/../b")]
        public IWebElement firstName;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Фамилия:')]/../b")]
        public IWebElement lastName;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Отчество:')]/../b")]
        public IWebElement middleName;        
        [FindsBy(How = How.XPath, Using = "//div[@class='confirm-section__birthdate']/b")]
        public IWebElement birthDate;
        [FindsBy(How = How.XPath, Using = "//div[@class='confirm-section__mobile-phone']/b")]
        public IWebElement phoneNumber;

        public CheckDataPage(IWebDriver driver, WebDriverWait webDriverWait)
        {
            _driver = driver;
            _driverWait = webDriverWait;
            PageFactory.InitElements(driver, this);
        }
    }
}

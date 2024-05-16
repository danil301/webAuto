using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject1;


namespace Pages.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _driverWait;
        protected Actions _actions;
        protected Interactions _interactions;

        public virtual void FillPage(Data data)
        {

        }

        public BasePage(IWebDriver driver, WebDriverWait driverWait, bool cookie)
        {
            _driver = driver;   
            _driverWait = driverWait;
            _actions = new Actions(driver);
            _interactions = new Interactions(driver, driverWait);

            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            if (cookie)
            {
                try
                {
                    var cookieButton = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(), 'Хорошо')]")));
                    driverWait.Until(d =>
                    {
                        cookieButton.Click();
                        return true;
                    });
                }
                catch (Exception) { }
            }
        }


    }
}

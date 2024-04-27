using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages.WebElements
{
    public class CheckBox : CustomWebElement
    {
        public string Title;

        public CheckBox(string xPath, IWebDriver driver, WebDriverWait driverWait) : base($"{xPath}/rui-checkbox", driver, driverWait)
        {
            Title = element.FindElement(By.XPath("..")).Text;
        }

        public void Check(bool check)
        {
            if (!CheckState() && check) element.Click();
            else if (CheckState() && !check) element.Click();
        }

        public bool CheckState() => element.FindElement(By.XPath("./label")).GetAttribute("class").Split().Contains("rui-checkbox_checked");
    }
}

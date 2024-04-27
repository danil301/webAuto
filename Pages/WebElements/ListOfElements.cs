using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages.WebElements
{
    public class ListOfElements<T>
    {
        public List<T> list;

        public ListOfElements(string xPath, IWebDriver driver, WebDriverWait driverWait)
        {
            list = new List<T>();

            for (int i = 1; i <= driver.FindElements(By.XPath(xPath)).Count; i++)
            {
                var path = $"({xPath})[{i}]";
                var element = Activator.CreateInstance(typeof(T), path, driver, driverWait);
                list.Add((T)element);
            }
        }
    }
}

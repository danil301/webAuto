using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Pages.WebElements
{
    public class Slider : CustomWebElement
    {
        private int _width { get => element.Size.Width; }
        private int _max { get => int.Parse(element.GetAttribute("max")); }
        private int _currentValue
        {
            get
            {
                int value;
                int.TryParse(element.GetAttribute("value"), out value);
                return value;
            }
        }
                           
        public Slider(string xPath, IWebDriver driver, WebDriverWait driverWait) : base(xPath, driver, driverWait)
        {

        }

        /// <summary>
        /// Ставит значение введенное значение слайдера слайдера
        /// </summary>
        /// <param name="target"></param>
        public void SetValue(int target)
        {
            var amountPerPixel = _max / _width;

            _actions.ClickAndHold(element).Release().Perform();           
            _actions.ClickAndHold(element).MoveByOffset((target - _currentValue) / amountPerPixel, 0).Release().Perform();
            if (_currentValue > target) _actions.SendKeys(string.Join("", Enumerable.Repeat(Keys.Left, _currentValue - target).ToArray())).Release().Perform();
            else if (_currentValue < target) _actions.SendKeys(string.Join("", Enumerable.Repeat(Keys.Right, target - _currentValue).ToArray())).Release().Perform();           
        }
    }
}

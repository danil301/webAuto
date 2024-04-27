using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.DOMSnapshot;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumInitialize_Builder
{
    public class SeleniumBuilder : IDisposable
    {
        private IWebDriver _webDriver { get; set; }

        private ChromeDriverService _driverService { get; set; }

        private ChromeOptions _chromeOptions { get; set; }

        public int Port { get; private set; }

        public bool IsDisposed { get; private set; }

        public List<string> ChangedArguments { get; private set; }

        public Dictionary<string, object> ChangedUserOptions { get; private set; }

        public TimeSpan Timeout { get; private set; }

        public string StartingURL { get; private set; }

        public SeleniumBuilder()
        {
            ChangedArguments = new List<string>();
            ChangedUserOptions = new Dictionary<string, object>();
            _chromeOptions = new ChromeOptions();
            _driverService = ChromeDriverService.CreateDefaultService();
        }

        public IWebDriver Build()
        {
            //Создать экземпляр драйвера, присвоить получившийся результат переменной WebDriver, вернуть в качестве результата данного метода.
            if (ChangedUserOptions.Count != 0 && ChangedArguments.Count != 0) _webDriver = new ChromeDriver(_driverService, _chromeOptions);
            else if (ChangedUserOptions.Count != 0 || ChangedArguments.Count != 0) _webDriver = new ChromeDriver(_chromeOptions);
            else _webDriver = new ChromeDriver();

            if (Timeout != TimeSpan.Zero) _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Timeout.Seconds);
            if (StartingURL != null) _webDriver.Navigate().GoToUrl(StartingURL);


            return _webDriver;
        }

        public void Dispose()
        {
            //Закрыть браузер, очистить использованные ресурсы, по завершении переключить IsDisposed на состояние true
            //WebDriver.Close();
            //WebDriver.Quit();
            _webDriver.Dispose();
            IsDisposed = true;
        }
        
        public SeleniumBuilder ChangePort(int port)
        {
            //Реализовать смену порта, на котором развёрнут IWebDriver для этого необходимо ознакомиться с классом DriverService соответствующего драйвера (ChromeDriverService для хрома)
            //Изменить свойство Port на тот порт, на который поменяли.
            //Builder в данном методе должен возвращать сам себя
            _driverService = ChromeDriverService.CreateDefaultService();
            _driverService.Port = port;
            Port = _driverService.Port;
                     
            return this;
        }

        public SeleniumBuilder SetArgument(string argument)
        {
            //Реализовать добавление аргумента. При решении данной задаче ознакомитесь с классом Options соответствующего драйвера (ChromeOptions для браузера Chrome)
            //Все изменённые/добавленные аргументы необходимо отразить в свойстве СhangedArguments, которое перед этим нужно где-то будет проинициализировать.
            //Builder в данном методе должен возвращать сам себя
        
            //todo
            ChangedArguments = new List<string>();
             _chromeOptions.AddArgument(argument);
             ChangedArguments.Add(argument);
                       
            return this;
        }

        public SeleniumBuilder SetUserOption(string option, object value) 
        {
            //Реализовать добавление пользовательской настройки.
            //Все изменения сохранить в свойстве ChangedUserOptions
            //Builder в данном методе должен возвращать сам себя



            if (ChangedUserOptions.ContainsKey(option))
            {
                if (ChangedUserOptions[option] == value) return this;
                else
                {
                    _chromeOptions = RemoveArgument(_chromeOptions, option);
                    _chromeOptions.AddUserProfilePreference(option, value);
                }
            }
            else
            {
                _chromeOptions.AddUserProfilePreference(option, value);
                ChangedUserOptions.Add(option, value);
            }

            return this;
        }
        
        public SeleniumBuilder WithTimeout(TimeSpan timeout)
        {
            //Реализовать изменение изначального таймаута запускаемого браузера
            //Отслеживать изменения в свойстве Timeout
            //Builder возвращает себя
            Timeout = timeout;
            return this;
        }

        public SeleniumBuilder WithURL(string url)
        {
            //Реализовать изменения изначального URL запускаемого браузера
            //Отслеживать изменения в строке StartingURL
            //Builder возвращает себя
            StartingURL = url;
            return this;
        }

        public bool IsBrowserHeadless()
        {
            if (_webDriver is ChromeDriver chromeDriver)
            {
                var browserName = chromeDriver.Capabilities.GetCapability("browserName").ToString();

                return browserName == "chrome-headless-shell";
            }
            return true;
        }


        public ChromeOptions RemoveArgument(ChromeOptions options, string argument)
        {
            ChromeOptions newOptions = new ChromeOptions();

            foreach (var arg in options.Arguments)
            {
                if (arg != argument)
                {
                    newOptions.AddArgument(arg);
                }
            }

            return newOptions;
        }

    }
}
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages;
using Pages.Pages;
using Pages.WebElements;
using SeleniumInitialize_Builder;
using System.Reflection;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class PageStepDefinitions
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;
        private Data _data;

        private Lazy<DebitCardYourCashBack> _debitCardYourCashBackLazy;
        private Lazy<CheckDataPage> _checkDataPageLazy;

        private DebitCardYourCashBack _debitCardYourCashBack => _debitCardYourCashBackLazy.Value;
        private CheckDataPage _checkDataPage => _checkDataPageLazy.Value;

        private Interactions _interactions;
        private ScenarioContext _scenarioContext;

        public PageStepDefinitions(ScenarioContext scenarioConttext)
        {
            _scenarioContext = scenarioConttext;
            SeleniumBuilder builder = new SeleniumBuilder();
            _driver = builder.Build();
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _interactions = new Interactions(_driver, _driverWait);
            _debitCardYourCashBackLazy = new Lazy<DebitCardYourCashBack>(() => new DebitCardYourCashBack(_driver, _driverWait, true));
            _checkDataPageLazy = new Lazy<CheckDataPage>(() => new CheckDataPage(_driver, _driverWait, true));
            _data = new Data();
        }

        private void SaveDataToContext(string fieldName, string fieldValue)
        {           
            typeof(Data).GetField(fieldName.Replace("Input", "")).SetValue(_data, fieldValue);
            _scenarioContext["data"] = _data;
        }

        [Given(@"Переходим на страницу по адрессу ""([^""]*)""")]
        public void GoToPageWithUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, _driver.Url, "Неверный url");
        }

        private BasePage GetPage(string pageName)
        {
            Type type = Type.GetType($"Pages.Pages.{pageName}, Pages");
            FieldInfo classInfo = typeof(PageStepDefinitions).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name.ToLower().Contains(pageName.ToLower()));

            var lazyPageInstance = classInfo.GetValue(this) as dynamic;
            return lazyPageInstance.Value;
        }

        private CustomWebElement GetField(BasePage page, string fieldName)
        {
            FieldInfo fieldInfo = page.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            return (CustomWebElement)fieldInfo.GetValue(page);
        }

        [Then(@"Заполнить поле ""([^""]*)"" страницы ""([^""]*)"" текстом ""([^""]*)""")]
        public void FillTextField(string fieldName, string pageName, string text)
        {
            var pageInstance = GetPage(pageName);
            var field = GetField(pageInstance, fieldName);

            _interactions.FillActionFields(field.element, text);
            if (fieldName != "phoneNumberInput") SaveDataToContext(fieldName, text);
            else
            {
                SaveDataToContext(fieldName, $"+7 ({text.Substring(0, 3)}) " +
                    $"{text.Substring(3, 3)}-{text.Substring(6, 2)}-{text.Substring(8, 2)}");
            }           
        }

        [Then(@"Нажать на ""([^""]*)"" на странице ""([^""]*)""")]
        public void ClickElement(string elementName, string pageName)
        {
            var pageInstance = GetPage(pageName);
            var element = GetField(pageInstance, elementName);

            _interactions.ClickElement(element.element);
        }

        [Then(@"Поставить листбокс ""([^""]*)"" на странице ""([^""]*)"" в положение ""([^""]*)""")]
        public void FillListBox(string listBoxName, string pageName, string state)
        {
            var pageInstance = GetPage(pageName);
            var listBox = GetField(pageInstance, listBoxName);

            _interactions.FillListBox(listBox.element, state);
        }

        [Then(@"Поставить чекбокс ""([^""]*)"" на страницке ""([^""]*)"" в положение ""([^""]*)""")]
        public void SetCheckBox(string checkBoxName, string pageName, bool state)
        {
            var pageInstance = GetPage(pageName);
            var checkBox = GetField(pageInstance, checkBoxName);

            _interactions.FillCheckBox(state, checkBox.element, checkBox._xPath);
        }

        [Given(@"Текст поля ""([^""]*)"" верный")]
        public void CheckFieldText(string fieldName)
        {
            FieldInfo fieldInfo = typeof(CheckDataPage).GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            IWebElement field = (IWebElement)fieldInfo.GetValue(_checkDataPage);
            var data = _scenarioContext["data"];
            Assert.AreEqual(data.GetType().GetField(fieldName).GetValue(data), field.Text, "Неверный текст");
        }

        [Then(@"Заполнить поля страницы ""([^""]*)"" параметрами:")]
        public void FillAllFields(string pageName, Table table)
        {
            var fields = table.CreateInstance<Data>();

            _debitCardYourCashBack.FillPage(fields);

            fields.phoneNumber = $"+7 ({fields.phoneNumber.Substring(0, 3)}) " +
                    $"{fields.phoneNumber.Substring(3, 3)}-{fields.phoneNumber.Substring(6, 2)}-{fields.phoneNumber.Substring(8, 2)}";
            _scenarioContext["data"] = fields;
        }

        [Then(@"Вызвать метод ""([^""]*)"" у страницы ""([^""]*)"" с параметрами:")]
        public void ExecutePageMethod(string methodName, string pageName, Table table)
        {
            var page = GetPage(pageName);

            var types = new List<Type>();
            var values = new List<object>();

            foreach (var row in table.Rows)
            {
                Type type = Type.GetType($"System.{row[0]}");
                types.Add(type);

                values.Add(Convert.ChangeType(row[1], type));
            }
            page.GetType().GetMethod(methodName, types.ToArray()).Invoke(page, values.ToArray());                  
        }

        [Then(@"Заполнить страницу ""([^""]*)"" данными из файла ""([^""]*)""")]
        public void FillPageFromJson(string pageName, string jsonPath)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..");
            string[] files = Directory.GetFiles(path, "data.json", SearchOption.AllDirectories);

            Data data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(files[0]));      

            GetPage(pageName).FillPage(data);
            data.phoneNumber = $"+7 ({data.phoneNumber.Substring(0, 3)}) " +
                    $"{data.phoneNumber.Substring(3, 3)}-{data.phoneNumber.Substring(6, 2)}-{data.phoneNumber.Substring(8, 2)}";
            _scenarioContext["data"] = data;
        }


        [AfterScenario]
        public void Dispose()
        {
            _driver.Dispose();
        }

    }
}

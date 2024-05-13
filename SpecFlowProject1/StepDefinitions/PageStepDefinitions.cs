using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages;
using Pages.Helpers;
using Pages.Pages;
using Pages.WebElements;
using SeleniumInitialize_Builder;
using System;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class PageStepDefinitions
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;

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
        }

        [Given(@"Переходим на страницу по адрессу ""([^""]*)""")]
        public void GoToPageWithUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, _driver.Url, "Неверный url");
        }

        private object GetPage(string pageName)
        {
            Type type = Type.GetType($"Pages.Pages.{pageName}, Pages");
            FieldInfo classInfo = typeof(PageStepDefinitions).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name.ToLower().Contains(pageName.ToLower()));

            var lazyPageInstance = classInfo.GetValue(this) as dynamic;
            return lazyPageInstance.Value;
        }

        private CustomWebElement GetField(object page, string fieldName)
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
            if (fieldName != "phoneNumberInput") _scenarioContext[fieldName.Replace("Input", "")] = text;
            else
            {
                _scenarioContext[fieldName.Replace("Input", "")] = $"+7 ({text.Substring(0, 3)}) " +
                    $"{text.Substring(3, 3)}-{text.Substring(6, 2)}-{text.Substring(8, 2)}";
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
            Assert.AreEqual(_scenarioContext[fieldName], field.Text, "Неверный текст");
        }

        [Then(@"Заполнить поля страницы:")]
        public void FillAllFields(Table table)
        {
            var fields = table.CreateInstance<Data>();

            _debitCardYourCashBack.FillPage(fields, _interactions);

            fields.phoneNumber = $"+7 ({fields.phoneNumber.Substring(0, 3)}) " +
                    $"{fields.phoneNumber.Substring(3, 3)}-{fields.phoneNumber.Substring(6, 2)}-{fields.phoneNumber.Substring(8, 2)}";
            _scenarioContext["firstName"] = fields.firstName;
            _scenarioContext["lastName"] = fields.lastName;
            _scenarioContext["middleName"] = fields.middleName;
            _scenarioContext["birthDate"] = fields.birthDate;
            _scenarioContext["phoneNumber"] = fields.phoneNumber;
        }


        [AfterScenario]
        public void Dispose()
        {
            _driver.Dispose();
        }

    }
}

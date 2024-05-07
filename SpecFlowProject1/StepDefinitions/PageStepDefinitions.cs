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

        [Then(@"Заполнить поле ""([^""]*)"" страницы ""([^""]*)"" текстом ""([^""]*)""")]
        public void FillTextField(string fieldName, string page, string text)
        {
            Type type = Type.GetType($"Pages.Pages.{page}, Pages");
            FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);

            FieldInfo classInfo = typeof(PageStepDefinitions).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name.ToLower().Contains(page.ToLower()));

            var lazyPageInstance = classInfo.GetValue(this) as dynamic;
            var pageInstance = lazyPageInstance.Value;

            CustomWebElement field = (CustomWebElement)fieldInfo.GetValue(pageInstance);

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
            Type type = Type.GetType($"Pages.Pages.{pageName}, Pages");
            FieldInfo fieldInfo = type.GetField(elementName, BindingFlags.Public | BindingFlags.Instance);

            FieldInfo classInfo = typeof(PageStepDefinitions).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name.ToLower().Contains(pageName.ToLower()));

            var lazyPageInstance = classInfo.GetValue(this) as dynamic;
            var pageInstance = lazyPageInstance.Value;

            CustomWebElement element = (CustomWebElement)fieldInfo.GetValue(pageInstance);

            _interactions.ClickElement(element.element);
        }

        [Then(@"Поставить листбокс ""([^""]*)"" на странице ""([^""]*)"" в положение ""([^""]*)""")]
        public void FillListBox(string listBoxName, string pageName, string state)
        {
            Type type = Type.GetType($"Pages.Pages.{pageName}, Pages");
            FieldInfo fieldInfo = type.GetField(listBoxName, BindingFlags.Public | BindingFlags.Instance);

            FieldInfo classInfo = typeof(PageStepDefinitions).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name.ToLower().Contains(pageName.ToLower()));

            var lazyPageInstance = classInfo.GetValue(this) as dynamic;
            var pageInstance = lazyPageInstance.Value;

            CustomWebElement element = (CustomWebElement)fieldInfo.GetValue(pageInstance);

            _interactions.FillListBox(element.element, state);
        }

        [Then(@"Поставить чекбокс ""([^""]*)"" на страницке ""([^""]*)"" в положение ""([^""]*)""")]
        public void SetCheckBox(string checkBoxName, string pageName, bool state)
        {
            Type type = Type.GetType($"Pages.Pages.{pageName}, Pages");
            FieldInfo fieldInfo = type.GetField(checkBoxName, BindingFlags.Public | BindingFlags.Instance);

            FieldInfo classInfo = typeof(PageStepDefinitions).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name.ToLower().Contains(pageName.ToLower()));

            var lazyPageInstance = classInfo.GetValue(this) as dynamic;
            var pageInstance = lazyPageInstance.Value;

            CustomWebElement element = (CustomWebElement)fieldInfo.GetValue(pageInstance);

            _interactions.FillCheckBox(state, element.element, element._xPath);
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
           
            _interactions.FillActionFields(_debitCardYourCashBack.firstNameInput.element, fields.firstName);
            _interactions.FillActionFields(_debitCardYourCashBack.lastNameInput.element, fields.lastName);
            _interactions.FillActionFields(_debitCardYourCashBack.middleNameInput.element, fields.middleName);
            _interactions.FillActionFields(_debitCardYourCashBack.birthDateInput.element, fields.birthDate);
            _interactions.FillActionFields(_debitCardYourCashBack.phoneNumberInput.element, fields.phoneNumber);
            _interactions.FillListBox(_debitCardYourCashBack.citizenShipInput.element, fields.citizenShip);
            _interactions.FillCheckBox(true, _debitCardYourCashBack.promotionCheckBox.element, _debitCardYourCashBack.promotionCheckBox._xPath);
            _interactions.FillCheckBox(true, _debitCardYourCashBack.personalDataCheckBox.element, _debitCardYourCashBack.personalDataCheckBox._xPath);
            _interactions.ClickElement(_debitCardYourCashBack.femaleRadioButton.element);
            _interactions.ClickElement(_debitCardYourCashBack.continueButton.element);

            fields.phoneNumber = $"+7 ({fields.phoneNumber.Substring(0, 3)}) " +
                    $"{fields.phoneNumber.Substring(3, 3)}-{fields.phoneNumber.Substring(6, 2)}-{fields.phoneNumber.Substring(8, 2)}";
            _scenarioContext["data"] = fields;
        }

        [Then(@"Проверить поля страницы")]
        public void CheckAllFields()
        {
            Data data = (Data)_scenarioContext["data"];
            Assert.Multiple(() =>
            {
                Assert.AreEqual(data.firstName, _checkDataPage.firstName.Text);
                Assert.AreEqual(data.lastName, _checkDataPage.lastName.Text);
                Assert.AreEqual(data.middleName, _checkDataPage.middleName.Text);
                Assert.AreEqual(data.phoneNumber, _checkDataPage.phoneNumber.Text);
                Assert.AreEqual(data.birthDate, _checkDataPage.birthDate.Text);
            });
        }


        [AfterScenario]
        public void Dispose()
        {
            _driver.Dispose();
        }

    }
}

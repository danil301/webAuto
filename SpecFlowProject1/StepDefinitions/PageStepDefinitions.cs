using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages;
using Pages.Pages;
using Pages.WebElements;
using SeleniumInitialize_Builder;
using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class PageStepDefinitions
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;
        private DebitCardYourCashBack _debitCardYourCashBack;
        private Interactions _interactions;
        private CheckDataPage _checkDataPage;
        private ScenarioContext _scenarioContext;

        public PageStepDefinitions(ScenarioContext scenarioConttext)
        {
            _scenarioContext = scenarioConttext;
            SeleniumBuilder builder = new SeleniumBuilder();
            _driver = builder.Build();
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _interactions = new Interactions(_driver, _driverWait);
        }

        [Given(@"Переходим на страницу по адрессу ""([^""]*)""")]
        public void GoToPageWithUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual(url, _driver.Url, "Неверный url");
        }

        //страница в параметр и потом рефл
        [Then(@"Заполнить поле ""([^""]*)"" текстом ""([^""]*)""")]
        public void FillTextField(string fieldName, string text)
        {
            FieldInfo fieldInfo = typeof(DebitCardYourCashBack).GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            CustomWebElement field = (CustomWebElement)fieldInfo.GetValue(_debitCardYourCashBack);
            _interactions.FillActionFields(field.element, text);
            _scenarioContext[fieldName.Replace("Input", "")] = text;
        }

        [Then(@"Выбрать пол ""([^""]*)""")]
        public void FillSex(string sex)
        {
            if (sex == "мужской") _interactions.ClickElement(_debitCardYourCashBack.maleRadioButton.element);
            else if (sex == "женский") _interactions.ClickElement(_debitCardYourCashBack.femaleRadioButton.element);
        }

        [Then(@"Выбрать гражданство ""([^""]*)""")]
        public void FillCitizenship(string input)
        {
            _interactions.FillListBox(_debitCardYourCashBack.citizenShipInput.element, input);
        }

        [Then(@"Поставить чекбокс ""([^""]*)"" в положение ""([^""]*)""")]
        public void SetCheckBox(string checkBox, string state)
        {
            FieldInfo fieldInfo = typeof(DebitCardYourCashBack).GetField(checkBox, BindingFlags.Public | BindingFlags.Instance);
            CustomWebElement field = (CustomWebElement)fieldInfo.GetValue(_debitCardYourCashBack);
            _interactions.FillCheckBox(state == "Включён", field.element, field._xPath);
        }

        //кнопка продолжить для всех страниц
        [Then(@"Нажать кнопку продолжить")]
        public void ClickContinueButton()
        {
            _interactions.ClickElement(_debitCardYourCashBack.continueButton.element);
        }

        [Given(@"Открылась страница ""([^""]*)""")]
        public void InitPage(string classTypeName)
        {
            string exePath = Assembly.GetExecutingAssembly().Location;
            string exeDirectory = Path.GetDirectoryName(exePath);
            string solutionDirectory = Path.Combine(exeDirectory, "..", "..", "..", "..", "Pages", "bin", "Debug", "net6.0", "Pages.dll");
            string fullPathToSolution = Path.GetFullPath(solutionDirectory);
            Assembly assembly = Assembly.LoadFrom(fullPathToSolution);

            Type type = assembly.GetType($"Pages.Pages.{classTypeName}");
            object instance = Activator.CreateInstance(type, _driver, _driverWait, true);

            FieldInfo fieldInfo = typeof(PageStepDefinitions)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(x => x.FieldType == type);
            fieldInfo.SetValue(this, instance);
        }

        [Given(@"Текст поля ""([^""]*)"" равен ""([^""]*)""")]
        public void CheckText(string fieldName, string text)
        {
            FieldInfo fieldInfo = typeof(CheckDataPage).GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            IWebElement field = (IWebElement)fieldInfo.GetValue(_checkDataPage);
            Assert.AreEqual(text, field.Text, "Неверный текст");
        }

        [Given(@"Текст поля ""([^""]*)"" верный")]
        public void CheckFieldText(string fieldName)
        {
            FieldInfo fieldInfo = typeof(CheckDataPage).GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            IWebElement field = (IWebElement)fieldInfo.GetValue(_checkDataPage);
            var a = _scenarioContext[fieldName];
            Assert.AreEqual(_scenarioContext[fieldName], field.Text, "Неверный текст");
        }


        [AfterScenario]
        public void Dispose()
        {
            _driver.Dispose();
        }

    }
}

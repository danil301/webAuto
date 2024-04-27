using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages;
using Pages.Pages;
using SeleniumInitialize_Builder;
using System;
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

        public PageStepDefinitions()
        {
            SeleniumBuilder builder = new SeleniumBuilder();
            _driver = builder.Build();
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));            
        }

        [Given(@"Переходим на страницу по адрессу ""([^""]*)""")]
        public void GoToPageWithUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _debitCardYourCashBack = new DebitCardYourCashBack(_driver, _driverWait, true);
            _interactions = new Interactions(_driver, _driverWait);
        }

        [Then(@"Проверяем адресс ""([^""]*)""")]
        public void CheckUrl(string url)
        {
            Assert.AreEqual(url, _driver.Url, "Неправильный url");
        }

        [Then(@"Заполнить поле Фамилия ""([^""]*)""")]
        public void FillLastName(string input)
        {
            _interactions.FillTextFields(_debitCardYourCashBack.lastNameInput.element, input);
        }

        [Then(@"Заполнить поле Имя ""([^""]*)""")]
        public void FillFirstName(string input)
        {
            _interactions.FillTextFields(_debitCardYourCashBack.firstNameInput.element, input);
        }

        [Then(@"Заполнить поле Отчество ""([^""]*)""")]
        public void FillMiddleName(string input)
        {
            _interactions.FillTextFields(_debitCardYourCashBack.middleNameInput.element, input);
        }

        [Then(@"Выбрать пол ""([^""]*)""")]
        public void FillSex(string sex)
        {
            if (sex == "мужской") _interactions.ClickElement(_debitCardYourCashBack.maleRadioButton.element);
            else if (sex == "женский") _interactions.ClickElement(_debitCardYourCashBack.femaleRadioButton.element);

        }

        [Then(@"Заполнить дату рождения ""([^""]*)""")]
        public void FillBirthDate(string date)
        {
            _interactions.FillActionFields(_debitCardYourCashBack.birthDateInput.element, date);
        }

        [Then(@"Ввести номер мобильного телефона ""([^""]*)""")]
        public void FillPhoneNumber(string input)
        {
            _interactions.FillActionFields(_debitCardYourCashBack.phoneNumberInput.element, input);
        }

        [Then(@"Выбрать гражданство ""([^""]*)""")]
        public void FillCitizenship(string input)
        {
            _interactions.FillListBox(_debitCardYourCashBack.citizenShipInput.element, input);
        }

        [Then(@"Выбрать чекбокс на согласие обработки данных")]
        public void ClickPersonalDataCheckBox()
        {
            _interactions.ClickElement(_debitCardYourCashBack.personalDataCheckBox.element);
        }

        [Then(@"Выбрать чекбокс рассылки")]
        public void ClickPromotionCheckBox()
        {
            _interactions.ClickElement(_debitCardYourCashBack.promotionCheckBox.element);
        }

        [Then(@"Нажать кнопку продолжить")]
        public void ClickContinueButton()
        {
            _interactions.ClickElement(_debitCardYourCashBack.continueButton.element);
        }

        [Given(@"Открылась страница подтверждения данных с url ""([^""]*)""")]
        public void InitCheckDataPage(string p0)
        {
            _checkDataPage = new CheckDataPage(_driver, _driverWait);
        }

        [Given(@"Поле фамилии равно ""([^""]*)""")]
        public void CheckLastName(string text)
        {
            Assert.AreEqual(text, _checkDataPage.lastName.Text, "Поле фамилии не совпадает");
        }

        [Given(@"Поле имени равно ""([^""]*)""")]
        public void CheckFirstName(string text)
        {
            Assert.AreEqual(text, _checkDataPage.firstName.Text, "Поле имени не совпадает");
        }

        [Given(@"Поле отчества равно ""([^""]*)""")]
        public void CheckMiddleName(string text)
        {
            Assert.AreEqual(text, _checkDataPage.middleName.Text, "Поле отчества не совпадает");
        }

        [Given(@"Поле даты рождения равно ""([^""]*)""")]
        public void CheckBirthDate(string text)
        {
            Assert.AreEqual(text, _checkDataPage.birthDate.Text, "Поле даты рождения не совпадает");
        }

        [Given(@"Поле номера телефона равно ""([^""]*)""")]
        public void CheckPhoneNumber(string text)
        {
            Assert.AreEqual(text, _checkDataPage.phoneNumber.Text, "Поле номера телефона не совпадает");
        }
    }
}

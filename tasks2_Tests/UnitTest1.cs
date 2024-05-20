using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pages;
using Pages.Helpers;
using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Builder;
using System.Text.RegularExpressions;
using Pages.Pages;
using Newtonsoft.Json;
using SpecFlowProject1;
using System.Text.Json;

namespace tasks2_Tests
{
    public class Tests
    {
        private SeleniumBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _builder = new SeleniumBuilder();
        }

        [TearDown]
        public void Teardown()
        {
            _builder.Dispose();
        }

        [Test(Description = "Проверка наличия Выпадающего списка 'Объект ипотеки'")]
        public void HasDropDownList()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(10)).Build();
            var element = driver.FindElement(By.XPath("//label[contains(text(), 'Объект ипотеки')]"));
                
            Assert.NotNull(element, "Элемент не найден на странице.");
        }

        [Test(Description = "Проверка наличия Кнопки 'Заполнить через госуслуги'")]
        public void HasFillThroughGosusligiButton()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));

            Assert.NotNull(element, "Элемент не найден на странице.");
        }

        [Test(Description = "Проверка наличия Карточки с брендом 'Семейная ипотека'")]
        public void HasFamilyMortgageCard()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var familyCard = driver.FindElement(By.XPath("//div[contains(@class, 'brands-cards__header') and (text()='Семейная ипотека — 6%')]"));
            
            Assert.NotNull(familyCard, "Элемент не найден на странице.");
        }

        [Test(Description = "Проверка наличия Свитчера 'Страхование жизни'")]
        public void HasLifeInsuranceSwitcher()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var lifeSwitcher = driver.FindElement(By.XPath("//psb-text[contains(text(), 'Страхование жизни')]"));           

            Assert.NotNull(lifeSwitcher, "Элемент не найден на странице.");            
        }

        [Test(Description = "Проверка наличия Поля 'Срок кредита'")]
        public void HasLoanTermField()
        {     
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//rui-range-slider[@id='loanPeriod']"));

            Assert.NotNull(element, "Элемент не найден на странице.");
        }

        [Test(Description = "Проверка состояние активности Выпадающего списка 'Объект ипотеки'")]
        public void IsDropDownListEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']"));

            Assert.IsTrue(element.Enabled, "Выпадающий список 'Объект ипотеки' не активен");
        }

        [Test(Description = "Проверка отображения Выпадающего списка 'Объект ипотеки'")]
        public void IsDropDownListDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']"));

            Assert.IsTrue(element.Displayed, "Выпадающий список 'Объект ипотеки' не отображается");
        }

        [Test(Description = "Проверка состояние активности Кнопки 'Заполнить через госуслуги'")]
        public void IsFillThroughGosusligiButtonEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));

            Assert.IsTrue(element.Enabled, "Кнопка 'Заполнить через госуслуги' не активна");
        }

        [Test(Description = "Проверка отображения Кнопки 'Заполнить через госуслуги'")]
        public void IsFillThroughGosusligiButtonDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));

            Assert.IsTrue(element.Displayed, "Кнопка 'Заполнить через госуслуги' не отображается");
        }

        [Test(Description = "Проверка состояние активности Карточки с брендом 'Семейная ипотека'")]
        public void IsFamilyMortgageCardEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//div[@class='brands-cards__item ng-star-inserted']"));

            Assert.IsTrue(element.Enabled, "Карточка с брендом 'Семейная ипотека' не активна");
        }

        [Test(Description = "Проверка отображения Карточки с брендом 'Семейная ипотека'")]
        public void IsFamilyMortgageCardDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//div[@class='brands-cards__item ng-star-inserted']"));

            Assert.IsTrue(element.Displayed, "Карточка с брендом 'Семейная ипотека' не отображается");
        }

        [Test(Description = "Проверка состояние активности Свитчера 'Страхование жизни'")]
        public void IsLifeInsuranceSwitcherEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//psb-switcher[@class = 'deltas__switcher _checked ng-untouched ng-pristine ng-valid']"));

            Assert.IsTrue(element.Enabled, "Свитчер 'Страхование жизни' не активен");
        }

        [Test(Description = "Проверка отображения Свитчера 'Страхование жизни'")]
        public void IsLifeInsuranceSwitcherDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//psb-switcher[@class = 'deltas__switcher _checked ng-untouched ng-pristine ng-valid']"));

            Assert.IsTrue(element.Displayed, "Свитчер 'Страхование жизни' не отображается");
        }

        [Test(Description = "Проверка состояние активности поля 'Срок кредита'")]
        public void IsLoanTermFieldEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//label[contains(text(), 'Срок кредита')]"));

            Assert.IsTrue(element.Enabled, "Поле 'Срок кредита' не активно");
        }

        [Test(Description = "Проверка состояние активности поля 'Срок кредита'")]
        public void IsLoanTermFieldDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//label[contains(text(), 'Срок кредита')]"));

            Assert.IsTrue(element.Displayed, "Поле 'Срок кредита' не отображается");
        }


        [Test(Description = "Проверка значения 'Квартира в строящемся домe' у Выпадающего списка 'Объект ипотеки'")]
        public void DropDownListHasRightValue()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var elementValue = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']//span")).Text;

            Assert.AreEqual(elementValue, "Квартира в строящемся доме", "Значение не 'Квартира в строящемся доме'");          
        }

        [Test(Description = "Проверка изначального значения '30' поля 'Срок кредита'")]
        public void LoanTermFieldHasRightValue()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var elementValue = driver.FindElement(By.XPath("//rui-range-slider[@id='loanPeriod']//input")).GetAttribute("value").ToString();

            Assert.AreEqual(elementValue, "30", "Изначальное значение не '30'");
        }

        [Test(Description = "Проверка активности свитчера 'Страхование жизни'")]
        public void CheckLifeInsuranceSwitcherState()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var elementState = driver.FindElement(By.XPath("//input[@name='switcher-2']")).Selected;

            Assert.True(elementState, "Свитчера 'Страхование жизни' не выбран");
        }

        [Test(Description = "Проверка активности свитчера Карточки 'Семейная ипотека'. Должна быть не выбрана.")]
        public void CheckFamilyMortgageCardState()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var familyCard = driver.FindElement(By.XPath("//div[text()='Семейная ипотека — 6%']"));
            bool isActive = familyCard.GetAttribute("class").Contains("_active");

            Assert.False(isActive, "Карточка 'Семейная ипотека' выбрана");
        }

        [Test(Description = "Проверка стилей Кнопки 'Заполнить через госуслуги'")]
        public void CheckStylesFillThroughGosusligiButton()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20))
                .SetArgument("--headless").Build();

            var element = driver.FindElement(By.XPath("//rui-wrapper[@data-appearance='primary']"));
            var buttonElement = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));
            var clickable = buttonElement.Enabled && buttonElement.Displayed ? true : false;           

            var color = element.GetCssValue("background-color");
            var height = buttonElement.GetCssValue("height");

            Assert.True(clickable);
            Assert.AreEqual(color, "rgba(242, 97, 38, 1)", "Цвет Кнопки 'Заполнить через госуслуги' не верный");
            Assert.AreEqual(height, "48px", "Высота Кнопки 'Заполнить через госуслуги' неверная");
        }

        [Test(Description = "Проверка видимости сообщения об ошибке при нажатии Кнопки 'Заполнить через госуслуги' с незаполненными полями")]
        public void CheckErronMessageWhenClickFillWithoutGosusligiButtonWithEmptyFields()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/military-family-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));

            var button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') and @data-appearance = 'secondary']")));         

            driverWait.Until(d =>
            {
                button.Click();
                return true;
            });
                                  
            var errorMessage = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'mortgage-calculator-output__alert_show')]")));

            Assert.AreEqual(errorMessage.Text, "Оформление заявки станет доступным после заполнения обязательных полей", "Ошибка отображается неверно на Кнопке 'Заполнить через госуслуги' с незаполненными полями");
        }

        [Test(Description = "Проверка наличия Кнопки 'Заполнить без госуслуг'")]
        public void DoesNotHaveFillWithoutGosusligiButtonWhenErrorMessage()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/military-family-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));

            var button = driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') " +
                "and @data-appearance = 'secondary']")));

            bool IsButtonVisible;
            bool IsButtonAppeared;
            bool IsErrorGone;

            driverWait.Until(d =>
            {
                button.Click();
                return true;
            });


            try
            {
                button = driver.FindElement(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') " +
                "and @data-appearance = 'secondary' and contains(@class, '_hovered')]"));
                IsButtonVisible = true;
            }
            catch (Exception)
            {
                IsButtonVisible = false;
            }

            try
            {
                button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') " +
                "and @data-appearance = 'secondary']")));
                IsButtonAppeared = true;
            }
            catch (Exception)
            {
                IsButtonAppeared = false;
            }
            
            try
            {
                var errorMessage = driverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[contains(@class, 'mortgage-calculator-output__alert_show')]")));
                IsErrorGone = true;
            }
            catch (Exception)
            {
                IsErrorGone = false;
            }

            Assert.Multiple(() =>
            {
                Assert.True(IsButtonAppeared, "Кнопка 'Заполнить без госуслуг' не появилась");
                Assert.True(IsErrorGone, "Сообщение об ошибке не ушло");
                Assert.False(IsButtonVisible, "Кнопка 'Заполнить без госуслуг' видна");
                Assert.NotNull(button, "Кнопки 'Заполнить без госуслуг' не существует");
            });
            
        }


        //todo
        [Test(Description = "Проверка работы свитчеров")]
        public void SwitchersCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/classic-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException));

            TurnOffSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='switcher-2']"))));  
            TurnOffSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='switcher-3']"))));  
            TurnOffSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='switcher-4']"))));  
            TurnOffSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='switcher-5']"))));

            var switchers = (driver.FindElements(By.XPath("//span[contains(@class, 'psb-status')]")));

            bool IsAllSwitchersMain = true;
            foreach (var item in switchers)
            {
                if (item.GetAttribute("class").Split().Contains("psb-status_main")) continue;
                IsAllSwitchersMain = false;
            }

            bool IsAllSwitchersSuccess = true;
            for (int i = 2; i < 6; i++)
            {
                TurnOnSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//input[@name='switcher-{i}']"))));
                if(CheckSpanStatus(driver, "psb-status_success", i - 2)) continue;
                IsAllSwitchersSuccess = false;
            }

            Assert.True(IsAllSwitchersMain, "Не все свитчеры в состоянии 'main'");
            Assert.True(IsAllSwitchersSuccess, "Не все свитчеры в состоянии 'success'");
        }

        private void TurnOffSwitcher(WebDriverWait driverWait, IWebElement switcher)
        {
            if (switcher.Selected)
            {
                driverWait.Until(d =>
                {
                    switcher.FindElement(By.XPath("./..//span")).Click();
                    return true;
                });
            }
        }

        private void TurnOnSwitcher(WebDriverWait driverWait, IWebElement switcher)
        {
            if (!switcher.Selected)
            {
                driverWait.Until(d =>
                {
                    switcher.FindElement(By.XPath("./..//span")).Click();
                    return true;
                });
            }
        }
 
        private bool CheckSpanStatus(IWebDriver driver, string className, int num)
        {
            var switchers = (driver.FindElements(By.XPath("//span[contains(@class, 'psb-status')]")));
            var span = switchers[num];
            if (span.GetAttribute("class").Split().Contains(className)) return true;
            return false;
        }



        [Test(Description = "Проверка страницы с формой заполнения ипотеки без госуслуг")]
        public void FillWithoutGosusligiFormCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/classic-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException), typeof(StaleElementReferenceException));

            

            var button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') " +
                "and @data-appearance = 'secondary']")));
            button.Click();

            Interactions interactions = new Interactions(driver, driverWait);
            interactions.AcceptCookieIfExists();

            var lastNameInput = driver.FindElement(By.XPath("//input[@name='CardHolderLastName']"));
            var firstNameInput = driver.FindElement(By.XPath("//input[@name='CardHolderFirstName']"));
            var middleNameInput = driver.FindElement(By.XPath("//input[@name='CardHolderMiddleName']"));
            var maleRadioButton = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='formly_19_radio_Sex_0']/../.")));
            var birthDate = driver.FindElement(By.XPath("//input[@data-mat-calendar='mat-datepicker-1']"));
            var phoneNumber = driver.FindElement(By.XPath("//input[@name='Phone']"));
            var emailInput = driver.FindElement(By.XPath("//input[@name='Email']"));
            var selectResidence = driver.FindElement(By.XPath("//mat-select[@name='RussianFederationResident']"));
            var officialEmployment = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-select[@name='RussianEmployment']")));
            var mortgageCentreAdress = driver.FindElement(By.Id("formly_28_select-with-double-item_OfficeId_0"));
            var personalDataCheckBox = driver.FindElement(By.XPath("//a[@href='/res/i/td/ConsentPDProcessing.pdf']/../../../span[@class='rui-checkbox__frame']"));
            var creditStoryCheckBox = driver.FindElement(By.XPath("//a[@href='/res/i/td/ConsentBKI.pdf']/../../../span[@class='rui-checkbox__frame']"));
            var promotionCheckBox = driver.FindElement(By.XPath("//a[@href='/res/i/td/ConsentPromotion.pdf']/../../../span[@class='rui-checkbox__frame']"));

            var notClickable = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@rtl-automark='REGISTRATION_NEXT']")))
                .GetAttribute("class").Contains("_disabled");
            Assert.True(notClickable, "Кнопка кликабельна при незаполненных полях");
            
            interactions.FillTextFields(lastNameInput, "абв").FillTextFields(firstNameInput, "абв").FillTextFields(middleNameInput, "абв")
                .ClickElement(maleRadioButton).FillActionFields(birthDate, "30122000").FillActionFields(phoneNumber, "9002221212")
                .FillTextFields(emailInput, "test@mail.ru").FillListBox(selectResidence, "РФ").FillListBox(officialEmployment, "Есть")
                .FillListBox(mortgageCentreAdress, "г. Москва, пл. Славянская, д. 2/5 ")
                .ClickElement(personalDataCheckBox).ClickElement(creditStoryCheckBox).ClickElement(promotionCheckBox);

            var clickable = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@rtl-automark='REGISTRATION_NEXT']")))
                .GetAttribute("class").Contains("_disabled") ? false : true;
            
            Assert.True(clickable, "Кнопка кликабельна при заполненных полях");
        }

        [Test(Description = "Проверка цвета для кнопки 'Заполнить через Госуслуги' в обычном и наведённом состоянии")]
        public void FillThroughGosusligiButtonColorsCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/classic-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException));

            var button = driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//rui-wrapper[@data-appearance='primary']")));

            var color = button.GetCssValue("background-color");

            Actions actions = new Actions(driver);
            actions.MoveToElement(button).Perform();

            var hoverButton = driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//rui-wrapper[@data-appearance='primary']")));
            var hoverColor = hoverButton.GetCssValue("background-color");

            Assert.AreEqual(color, "rgba(242, 97, 38, 1)", "Цвет кнопки в обычном состоянии не верный");
            Assert.AreEqual(hoverColor, "rgba(212, 73, 33, 1)", "Цвет кнопки в наведенном состоянии не верный");
        }

        [Test(Description = "Проверка изменения значения слайдера при его прокрутке")]
        public void SliderValueCheckWhenSlide()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/classic-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException));

            var slider = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//rui-range-slider[@data-testid='calc-input-amountPledge']")))
                .FindElement(By.TagName("rui-slider"));
            var inputField = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@forminput]")));

            var prevValue = inputField.GetAttribute("value");


            Actions actions = new Actions(driver);
            actions.MoveToElement(slider).Perform();           
            actions.ClickAndHold(slider).MoveByOffset(500, 0).Release().Perform();

        
            string updatedValue = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@forminput]"))).GetAttribute("value");
            Console.WriteLine("Updated value: " + updatedValue);

            Assert.AreNotEqual(prevValue, updatedValue, "Значение слайдера не изменилось");
        }

        [Test(Description = "Проверка страницы подтверждения данных у дебетки")]
        public void DebitDataCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait, true);
            var interactions = new Interactions(driver, driverWait);
            interactions.AcceptCookieIfExists()
                .FillCheckBox(true, debitCardYourCashBack.promotionCheckBox.element, debitCardYourCashBack.promotionCheckBox._xPath)
                .FillCheckBox(true, debitCardYourCashBack.personalDataCheckBox.element, debitCardYourCashBack.personalDataCheckBox._xPath)
                .FillTextFields(debitCardYourCashBack.firstNameInput.element, Fields.firstName)
                .FillTextFields(debitCardYourCashBack.lastNameInput.element, Fields.lastName)
                .FillTextFields(debitCardYourCashBack.middleNameInput.element, Fields.middleName)
                .FillActionFields(debitCardYourCashBack.birthDateInput.element, Fields.birthDate)
                .FillActionFields(debitCardYourCashBack.phoneNumberInput.element, Fields.phoneNumber)
                .FillListBox(debitCardYourCashBack.citizenShipInput.element, "РФ")
                .ClickElement(debitCardYourCashBack.maleRadioButton.element)
                .ClickElement(debitCardYourCashBack.continueButton.element);

            CheckDataPage checkDataPageDebit = new CheckDataPage(driver, driverWait, true);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(checkDataPageDebit.lastName.Text, Fields.lastName, "Поле фамилии не совпадает");
                Assert.AreEqual(checkDataPageDebit.firstName.Text, Fields.firstName, "Поле имени не совпадает");
                Assert.AreEqual(checkDataPageDebit.middleName.Text, Fields.middleName, "Поле отчества не совпадает");
                Assert.AreEqual(checkDataPageDebit.birthDate.Text, Fields.birthDate, "Поле даты рождения не совпадает");
                Assert.AreEqual(checkDataPageDebit.phoneNumber.Text.Replace(" ", "").Replace("+", "").Replace("-", " ").Replace("(", "")
                .Replace(")", "").Replace(" ", "").Substring(1), Fields.phoneNumber, "Поле номера телефона не совпадает");
            });
        }

        [Test(Description = "Проверка страницы подтверждения данных у кредита")]
        public void CreditDataCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/consumer-loan");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            CreditPage creditPage = new CreditPage(driver, driverWait, true);
            var interactions = new Interactions(driver, driverWait);
            interactions.AcceptCookieIfExists()
                .FillCheckBox(true, creditPage.promotionCheckBox.element, creditPage.promotionCheckBox._xPath)
                .FillCheckBox(true, creditPage.personalDataCheckBox.element, creditPage.personalDataCheckBox._xPath)
                .FillCheckBox(true, creditPage.creditStoryCheckBox.element, creditPage.creditStoryCheckBox._xPath)
                .FillTextFields(creditPage.firstNameInput.element, Fields.firstName)
                .FillTextFields(creditPage.lastNameInput.element, Fields.lastName)
                .FillTextFields(creditPage.middleNameInput.element, Fields.middleName)
                .FillActionFields(creditPage.birthDateInput.element, Fields.birthDate)
                .FillActionFields(creditPage.phoneNumberInput.element, Fields.phoneNumber.Substring(1))
                .FillListBox(creditPage.citizenShipInput.element, "РФ")
                .FillListBox(creditPage.oficcialEmploymentInput.element, "Есть")
                .ClickElement(creditPage.maleRadioButton.element)
                .ClickElement(creditPage.continueButton.element);

            CheckDataPage checkDataPageCredit = new CheckDataPage(driver, driverWait, true);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(checkDataPageCredit.lastName.Text, Fields.lastName, "Поле фамилии не совпадает");
                Assert.AreEqual(checkDataPageCredit.firstName.Text, Fields.firstName, "Поле имени не совпадает");
                Assert.AreEqual(checkDataPageCredit.middleName.Text, Fields.middleName, "Поле отчества не совпадает");
                Assert.AreEqual(checkDataPageCredit.birthDate.Text, Fields.birthDate, "Поле даты рождения не совпадает");
                Assert.AreEqual(checkDataPageCredit.phoneNumber.Text.Replace(" ", "").Replace("+", "").Replace("-", " ").Replace("(", "")
                .Replace(")", "").Replace(" ", "").Substring(1), Fields.phoneNumber, "Поле номера телефона не совпадает");
            });
        }

        [Test(Description = "Проверка отображения значений каждого слайдера и общей суммы после их прокрутки")]
        public void SliderSetValueDispayedCorrectly()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait, true);

            var cashBack = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(@class, 'cashback-calculator-output__label-yearly-count')]")));

            var startCashBack = cashBack.Text;

            Random random = new Random();
            for (int i = 0; i < debitCardYourCashBack.Sliders.list.Count; i++)
            {
                var slider = debitCardYourCashBack.Sliders.list[i];               
                slider.SetValue(random.Next(0, 50001));
                var textValue = driver.FindElement(By.XPath($"(//span[contains(@class, 'category-value')])[{i + 1}]"))
                    .Text.Replace(" ", "").Replace("₽/мес", "");
                Assert.AreEqual(slider.GetTextFromField(), textValue, "Значения слайдера и текста не совпадают");
            }

            var currentCashBack = cashBack.Text;

            Assert.AreNotEqual(startCashBack, currentCashBack, "Сумма осталась той же");               
        }

        //[TestCase("Сколько стоит и по времени занимает выпуск карты?", "Выпуск бесплатно. Меньше 5 минут. Картой можно пользоваться сразу, пластиковый носитель не обязателен.")]
        [TestCase("Есть ли лимиты на снятие наличных?", "Существует два лимита: дневной — до 150 000 ₽ и ежемесячный — до 300 000 ₽. Снятие наличных до указанного лимита в банкоматах ПСБ, Альфа-банка и Россельхозбанка будет бесплатным. В остальных банкоматах бесплатно при снятии от 3000 ₽ до 30 000 ₽. При этом 30 000 ₽ – это максимальная сумма снятия в месяц без комиссии.")]
        [TestCase("Что такое кешбэк?", "Это баллы, которые мы начисляем раз в месяц за покупки или за то, что вы храните деньги на карте. Вы можете переводить себе на карту любое количество полученных баллов по курсу: 1 балл = 1 ₽. Баллы доступны для использования в течение 1 года со дня их начисления.")]
        public void FAQTest(string question, string expectedAnswer)
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
        
            DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait, true);
            var list = debitCardYourCashBack.FAQList.list;

            Assert.AreEqual(expectedAnswer.Trim(), list.FirstOrDefault(x => x.Question.Contains(question)).ShowAnswer().Trim(), "Вопрос и ответ не соответствуют друг другу");
        }

        [Test]
        public void CategoriesTest()
        {
            var categories = new string[] { "Кино", "АЗС", "Кафе" };

            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait, true);

            debitCardYourCashBack.categoriesButton.element.Click();
            driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//rtl-select-categories-dialog")));
            var checkBoxesList = debitCardYourCashBack.CheckBoxesList;
            checkBoxesList.list.ForEach(x => x.Check(false));

            categories.ToList().ForEach(x => checkBoxesList.list.FirstOrDefault(y => y.Title.Contains(x)).Check(true));
            debitCardYourCashBack.confirmCategoriesButton.element.Click();

            driverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//rtl-select-categories-dialog")));

            var categoriesTitles = new List<string>();
            driver.FindElements(By.XPath("//div[contains(@class, 'category-wrapper')]"))
                .ToList().ForEach(x => categoriesTitles.Add(x.Text));

            categories.ToList().ForEach(x => Assert.True(categoriesTitles.Any(y => y.Contains(x)), "Выбранная категория отсутствует")); 
        }

        [TestCase("Пу", "Пушкин")]
        public void ListBoxTest(string subString, string expected)
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait, true);

            //debitCardYourCashBack.lastNameInput.element.SendKeys(subString);
            //driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@role, 'listbox')]")));
            var lastNameOpt = debitCardYourCashBack.LastNameOptions;
            lastNameOpt.SetField(subString).SelectOptionByName(expected);
   
            debitCardYourCashBack.FirstNameOptions.SetField("Вас").SelectOptionById(2);
            debitCardYourCashBack.MiddleNameOptions.SetField("Дени").SelectOptionByName("Денисович");
            debitCardYourCashBack.CitizenShipOptions.SetField().SelectOptionByName("РФ");
            

            Assert.AreEqual(expected, debitCardYourCashBack.lastNameInput.GetTextFromField(), "Выбранная фамилия неверно отображается");
        }

        [TestCase("30.12.1940")]
        public void CalendarSetDateTest(string date)
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait, true);

            var calendar = debitCardYourCashBack.Calendar;
            calendar.SetDate(date);

            Assert.AreEqual(date, debitCardYourCashBack.birthDateInput.GetTextFromField(), "Выбранная дата неверно отображается в поле.");
        }

        [Test(Description = "Проверка отображения информации в pdf файле")]
        public void PdfFileCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait, true);

            debitCardYourCashBack.AdditionalDocuments.list[0].element.FindElement(By.XPath("./a")).Click();

            string text = "";

            var tabs = driver.WindowHandles;
            driver.SwitchTo().Window(tabs[1]);

            string workingDirectory = Environment.CurrentDirectory;

            string pathToFile = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName + "\\Pages\\Helpers\\test.pdf";

            if (FileLoader.LoadByUrl(driver.Url, pathToFile))
            {
                text = TextExtractor.ExtractFromPdf(pathToFile);
                FileLoader.DeleteFile(pathToFile);
            }
            else Assert.Fail("Ошибка при загрузке файла");

            Assert.True(text.Contains("Дебетовая карта «Твой кешбэк»"), "Неверное содержание pdf файла");
        }


        //3 block

        //Task1
        //Страница https://ib.psbank.ru/, тип локатора xPath, значение локатора "//span[contains(text(), "Стать клиентом")]"
        //Страница https://ib.psbank.ru/store/products/consumer-loan, тип локатора xPath, значение локатора "//div[contains(@class, "card-benefits-banner__text")]"
        //Страница https://ib.psbank.ru/store/products/investmentsbrokerage, тип локатора xPath, значение локатора "//span[contains(text(), "Аналитическая поддержка")]"


        [Test(Description = "Проверка отображения текста в блоке переводов с карты на карту")]
        public void TransferFromCardToCardHasRightText()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            driver.SwitchTo().Frame(driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//iframe[@class='card-to-card__iframe']"))));

            var elementWithTetxVisible = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//h2[@class='transfers__title']")));
            var elementText = elementWithTetxVisible.Text;

            Assert.Multiple(() =>
            {
                Assert.NotNull(elementWithTetxVisible, "Текст не отображается");
                Assert.AreEqual(elementText, "Перевод с карты на карту", "Элемент не содержит правильный текст");
            });          
        }

        [Test(Description = "Проверка url у брокерского договора")]
        public void InvestmentLinksLoadCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/");
            
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            var investmentsDropMenu = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Инвестиции')]")));
            investmentsDropMenu.Click();
                       
            var option = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(), 'Брокерский договор')]")));
            var optionLink = option.GetAttribute("href");
            Assert.AreEqual("https://ib.psbank.ru/store/products/investmentsbrokerage", optionLink, "Неверный url у тега с Брокерским договором.");

            option.Click();
            driverWait.Until(ExpectedConditions.UrlToBe(optionLink));
            
            Assert.AreEqual("https://ib.psbank.ru/store/products/investmentsbrokerage", driver.Url, "Переход на неправильный url.");
        }

        [Test(Description = "Проверка текста на странице кредита при смене вкладок")]
        public void SwitchTabsCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/consumer-loan");

            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");

            var tabs = driver.WindowHandles;
          
            driver.SwitchTo().Window(tabs[1]);

            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/investmentsbrokerage");

            string pattern = @"Генеральная лицензия на осуществление банковских операций № \d{4} от \d{2} \w{3,8} \d{4}";

            var text = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//font[contains(text(), 'Генеральная лицензия на')]"))).Text;
            var isInvestTextMatch = Regex.IsMatch(text, pattern);
            Assert.IsTrue(isInvestTextMatch, "Текст на странице инвестиций не соответсвует паттерну.");

            driver.Close();
            driver.SwitchTo().Window(tabs[0]);

            text = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//rtl-copyrights"))).Text;
            var isCreditTextMatch = Regex.IsMatch(text, pattern);

            Assert.IsTrue(isCreditTextMatch, "Текст на странице кредита не соответсвует паттерну.");
            
        }

        [Test(Description = "Проверка работы вкладок ипотеки")]
        public void MortgageTabsCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/");

            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            Interactions interactions = new Interactions(driver, driverWait);
            interactions.AcceptCookieIfExists();

            var mortgageDropMenu = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Ипотека')]")));
            mortgageDropMenu.Click();

            var option = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(), 'Приобретение квартиры')]")));
            option.Click();

            
            var button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(), 'Приобретение')]")));
            button.Click();

            //проверить цвет как зафиксят
            
            var familyMortgage = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(text(), 'Семейная ипотека — ')]")));
            familyMortgage.Click();

            var familyMortgageProgramText = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(text(), 'Семейная ипотека')]")))
                .Text;
            var familyMortgageMonthlyPayment = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@data-testid='monthly-payment']"))).Text
                .Replace(" ", "").Replace("₽", "");
            int payment;
            var isFamilyMortgageMonthlyPaymentNumber = int.TryParse(familyMortgageMonthlyPayment, out payment);

            var familyMortgageInterestRate = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@data-testid='interest-rate']"))).Text;
            var pattern = @"\d*%";
            var isFamilyMortgageInterestRateMatch = Regex.IsMatch(familyMortgageInterestRate, pattern);


            Assert.Multiple(() =>
            {
                Assert.AreEqual(familyMortgageProgramText, "Семейная ипотека — 6%", "Неверное отображение типа ипотеки семейной ипотеке.");
                Assert.True(isFamilyMortgageMonthlyPaymentNumber, "Месячный платеж не число в семейной ипотеке.");
                Assert.True(isFamilyMortgageInterestRateMatch, "Процент не соответствует маске в семейной ипотеке.");
            });

            

            button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(), 'Рефинансирование')]")));                        
            button.Click();
            Actions action = new Actions(driver);
            action.MoveByOffset(0, 100).Release().Perform();
            button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(), 'Рефинансирование')]/..")));

            var refinancingProgramText = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(text(), 'Рефинансирование. Семейная')]"))).Text;
            var refinancingMonthlyPayment = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@data-testid='monthly-payment']"))).Text
                .Replace(" ", "").Replace("₽", "");
            var isRefinancingMonthlyPaymentNumber = int.TryParse(refinancingMonthlyPayment, out payment);

            var refinancingProgramRate = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@data-testid='interest-rate']"))).Text;
            var isRefinancingProgramInterestRateMatch = Regex.IsMatch(familyMortgageInterestRate, pattern);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(button.GetCssValue("background-color"), "rgba(33, 33, 33, 1)", "Цвет кнопки 'Рефинансирование' неправильный в выбранном состоянии.");
                Assert.AreEqual(refinancingProgramText, "Рефинансирование. Семейная ипотека — 6%", "Неверное отображение типа ипотеки в рефинансировании.");
                Assert.True(isRefinancingMonthlyPaymentNumber, "Месячный платеж не число в рефинансировании.");
                Assert.True(isRefinancingProgramInterestRateMatch, "Процент не соответствует маске в рефинансировании.");
            });            
        }

        [Test]
        public void CheckDataTest()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            string path = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..");
            
            string[] files = Directory.GetFiles(path, "data.json", SearchOption.AllDirectories);
            var scenarios = JsonConvert.DeserializeObject<Dictionary<string, Data>>(File.ReadAllText(files[0]));
            Data data = scenarios["goodScenario"];

            DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait, true);
            debitCardYourCashBack.FillPage(data);
            debitCardYourCashBack.continueButton.element.Click();

            CheckDataPage checkDataPageDebit = new CheckDataPage(driver, driverWait, true);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(checkDataPageDebit.lastName.Text, data.lastName, "Поле фамилии не совпадает");
                Assert.AreEqual(checkDataPageDebit.firstName.Text, data.firstName, "Поле имени не совпадает");
                Assert.AreEqual(checkDataPageDebit.middleName.Text, data.middleName, "Поле отчества не совпадает");
                Assert.AreEqual(checkDataPageDebit.birthDate.Text, data.birthDate, "Поле даты рождения не совпадает");
                Assert.AreEqual(checkDataPageDebit.phoneNumber.Text.Replace(" ", "").Replace("+", "").Replace("-", " ").Replace("(", "")
                .Replace(")", "").Replace(" ", "").Substring(1), data.phoneNumber, "Поле номера телефона не совпадает");
            });
        }
    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pages.Helpers;
using Pages.WebElements;
using SpecFlowProject1;

namespace Pages.Pages
{
    public class DebitCardYourCashBack : BasePage
    {       
        public CustomWebElement firstNameInput;
        public CustomWebElement lastNameInput;
        public CustomWebElement middleNameInput;
        public CustomWebElement maleRadioButton;
        public CustomWebElement femaleRadioButton;
        public CustomWebElement birthDateInput;
        public CustomWebElement phoneNumberInput;
        public CustomWebElement citizenShipInput;
        public CustomWebElement personalDataCheckBox;
        public CustomWebElement promotionCheckBox;

        public CustomWebElement continueButton;

        public CustomWebElement categoriesButton;
        public CustomWebElement confirmCategoriesButton { get => new CustomWebElement("//button[contains(@class, 'confirm-button')]", _driver, _driverWait); }

        public CustomWebElement yearButton;

        /// <summary>
        /// Слайдеры в калькуляторе кешбэка. При обращении к ним будет происходить их инициализация
        /// </summary>
        public ListOfElements<Slider> Sliders { get => new ListOfElements<Slider>("//input[contains(@class,'slider') and @type='range']", _driver, _driverWait); }
        /// <summary>
        /// Чекбоксы категорий кешбэка. При обращении к ним будет происходить их инициализация
        /// </summary>
        public ListOfElements<CheckBox> CheckBoxesList { get => new ListOfElements<CheckBox>("//li[contains(@class, 'category')]", _driver, _driverWait); }
        
        //опции
        public ListBox LastNameOptions { get => new ListBox("//input[@name='CardHolderLastName']", _driver, _driverWait); }
        public ListBox FirstNameOptions { get => new ListBox("//input[@name='CardHolderFirstName']", _driver, _driverWait); }
        public ListBox MiddleNameOptions { get => new ListBox("//input[@name='CardHolderMiddleName']", _driver, _driverWait); }
        public ListBox CitizenShipOptions { get => new ListBox("//mat-select[@name='RussianFederationResident']", _driver, _driverWait); }

        /// <summary>
        /// Класс взаимодействия с datepicker. При обращении к нему будет происходить его инициализация
        /// </summary>
        public Calendar Calendar { get => new Calendar("//mat-calendar", _driver, _driverWait); }
        /// <summary>
        /// Вопросы и ответы по карте. При обращении к ним будет происходить их инициализация
        /// </summary>
        public ListOfElements<FAQ> FAQList { get => new ListOfElements<FAQ>("//rui-expansion-panel", _driver, _driverWait); }
        /// <summary>
        /// Список файлов PDF на странице. При обращении к ним будет происходить их инициализация
        /// </summary>
        public ListOfElements<CustomWebElement> AdditionalDocuments { get => new ListOfElements<CustomWebElement>("//div[contains(@class, 'additional-info-documents__body')]", _driver, _driverWait); }

        public DebitCardYourCashBack(IWebDriver driver, WebDriverWait webDriverWait, bool cookie) : base(driver, webDriverWait, cookie)
        {
            FindElements();
            FindScecialElements();
            Fields.GenerateFields();
        }

        /// <summary>
        /// Находит все веб-элементы на странице.
        /// </summary>
        private void FindElements()
        {
            lastNameInput = new CustomWebElement("//input[@name='CardHolderLastName']", _driver, _driverWait);
            firstNameInput = new CustomWebElement("//input[@name='CardHolderFirstName']", _driver, _driverWait);
            middleNameInput = new CustomWebElement("//input[@name='CardHolderMiddleName']", _driver, _driverWait);
            maleRadioButton = new CustomWebElement("//div[@class='rui-radio__label'][normalize-space()='Мужской']/..", _driver, _driverWait);
            femaleRadioButton = new CustomWebElement("//div[@class='rui-radio__label'][normalize-space()='Женский']/..", _driver, _driverWait);
            birthDateInput = new CustomWebElement("//input[@data-mat-calendar='mat-datepicker-1']", _driver, _driverWait);
            phoneNumberInput = new CustomWebElement("//input[@rtl-automark='Phone']", _driver, _driverWait);
            citizenShipInput = new CustomWebElement("//mat-select[@name='RussianFederationResident']", _driver, _driverWait);
            personalDataCheckBox = new CustomWebElement("//a[@href='/res/i/td/ConsentPDProcessing.pdf']/../../../span[@class='rui-checkbox__frame']", _driver, _driverWait);
            promotionCheckBox = new CustomWebElement("//a[@href='/res/i/td/ConsentPromotion.pdf']/../../../span[@class='rui-checkbox__frame']", _driver, _driverWait);
            continueButton = new CustomWebElement("//button[@rtl-automark='REGISTRATION_NEXT']", _driver, _driverWait);
        }

        /// <summary>
        /// Находит уникальные элементы для страницы кешбэка
        /// </summary>
        protected virtual void FindScecialElements()
        {
            categoriesButton = new CustomWebElement("//span[contains(text(), 'Выбрать другие категории')]/../..", _driver, _driverWait);
            yearButton = new CustomWebElement("//rui-icon[contains(@name, 'Calendar')]", _driver, _driverWait);
        }

        public override void FillPage(Data data, Interactions interactions)
        {
            interactions.FillActionFields(firstNameInput.element, data.firstName);
            interactions.FillActionFields(lastNameInput.element, data.lastName);
            interactions.FillActionFields(middleNameInput.element, data.middleName);
            interactions.FillActionFields(birthDateInput.element, data.birthDate);
            interactions.FillActionFields(phoneNumberInput.element, data.phoneNumber);
            interactions.FillListBox(citizenShipInput.element, data.citizenShip);
            interactions.ClickElement(data.sex == 'М' ? maleRadioButton.element : femaleRadioButton.element);
            interactions.FillCheckBox(data.promotionCheckBox, promotionCheckBox.element, promotionCheckBox._xPath);
            interactions.FillCheckBox(data.promotionCheckBox, personalDataCheckBox.element, personalDataCheckBox._xPath);
        }
    }
}

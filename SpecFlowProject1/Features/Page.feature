Feature: Page

A short summary of the feature

@test1
Scenario: Проверка корректности данных на странице подтверждения после заполнения формы на дебетку
	Given Переходим на страницу по адрессу "https://ib.psbank.ru/store/products/your-cashback-new"
	Then Заполнить поле "lastNameInput" страницы "DebitCardYourCashBack" текстом "абв"
	Then Заполнить поле "firstNameInput" страницы "DebitCardYourCashBack" текстом "абв"
	Then Заполнить поле "middleNameInput" страницы "DebitCardYourCashBack" текстом "абв"
	Then Нажать на "maleRadioButton" на странице "DebitCardYourCashBack"
	Then Заполнить поле "birthDateInput" страницы "DebitCardYourCashBack" текстом "30.12.2003"
	Then Заполнить поле "phoneNumberInput" страницы "DebitCardYourCashBack" текстом "9001022020"
	Then Поставить листбокс "citizenShipInput" на странице "DebitCardYourCashBack" в положение "РФ"
	Then Поставить чекбокс "personalDataCheckBox" на страницке "DebitCardYourCashBack" в положение "true"
	Then Поставить чекбокс "promotionCheckBox" на страницке "DebitCardYourCashBack" в положение "true"
	Then Нажать на "continueButton" на странице "DebitCardYourCashBack"
	Given Текст поля "firstName" верный
	Given Текст поля "lastName" верный
	Given Текст поля "middleName" верный
	Given Текст поля "birthDate" верный
	Given Текст поля "phoneNumber" верный

@test2
Scenario: Проверка корректности данных на странице подтверждения после заполнения формы на дебетку(сразу заполняем поля)
	Given Переходим на страницу по адрессу "https://ib.psbank.ru/store/products/your-cashback-new"
	Then Заполнить поля страницы "DebitCardYourCashBack" параметрами:
		| Field                | Value      |
		| firstName            | абв        |
		| lastName             | абв        |
		| middleName           | абв        |
		| birthDate            | 30.12.2003 |
		| phoneNumber          | 9004156767 |
		| citizenShip          | РФ         |
		| sex                  | М          |
		| personalDataCheckBox | true       |
		| promotionCheckBox    | true       |
	Then Нажать на "continueButton" на странице "DebitCardYourCashBack"
	Given Текст поля "firstName" верный
	Given Текст поля "lastName" верный
	Given Текст поля "middleName" верный
	Given Текст поля "birthDate" верный
	Given Текст поля "phoneNumber" верный

@test3
Scenario: Проверка корректности данных на странице подтверждения после заполнения формы на дебетку(через методы страницы)
	Given Переходим на страницу по адрессу "https://ib.psbank.ru/store/products/your-cashback-new"
	Then Заполнить страницу "DebitCardYourCashBack" данными из файла "data.json" сценарием "goodScenario"
	Then Нажать на "continueButton" на странице "DebitCardYourCashBack"
	Given Текст поля "firstName" верный
	Given Текст поля "lastName" верный
	Given Текст поля "middleName" верный
	Given Текст поля "birthDate" верный
	Given Текст поля "phoneNumber" верный

@test4
Scenario: Проверка корректности данных на странице подтверждения после заполнения формы на дебетку(через targetPage)
	Given Переходим на страницу по адрессу "https://ib.psbank.ru/store/products/your-cashback-new"	
	Given Выбрать страницу "DebitCardYourCashBack"
	Then Заполнить поле "firstNameInput" текстом "dfa"
	Then Заполнить поле "middleNameInput" текстом "dfa"
	Then Заполнить поле "lastNameInput" текстом "dfa"

	
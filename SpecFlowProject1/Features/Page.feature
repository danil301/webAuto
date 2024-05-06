Feature: Page

A short summary of the feature

@test1
Scenario: Проверка корректности данных на странице подтверждения после заполнения формы на дебетку
	Given Переходим на страницу по адрессу "https://ib.psbank.ru/store/products/your-cashback-new"
	Given Открылась страница "DebitCardYourCashBack"
	Then Заполнить поле "lastNameInput" текстом "абв"
	Then Заполнить поле "firstNameInput" текстом "абв"
	Then Заполнить поле "middleNameInput" текстом "абв"
	Then Выбрать пол "мужской"
	Then Заполнить поле "birthDateInput" текстом "30.12.2003"
	Then Заполнить поле "phoneNumberInput" текстом "9001022020"
	Then Выбрать гражданство "РФ"
	Then Поставить чекбокс "personalDataCheckBox" в положение "Включён"
	Then Поставить чекбокс "promotionCheckBox" в положение "Включён"
	Then Нажать кнопку продолжить
	Given Открылась страница "CheckDataPage"	
	Given Текст поля "firstName" верный
	Given Текст поля "lastName" верный
	Given Текст поля "middleName" верный
	Given Текст поля "birthDate" верный
	Given Текст поля "phoneNumber" равен "+7 (900) 102-20-20"
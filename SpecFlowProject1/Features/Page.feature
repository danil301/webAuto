Feature: Page

A short summary of the feature

@test1
Scenario: Проверка корректности данных на странице подтверждения после заполнения формы на дебетку
	Given Переходим на страницу по адрессу "https://ib.psbank.ru/store/products/your-cashback-new"
	Then Проверяем адресс "https://ib.psbank.ru/store/products/your-cashback-new"
	Then Заполнить поле Фамилия "абв"
	Then Заполнить поле Имя "абв"
	Then Заполнить поле Отчество "абв"
	Then Выбрать пол "мужской"
	Then Заполнить дату рождения "30.12.2003"
	Then Ввести номер мобильного телефона "9001022020"
	Then Выбрать гражданство "РФ"
	Then Выбрать чекбокс на согласие обработки данных
	Then Выбрать чекбокс рассылки
	Then Нажать кнопку продолжить
	Given Открылась страница подтверждения данных с url "https://ib.psbank.ru/store/products/your-cashback-new"
	Then Проверяем адресс "https://ib.psbank.ru/store/products/your-cashback-new"
	Given Поле фамилии равно "абв"
	Given Поле имени равно "абв"
	Given Поле отчества равно "абв"
	Given Поле даты рождения равно "30.12.2003" 
	Given Поле номера телефона равно "+7 (900) 102-20-20"
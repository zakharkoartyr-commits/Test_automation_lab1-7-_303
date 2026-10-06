Feature: Bank Manager Customers Sorting
  Як Bank Manager
  Я хочу переглядати список клієнтів
  Щоб мати можливість сортувати їх за Last Name

  Scenario: Перевірка сортування клієнтів за Last Name
    Given користувач відкриває головну сторінку "https://www.globalsqa.com/angularJs-protractor/BankingProject"
    When користувач натискає на кнопку "Bank Manager Login"
    And користувач переходить на вкладку "Customers"
    And користувач клікає на заголовок стовпця "Last Name" для сортування
    Then список Last Name повинен бути відсортований за спаданням або зростанням
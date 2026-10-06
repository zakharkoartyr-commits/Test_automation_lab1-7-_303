using lab2_automatioon.Drivers;
using lab2_automatioon.Pages;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace lab2_automatioon.StepDefinitions
{
    [Binding]
    public class SortLastNameStepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly CustomersPage _customersPage;

        public SortLastNameStepDefinitions(WebDriverContext driverContext)
        {
            _homePage = new HomePage(driverContext.Driver);
            _customersPage = new CustomersPage(driverContext.Driver);
        }

        [Given(@"користувач відкриває головну сторінку ""(.*)""")]
        public void GivenКористувачВідкриваєГоловнуСторінку(string url)
        {
            _homePage.Open(url);
        }

        [When(@"користувач натискає на кнопку ""Bank Manager Login""")]
        public void WhenКористувачНатискаєНаКнопку()
        {
            _homePage.ClickBankManagerLogin();
        }

        [When(@"користувач переходить на вкладку ""Customers""")]
        public void WhenКористувачПереходитьНаВкладку()
        {
            _customersPage.ClickCustomersTab();
        }

        [When(@"користувач клікає на заголовок стовпця ""Last Name"" для сортування")]
        public void WhenКористувачКлікаєНаЗаголовокСтовпцяДляСортування()
        {
            _customersPage.ClickSortByLastName();
        }

        [Then(@"список Last Name повинен бути відсортований за спаданням або зростанням")]
        public void ThenСписокLastNameПовиненБутиВідсортований()
        {
            List<string> actualLastNames = _customersPage.GetLastNamesList();

            List<string> sortedAsc = actualLastNames.OrderBy(name => name).ToList();
            List<string> sortedDesc = actualLastNames.OrderByDescending(name => name).ToList();

            bool isSorted = actualLastNames.SequenceEqual(sortedAsc) || actualLastNames.SequenceEqual(sortedDesc);

            Assert.That(isSorted, Is.True, "Список Last Name не є коректно відсортованим.");
        }
    }
}
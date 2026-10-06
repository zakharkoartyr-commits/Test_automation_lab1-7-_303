using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2_automatioon.Pages
{
    public class CustomersPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CustomersPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private By CustomersTabButton => By.XPath("//button[contains(text(),'Customers')]");
        private By LastNameHeaderLink => By.XPath("//table//thead//tr//td[2]//a[contains(text(),'Last Name')]");
        private By LastNameRows => By.XPath("//table//tbody//tr/td[2]");

        public void ClickCustomersTab()
        {
            var tab = _wait.Until(d => d.FindElement(CustomersTabButton));
            tab.Click();
        }

        public void ClickSortByLastName()
        {
            var header = _wait.Until(d => d.FindElement(LastNameHeaderLink));
            header.Click();
        }

        public List<string> GetLastNamesList()
        {
            _wait.Until(d => d.FindElements(LastNameRows).Count > 0);
            var elements = _driver.FindElements(LastNameRows);
            return elements.Select(e => e.Text.Trim()).ToList();
        }
    }
}
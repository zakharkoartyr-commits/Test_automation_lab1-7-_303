using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace lab2_automatioon.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private By BankManagerLoginButton => By.XPath("//button[contains(text(),'Bank Manager Login')]");

        public void Open(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ClickBankManagerLogin()
        {
            var button = _wait.Until(d => d.FindElement(BankManagerLoginButton));
            button.Click();
        }
    }
}
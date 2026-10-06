using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace lab2_automatioon.Drivers
{
    public class WebDriverContext
    {
        public IWebDriver Driver { get; }

        public WebDriverContext()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}
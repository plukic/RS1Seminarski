using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FunctionalTests.PageObjectModels
{
    class NavbarPage
    {
        private readonly IWebDriver _driver;

        public NavbarPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement ConstructionSitesLink {get => _driver.FindElement(By.CssSelector("a[href*='ConstructionSites']")); }

        public void NavigateToConstructionSites()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(ConstructionSitesLink));
            clickableElement.Click();
        }
    }
}

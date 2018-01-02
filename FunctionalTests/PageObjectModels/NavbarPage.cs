using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

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
        public IWebElement EquipmentLink {get => _driver.FindElement(By.CssSelector("a[href*='Equipment']")); }

        public void NavigateToConstructionSites()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(ConstructionSitesLink));
            clickableElement.Click();
        }

        public void NavigateToEquipment()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(EquipmentLink));
            clickableElement.Click();
        }
    }
}

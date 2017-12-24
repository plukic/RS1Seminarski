using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FunctionalTests.PageObjectModels
{
    class ConstructionSitesPage
    {
        private readonly IWebDriver _driver;

        public ConstructionSitesPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement ConstructionSitesTable {get => _driver.FindElement(By.TagName("table")); } 
        public IWebElement ConstructionSitesCreationForm {get => _driver.FindElement(By.CssSelector("form[action*='/ConstructionSites/Create']")); } 
        public IWebElement CreateNewSiteLink { get => _driver.FindElement(By.CssSelector("a[href*='/ConstructionSites/Create']")); }

        public void OpenSiteCreationForm()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(CreateNewSiteLink));
            clickableElement.Click();
        }


    }
}

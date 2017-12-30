using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace FunctionalTests.PageObjectModels
{
    class ConstructionSitesPage
    {
        private readonly IWebDriver _driver;

        public ConstructionSitesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private const string TestSiteTitle = "project";
        private const decimal TestSiteWorth= 2112;
        private const string TestStartDate = "01012017";
        private const string TestEndDate = "01012018";
        private const string TestSiteCity = "Sarajevo";
        private const string TestContractDescription = "This will be a great project";

        public IWebElement ConstructionSitesTable {get => _driver.FindElement(By.TagName("table")); } 
        public IWebElement ConstructionSitesForm {get => _driver.FindElement(By.CssSelector("form[action*='/ConstructionSites/Create']")); } 
        public IWebElement CreateNewSiteLink { get => _driver.FindElement(By.CssSelector("a[href*='/ConstructionSites/Create']")); }
        public IWebElement SiteTitleInput { get => _driver.FindElement(By.Id("constructionSite_Title")); }
        public IWebElement SiteWorthInput { get => _driver.FindElement(By.Id("constructionSite_ProjectWorth")); }
        public IWebElement DateStartInput { get => _driver.FindElement(By.Id("constructionSite_DateStart")); }
        public IWebElement DateFinishInput { get => _driver.FindElement(By.Id("constructionSite_DateFinish")); }
        public IWebElement CityInput { get => _driver.FindElement(By.Id("constructionSite_CityId")); }
        public IWebElement ContractDescriptionInput { get => _driver.FindElement(By.Id("constructionSite_Contract_Description")); }
        public IWebElement ContractFileInput { get => _driver.FindElement(By.CssSelector("input[type='file']")); }
        public IWebElement Map { get => _driver.FindElement(By.Id("location-map")); }


        public void OpenSiteCreationForm()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(CreateNewSiteLink));
            clickableElement.Click();
        }

        public void FillOutForm()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(SiteTitleInput));


            var fullFileLocation = Helpers.Helpers.GetTestFileLocation();
            ContractFileInput.SendKeys(fullFileLocation);

            SiteTitleInput.SendKeys(TestSiteTitle);
            SiteWorthInput.SendKeys(TestSiteWorth.ToString());
            DateStartInput.SendKeys(TestStartDate);
            DateFinishInput.SendKeys(TestEndDate);
            new SelectElement(CityInput).SelectByText(TestSiteCity);
            ContractDescriptionInput.SendKeys(TestContractDescription);
            Map.Click();
        }

        public int CreateConstructionSite(IWebDriver driver)
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.RegisterAndLogin();
            driver.Navigate().GoToUrl(@"http://localhost:52140");

            var navbar = new NavbarPage(driver);
            navbar.NavigateToConstructionSites();
     
            OpenSiteCreationForm();

            FillOutForm();
            SubmitForm();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(ConstructionSitesTable));

            var detailsLinks = driver.FindElements(By.CssSelector("a[href*='/ConstructionSites/Details']"));
            var lastDetailsLink = detailsLinks.Last();
            var id = int.Parse(lastDetailsLink.GetAttribute("href").Split("/").Last());
            return id;
        }

        public void SubmitForm()
        {
            ConstructionSitesForm.Submit();
        }
    }
}

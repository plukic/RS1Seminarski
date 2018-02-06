using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace FunctionalTests.PageObjectModels
{
    class MaterialsPage
    {
        private readonly IWebDriver _driver;

        public MaterialsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private const string TestMaterialsTitle = "materials a";
        private const double TestAmount = 10312;

        public IWebElement MaterialsTable {get => _driver.FindElement(By.TagName("table")); } 
        public IWebElement MaterialsForm { get => _driver.FindElement(By.CssSelector("form[action*='/Materials/Create']")); } 
        public IWebElement CreateNewMaterialsLink { get => _driver.FindElement(By.CssSelector("a[href*='/Materials/Create']")); }
        public IWebElement MaterialsTitleInput { get => _driver.FindElement(By.Id("Name")); }
        public IWebElement AmountInput { get => _driver.FindElement(By.Id("Amount")); }
        public IWebElement UnitInput { get => _driver.FindElement(By.Id("Unit")); }


        public void OpenMaterialsCreationForm()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(CreateNewMaterialsLink));
            clickableElement.Click();
        }


        public void OpenMaterialsEdit()
        {
            int id = CreateMaterials(_driver);
            _driver.Navigate().GoToUrl(@"http://localhost:52140/Materials/Edit/" + id);
        }

        public void FillOutForm()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(MaterialsTitleInput));


            MaterialsTitleInput.SendKeys(TestMaterialsTitle);
            AmountInput.SendKeys(TestAmount.ToString());
        }

        public int CreateMaterials(IWebDriver driver)
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.RegisterAndLogin();
            driver.Navigate().GoToUrl(@"http://localhost:52140");

            var navbar = new NavbarPage(driver);
            navbar.NavigateToMaterials();
     
            OpenMaterialsCreationForm();

            FillOutForm();
            SubmitForm();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(MaterialsTable));

            var detailsLinks = driver.FindElements(By.CssSelector("a[href*='/Materials/Details']"));
            var lastDetailsLink = detailsLinks.Last();
            var id = int.Parse(lastDetailsLink.GetAttribute("href").Split("/").Last());
            return id;
        }

        public void SubmitForm()
        {
            MaterialsForm.Submit();
        }
    }
}

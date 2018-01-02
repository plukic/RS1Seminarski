using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace FunctionalTests.PageObjectModels
{
    class EquipmentPage
    {
        private readonly IWebDriver _driver;

        public EquipmentPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private const string TestEquipmentTitle = "equipment a";
        private const string TestPurchaseDate = "01012017";
        private const int TestQuantity = 6;
        private const string TestSerialNumber = "A3232";

        public IWebElement EquipmentTable {get => _driver.FindElement(By.TagName("table")); } 
        public IWebElement EquipmentForm { get => _driver.FindElement(By.CssSelector("form[action*='/Equipment/Create']")); } 
        public IWebElement CreateNewEquipmentLink { get => _driver.FindElement(By.CssSelector("a[href*='/Equipment/Create']")); }
        public IWebElement EquipmentTitleInput { get => _driver.FindElement(By.Id("Name")); }
        public IWebElement DatePurchaseInput { get => _driver.FindElement(By.Id("PurchaseDate")); }
        public IWebElement SerialNumberInput { get => _driver.FindElement(By.Id("SerialNumber")); }
        public IWebElement QuantityInput { get => _driver.FindElement(By.Id("Quantity")); }


        public void OpenEquipmentCreationForm()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(CreateNewEquipmentLink));
            clickableElement.Click();
        }


        public void OpenEquipmentEdit()
        {
            int id = CreateEquipment(_driver);
            _driver.Navigate().GoToUrl(@"http://localhost:52140/Equipment/Edit/" + id);
        }

        public void FillOutForm()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(EquipmentTitleInput));


            EquipmentTitleInput.SendKeys(TestEquipmentTitle);
            DatePurchaseInput.SendKeys(TestPurchaseDate);
            QuantityInput.SendKeys(TestQuantity.ToString());
            SerialNumberInput.SendKeys(TestSerialNumber);
        }

        public int CreateEquipment(IWebDriver driver)
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.RegisterAndLogin();
            driver.Navigate().GoToUrl(@"http://localhost:52140");

            var navbar = new NavbarPage(driver);
            navbar.NavigateToEquipment();
     
            OpenEquipmentCreationForm();

            FillOutForm();
            SubmitForm();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(EquipmentTable));

            var detailsLinks = driver.FindElements(By.CssSelector("a[href*='/Equipment/Details']"));
            var lastDetailsLink = detailsLinks.Last();
            var id = int.Parse(lastDetailsLink.GetAttribute("href").Split("/").Last());
            return id;
        }

        public void SubmitForm()
        {
            EquipmentForm.Submit();
        }
    }
}

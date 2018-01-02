using FunctionalTests.PageObjectModels;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using Assert = NUnit.Framework.Assert;

namespace FunctionalTests.ConstructionSites
{
    [TestFixture]
    public class ConstructionSitesTests
    {
        [Test]
        public void ShouldDisplayListForConstructionSites()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"http://localhost:52140");
                var registrationPage = new RegistrationPage(driver);
                registrationPage.RegisterAndLogin();

                var navbar = new NavbarPage(driver);
                navbar.NavigateToConstructionSites();

                var constructionSitesPage = new ConstructionSitesPage(driver);
                var constructionSitesList = constructionSitesPage.ConstructionSitesTable;
                Assert.That(constructionSitesList, Is.Not.Null);
            }
        }

        [Test]
        public void ShouldAllowConstructionSiteCreationThroughForm()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                var constructionSitesPage = new ConstructionSitesPage(driver);
                constructionSitesPage.CreateConstructionSite(driver);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement loadedList = wait.Until(ExpectedConditions.ElementToBeClickable(constructionSitesPage.ConstructionSitesTable));
                Assert.That(loadedList, Is.Not.Null);

            }
        }
        [Test]
        public void ShouldAllowConstructionSiteEditThroughForm()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                var constructionSitesPage = new ConstructionSitesPage(driver);
                int id = constructionSitesPage.CreateConstructionSite(driver);
                driver.Navigate().GoToUrl(@"http://localhost:52140/ConstructionSites/Edit/" + id);
                
                constructionSitesPage.FillOutForm();
                constructionSitesPage.SubmitForm();
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement loadedList = wait.Until(ExpectedConditions.ElementToBeClickable(constructionSitesPage.ConstructionSitesTable));
                Assert.That(loadedList, Is.Not.Null);

            }
        }
        [Test]
        public void ShouldAllowConstructionSiteEditWithoutFileInput()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                var constructionSitesPage = new ConstructionSitesPage(driver);
                constructionSitesPage.OpenSiteEdit();

                constructionSitesPage.FillOutForm();
                constructionSitesPage.ContractFileInput.Clear();
                constructionSitesPage.SubmitForm();
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement loadedList = wait.Until(ExpectedConditions.ElementToBeClickable(constructionSitesPage.ConstructionSitesTable));
                Assert.That(loadedList, Is.Not.Null);

            }
        }

        [Test]
        public void ShouldAllowAddingConstructionSiteManagerToConstructionSite()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                var registrationPage = new RegistrationPage(driver);
                registrationPage.RegisterAndLogin();
                var constructionSitesPage = new ConstructionSitesPage(driver);
                constructionSitesPage.OpenSiteEdit();
                constructionSitesPage.OpenAddSiteManagerModal();
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement randomManager = driver.FindElement(By.CssSelector(".construction-sites-managers-list tbody tr"));
                var clickableManager = wait.Until(ExpectedConditions.ElementToBeClickable(randomManager));
                clickableManager.Click();
                constructionSitesPage.SubmitAddSitemManagerButton.Click();
       
                var addedManager = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".construction-site-managers-panel .panel-body .site-manager")));

                Assert.That(addedManager, Is.Not.Null);

            }
        }
    }
}

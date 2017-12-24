using System;
using FunctionalTests.PageObjectModels;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Support.UI;

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
                var registrationPage = new RegistrationPage(driver);
                registrationPage.RegisterAndLogin();
                driver.Navigate().GoToUrl(@"http://localhost:52140");

                var navbar = new NavbarPage(driver);
                navbar.NavigateToConstructionSites();

                var constructionSitesPage = new ConstructionSitesPage(driver);
                constructionSitesPage.OpenSiteCreationForm();

                constructionSitesPage.FillOutForm();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var loadedList = wait.Until(ExpectedConditions.ElementToBeClickable(constructionSitesPage.ConstructionSitesTable));
                Assert.That(loadedList, Is.Not.Null);

            }
        }
    }
}

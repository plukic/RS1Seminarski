using FunctionalTests.PageObjectModels;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

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
        public void ShouldDisplaySiteCreationForm()
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

                var form = constructionSitesPage.ConstructionSitesCreationForm;
                Assert.That(form, Is.Not.Null);
            }
        }
    }
}

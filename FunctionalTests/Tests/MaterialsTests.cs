using System;
using System.IO;
using System.Reflection;
using FunctionalTests.PageObjectModels;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace FunctionalTests.Tests
{
    [TestFixture]
    public class MaterialsTests
    {
        [Test]
        public void ShouldDisplayListForMaterials()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"http://localhost:52140");
                var registrationPage = new RegistrationPage(driver);
                registrationPage.RegisterAndLogin();

                var navbar = new NavbarPage(driver);
                navbar.NavigateToMaterials();

                var materialsPage = new MaterialsPage(driver);
                var materialsList = materialsPage.MaterialsTable;
                Assert.That(materialsList, Is.Not.Null);
            }
        }

        [Test]
        public void ShouldAllowMaterialsCreationThroughForm()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                var materialsPage = new MaterialsPage(driver);
                materialsPage.CreateMaterials(driver);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement loadedList = wait.Until(ExpectedConditions.ElementToBeClickable(materialsPage.MaterialsTable));
                Assert.That(loadedList, Is.Not.Null);

            }
        }
        [Test]
        public void ShouldAllowMaterialsEditThroughForm()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                var materialsPage = new MaterialsPage(driver);
                int id = materialsPage.CreateMaterials(driver);
                driver.Navigate().GoToUrl(@"http://localhost:52140/Materials/Edit/" + id);
                
                materialsPage.FillOutForm();
                materialsPage.SubmitForm();
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement loadedList = wait.Until(ExpectedConditions.ElementToBeClickable(materialsPage.MaterialsTable));
                Assert.That(loadedList, Is.Not.Null);

            }
        }
    }
}

using FunctionalTests.PageObjectModels;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using Assert = NUnit.Framework.Assert;

namespace FunctionalTests.EquipmentTests
{
    [TestFixture]
    public class EquipmentTests
    {
        [Test]
        public void ShouldDisplayListForEquipment()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"http://localhost:52140");
                var registrationPage = new RegistrationPage(driver);
                registrationPage.RegisterAndLogin();

                var navbar = new NavbarPage(driver);
                navbar.NavigateToEquipment();

                var equipmentPage = new EquipmentPage(driver);
                var equipmentList = equipmentPage.EquipmentTable;
                Assert.That(equipmentList, Is.Not.Null);
            }
        }

        [Test]
        public void ShouldAllowEquipmentCreationThroughForm()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                var equipmentPage = new EquipmentPage(driver);
                equipmentPage.CreateEquipment(driver);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement loadedList = wait.Until(ExpectedConditions.ElementToBeClickable(equipmentPage.EquipmentTable));
                Assert.That(loadedList, Is.Not.Null);

            }
        }
        [Test]
        public void ShouldAllowEquipmentEditThroughForm()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                var equipmentPage = new EquipmentPage(driver);
                int id = equipmentPage.CreateEquipment(driver);
                driver.Navigate().GoToUrl(@"http://localhost:52140/Equipment/Edit/" + id);
                
                equipmentPage.FillOutForm();
                equipmentPage.SubmitForm();
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement loadedList = wait.Until(ExpectedConditions.ElementToBeClickable(equipmentPage.EquipmentTable));
                Assert.That(loadedList, Is.Not.Null);

            }
        }
    }
}

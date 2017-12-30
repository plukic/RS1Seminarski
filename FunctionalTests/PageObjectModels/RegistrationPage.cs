using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace FunctionalTests.PageObjectModels
{
    public class RegistrationPage
    {
        private readonly IWebDriver _driver;
        private readonly IConfigurationRoot _configuration;

        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;

            IConfigurationBuilder config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.development.json", optional: false);

            _configuration = config.Build();
        }

        private const string TestAccountUsername = "John";
        private readonly string _testAccountPassword = new Random(DateTime.Now.Millisecond) + "By9vy.";
        private const string TestAccountEmail = "John@mail.com";
        private const string TestAccountFirstName= "John";
        private const string TestAccountLastName= "Smith";
        private const string TestAccountDateOfBirth = "09051990";

        private readonly string _usernameInputId = "UserName";
        private readonly string _loginUsernameInputId = "Username";

        public IWebElement UsernameInput { get => _driver.FindElement(By.Id(_usernameInputId)); }
        public IWebElement LoginUsernameInput { get => _driver.FindElement(By.Id("Username")); }
        public IWebElement PasswordInput { get => _driver.FindElement(By.Id("Password")); }
        public IWebElement RepeatPasswordInput { get => _driver.FindElement(By.Id("ConfirmPassword")); }
        public IWebElement EmailInput { get => _driver.FindElement(By.Id("Email")); }
        public IWebElement DateOfBirthInput { get => _driver.FindElement(By.Id("BirthDate")); }
        public IWebElement FirstNameInput { get => _driver.FindElement(By.Id("FirstName")); }
        public IWebElement LastNameInput { get => _driver.FindElement(By.Id("LastName")); }
        public IWebElement Form { get => _driver.FindElement(By.TagName("form")); }



        public void NavigateToRegistration()
        {
            _driver.Navigate().GoToUrl(@"http://localhost:52140/login/register");
        }
        public void NavigateToLogin()
        {
            _driver.Navigate().GoToUrl(@"http://localhost:52140/login");
        }

        public void Login()
        {
            NavigateToLogin();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id(_loginUsernameInputId)));

            LoginUsernameInput.SendKeys(TestAccountUsername);
            PasswordInput.SendKeys(_testAccountPassword);
            LoginUsernameInput.Clear();
            PasswordInput.Clear();
            LoginUsernameInput.SendKeys(_configuration["MANAGER_USERNAME"]);
            PasswordInput.SendKeys(_configuration["MANAGER_PASSWORD"]);
            Form.Submit();
        }

        public void RegisterAndLogin()
        {
            //RegisterAccount();
            Login();
        }

    }
}

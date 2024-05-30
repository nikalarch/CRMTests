using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using CRMTests.Variables;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Runtime.InteropServices;
using static CRMTests.PageObjects.CreateContactPage;
using static CRMTests.PageObjects.LoginPage;
using static CRMTests.PageObjects.HomePage;
using CRMTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.DevTools.V123.Animation;
using System.Linq.Expressions;
using OpenQA.Selenium.Interactions;

namespace CRMTests.Hooks.StepDefinition
{
    [Binding]
    public class CreateContactTest
    {   // Variables for configuration settings, WebDriver instance, and page objects
        private readonly ConfigSettings _config;
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly CreateContactPage _createContactPage;
        private readonly HomePage _homePage;

        // Constructor to initialize the variables
        public CreateContactTest()
        {
            _config = Hooks.Config;
            _driver = Hooks.Driver;
            _loginPage = new LoginPage(_driver);
            _createContactPage = new CreateContactPage(_driver);
            _homePage = new HomePage(_driver);

        }
        //User login step definition
        [Given(@"User is logged in to the application")]
        public void GivenUserIsLoggedInToTheApplication()
        {


            _driver.Navigate().GoToUrl(_config.BaseUrl);

            //Wait for the login button to be clickable
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(_loginPage.LoginButton));

            _loginPage.UsernameField.SendKeys(_config.Username);
            _loginPage.PasswordField.SendKeys(_config.Password);
            _loginPage.LoginButton.Click();
        }

        //Step definition for clicking the create contact button
        [When(@"User clicks on the create contact button")]
        public void WhenUserClicksOnTheCreateContactButton()
        {   
            // Wait until the create contact button is visible, then click it
            WebDriverWait waitTillCreateContactButtonAppears = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            waitTillCreateContactButtonAppears.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='sidebar-item-link-basic' and contains(span, 'Create Contact')]")));
            {
                _homePage.CreateContactButton.Click();
            }
        }

        // Step definition for filling in other necessary fields
        [When(@"User fills in all necessary fields")]
        public void WhenUserFillsInAllNecessaryFields()

       
        {
            WebDriverWait waitTillContactFieldisAvailable = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // Actions to avoid overlapping elements
            var firstNameField = _createContactPage.ContactFirstNameField;
            Actions AvoidOverlappingContactFirstName = new Actions(_driver);
            AvoidOverlappingContactFirstName.MoveToElement(firstNameField).Click().Perform();

            //Check if contact first name is not null 
            if (string.IsNullOrWhiteSpace(_config.ContactFirstname))
            {
                throw new ArgumentNullException("ContactFirstname", "ContactFirstname cannot be null or empty.");
            }
            //Filling in contact fields
            _createContactPage.ContactFirstNameField.SendKeys(_config.ContactFirstname);
            _createContactPage.ContactLastNameField.SendKeys(_config.ContactLastname);
            _createContactPage.BusinessRoleDropdown.Click();

            // Wait for CEO option to be clickable
            WebDriverWait waitTillCeoOptionAppears = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            waitTillCeoOptionAppears.Until(ExpectedConditions.ElementToBeClickable(_createContactPage.BusinessRoleDropdownOptionCEO));

            // Actions to avoid overlapping CEO option
            Actions AvoidOverlappingCEOoption = new Actions(_driver);
            AvoidOverlappingCEOoption.MoveToElement(firstNameField).Click().Perform();

            //Clicking on dropdown options
            _createContactPage.BusinessRoleDropdownOptionCEO.Click();
            _createContactPage.CategoryDropdownOptionSuppliers.Click();
            _createContactPage.CategoryDropdownOptionCustomers.Click();
        }
        //Step definition for clicking save contact button
        [When(@"User clicks save contact button")]
        public void WhenUserClicksSaveContactButton()
        {
            _createContactPage.SaveContactButton.Click();
        }

        //Step definition for filled-in data verification
        [Then(@"User sees that filled-in data is displayed on the page")]
        public void ThenUserSeesThatFieldInDataIsDisplayedOnThePage()
        {
            var nameField = _driver.FindElement(By.XPath("//span[@class='name']"));
            Assert.That(nameField.Text.Contains(_config.ContactFirstname));
            Assert.That(nameField.Text.Contains(_config.ContactLastname));
        }
    }
}

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CRMTests.PageObjects
{
    // Page object class for the Login page
    public class LoginPage
    {
        private IWebDriver _driver;

        // Constructor to initialize the WebDriver 
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        // Web elements on the Login page
        public IWebElement UsernameField => _driver.FindElement(By.XPath("//*[@id=\"login_user\"]"));
        public IWebElement PasswordField => _driver.FindElement(By.XPath("//*[@id=\"login_pass\"]"));
        public IWebElement LoginButton => _driver.FindElement(By.XPath("//*[@id=\"login_button\"]/span[1]"));
    }
    // Page object class for the Home page
    public class HomePage
    {
        private IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        // Web elements on the Home page
        public IWebElement CreateContactButton => _driver.FindElement(By.XPath("//a[@class='sidebar-item-link-basic' and contains(span, 'Create Contact')]"));
        public IWebElement NewReleasePopupWindow => _driver.FindElement(By.XPath("//*[@id=\"sysmsg-0\"]/div[2]"));
        public IWebElement NewReleasePopupCloseButton => _driver.FindElement(By.XPath("//*[@id=\"sysmsg-0\"]/div[1]/div[2]"));
        public IWebElement SalesAndMarketingTab => _driver.FindElement(By.XPath("//*[@id=\"grouptab-1\"]/div"));
        public IWebElement ContactsButton => _driver.FindElement(By.XPath("//*[@id=\"left-sidebar\"]/div[3]/a"));
    }

    // Page object class for the Contacts page
    public class Contacts
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        // Constructor to initialize the WebDriver and WebDriverWait
        public Contacts(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        // Web elements on the Contacts page (to be specified)
        public IWebElement SearchInContactsField => _driver.FindElement(By.XPath(""));

    }


    public class CreateContactPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        // Constructor to initialize the WebDriver and WebDriverWait
        public CreateContactPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        // Web elements on the Contacts page (empty ones to be specified)
        public IWebElement ContactFirstNameField => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("DetailFormfirst_name-input")));
        public IWebElement ContactLastNameField => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("DetailFormlast_name-input")));
        public IWebElement BusinessRoleDropdown => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("DetailFormbusiness_role-input")));
        public IWebElement BusinessRoleDropdownOptionCEO => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='input-field input-field-group rbullet' and @tabindex='1']")));
        public IWebElement CategoryDropdownOptionCustomers => _driver.FindElement(By.XPath(""));
        public IWebElement CategoryDropdownOptionSuppliers => _driver.FindElement(By.XPath(""));
        public IWebElement SaveContactButton => _driver.FindElement(By.XPath(""));
        public IWebElement DisplayedNameField => _driver.FindElement(By.XPath(""));
    }
}

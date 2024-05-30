using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.IO;
using CRMTests.Variables;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace CRMTests.Hooks
{
    [Binding]
    public class Hooks
    {
        // Static property to hold the WebDriver instance
        public static IWebDriver Driver { get; set; }

        // Static property to hold configuration settings
        public static ConfigSettings Config { get; set; }

        // Directory path for configuration files
        static string ConfigDirectory = Path.Combine(AppContext.BaseDirectory, "Configuration");

        [BeforeTestRun]
        public static void BeforeTestRun()

        {
            // ConfigSettings instance initialization
            Config = new ConfigSettings();
            // Configuration builder to read configuration files
            ConfigurationBuilder builder = new ConfigurationBuilder();
            // Adding of configuration files
            builder.SetBasePath(ConfigDirectory);
            builder.AddJsonFile("Browser.json");
            builder.AddJsonFile("LoginCreds.json");
            builder.AddJsonFile("NewContactData.json");
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(Config);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}


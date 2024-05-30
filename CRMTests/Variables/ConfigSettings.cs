using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTests.Variables
{
    public class ConfigSettings
    {
        // Properties to store configuration values
        public string BrowserType { get; set; }
        public string LogLevel { get; set; }
        public string BaseUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ContactFirstname { get; set; }
        public string ContactLastname { get; set; }

    }
}

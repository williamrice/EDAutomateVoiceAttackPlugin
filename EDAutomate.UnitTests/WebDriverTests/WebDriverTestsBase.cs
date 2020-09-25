using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAutomate.UnitTests
{
    public class WebDriverTestsBase : MockTestBase
    {
        public string ChromeDriverPath { get; } = @"C:\ChromeDriver";
        public IWebDriver ChromeDriver { get; set; }

        public WebDriverTestsBase()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            ChromeDriver = new ChromeDriver(ChromeDriverPath, chromeOptions);

            WebDriverService.SetupProperty(x => x.Driver, ChromeDriver);
            WebDriverService.Setup(x => x.GetDriver()).Returns(ChromeDriver);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace EDAutomate
{
    public class WebDriverHandler
    {

        private static string ChromeDriverPath { get; } = @".\Apps\ED Automate\drivers\";
        
        private static IWebDriver driver = null;

        private static IWebDriver GetDriver()
        {

            if (driver == null)
            {
              driver = new ChromeDriver(ChromeDriverPath);
            }
            return driver;
        }
        public static void OpenInara<T>(dynamic vaProxy, string url, string vaVarName, string lastKnownSystem = "sol") where T : Enum
        {
            vaProxy.WriteToLog($"{ChromeDriverPath}", "orange");
            Enum? _addUrlEnd = EnumParser.ParseStringToEnum<T>(vaProxy, vaVarName, typeof(T));

            if (_addUrlEnd == null)
            {
                vaProxy.WriteToLog($"An error occurred. Parsed value is null", "red");
                return;
            }

            try
            {
                try
                {
                    _ = driver.Url;
                }
                catch (Exception)
                {
                    driver = null;
                }

                driver = GetDriver();
                

                try
                {
                    driver.Url = url + Convert.ToInt32(_addUrlEnd);
                }
                catch (Exception)
                {
                    vaProxy.WriteToLog($"ERROR: Could not connect to the webdriver, Check your network connection and try again", "red");
                }
                if (typeof(T) == typeof(Commodities.Commodity))
                {
                    var starSystemSearch = driver.FindElement(By.XPath("//*[@id=\"autocompletestar\"]"));

                    starSystemSearch.SendKeys(lastKnownSystem);
                    Thread.Sleep(2000);
                    starSystemSearch.SendKeys(Keys.Enter);

                    if (vaProxy.GetText("buyorsell") == "buy")
                    {
                        var exports = driver.FindElement(By.XPath("//*[@id=\"ui-id-9\"]"));
                        exports.Click();
                    }
                }

                vaProxy.SetBoolean("webDriverSuccess", true);
            }
            catch (Exception e)
            {
                DisplayWebDriverError(vaProxy, e);
                return;
            }
        }

        private static void DisplayWebDriverError(dynamic vaProxy, Exception e)
        {
            vaProxy.WriteToLog($"{e.Message} : An error occurred in the web driver", "red");
            vaProxy.WriteToLog($"{e.StackTrace}", "red");
            return;
        }

    }
}

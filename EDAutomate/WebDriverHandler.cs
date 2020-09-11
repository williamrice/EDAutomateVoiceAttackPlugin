using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using EliteJournalReader;
using EliteJournalReader.Events;
using System.Drawing.Text;

namespace EDAutomate
{
    public class WebDriverHandler
    {
        private static IWebDriver driver = null;

        

        private static IWebDriver GetDriver()
        {
            
            if (driver == null)
            {
               driver = new ChromeDriver();
            }
            return driver;
        }
        public static void OpenInaraToCheckPrices(string lastKnownSystem, dynamic vaProxy)
        {
            Commodities.Commodity _commodity = ParseCommoditiesVariable(vaProxy);
            vaProxy.WriteToLog($"{_commodity}", "pink");

             
            try
            {
                try
                {
                    _ = driver.Url;
                }
                catch (Exception e)
                {
                driver = null;
                }
                
                driver = GetDriver();


                try
                {
                    driver.Url = "https://inara.cz/galaxy-commodity/" + (int)_commodity;
                }
                catch (Exception e)
                {
                    vaProxy.WriteToLog($"ERROR: Could not connect to the webdriver, Check your network connection and try again", "red");
                }
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
            catch (Exception e)
            {
                //DisplayWebDriverError(vaProxy, e);
                return;
            }
        }

        private static void DisplayWebDriverError(dynamic vaProxy, Exception e)
        {
            vaProxy.WriteToLog($"{e.Message} : Chromedriver Error, make sure its installed", "red");
            vaProxy.WriteToLog($"{e.StackTrace}", "red");
            return;
        }

        public static void OpenInaraToCheckEngineer(dynamic vaProxy)
        {
           try
            {
                int? _engineer = vaProxy.GetInt("engineerVariable");
                driver = GetDriver();
                driver.Url = "https://inara.cz/galaxy-engineer/" + _engineer;
            }
            catch (Exception e)
            {
                DisplayWebDriverError(vaProxy, e);
            }
        }



        private static Commodities.Commodity ParseCommoditiesVariable(dynamic vaProxy)
        {
            Commodities.Commodity result;
            string incoming = vaProxy.GetText("commodityName");
            string comm = incoming.Replace(" ", "").Replace("-", "");
            vaProxy.WriteToLog($"{comm} from inside parse", "purple");
            
            _ = Enum.TryParse<Commodities.Commodity>(comm,true, out result);
            return result;
        }
    }
}

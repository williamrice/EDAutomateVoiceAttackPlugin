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
        private static IWebDriver driver;

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

            //TODO: make this cleaner and more reliable. 
            try
            {
                driver = GetDriver();
                if (_commodity == Commodities.Commodity.ParseError)
                {
                    vaProxy.WriteToLog($"There was an error parsing the commodity type {(int)_commodity}", "red");
                }
                driver.Url = "https://inara.cz/galaxy-commodity/" + (int)_commodity;
                var starSystemSearch = driver.FindElement(By.XPath("//*[@id=\"autocompletestar\"]"));

                starSystemSearch.SendKeys(lastKnownSystem);
                Thread.Sleep(2000);
                var searchButton = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div[1]/div[2]/form/div[3]/div/input"));
                searchButton.Click();
            }
            catch (Exception e)
            {
                DisplayWebDriverError(vaProxy, e);
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
            var comm = vaProxy.GetText("commoditiesVariable");

            switch (comm)
            {
                case "void opal":
                    return Commodities.Commodity.VoidOpal;
                case "painite":
                    return Commodities.Commodity.Painite;
                case "ltd":
                    return Commodities.Commodity.LTD;
                default:
                    return Commodities.Commodity.ParseError;
            }
        }
    }
}

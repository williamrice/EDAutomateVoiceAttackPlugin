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

namespace EDAutomate
{
    public class WebDriverHandler
    {
        
        public static void OpenInaraToCheckVoidOpalPrices(string lastKnownSystem, dynamic vaProxy)
        {
            
            
            
            IWebDriver driver;
            //TODO: Handle the error that is going to pop up if the user doesn't have the chrome driver installed. 
            try
            {
                driver = new ChromeDriver();
            }
            catch (Exception e)
            {
                vaProxy.WriteToLog($"{e.Message} : You probably don't have chromedriver installed", "red");
                return;
            }
            
            driver.Url = "https://inara.cz/galaxy-commodity/10250";
            var starSystemSearch = driver.FindElement(By.XPath("//*[@id=\"autocompletestar\"]"));

            starSystemSearch.SendKeys(lastKnownSystem);
            Thread.Sleep(2000);
            var searchButton = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div[1]/div[2]/form/div[3]/div/input"));
            searchButton.Click();
        }

    }
}

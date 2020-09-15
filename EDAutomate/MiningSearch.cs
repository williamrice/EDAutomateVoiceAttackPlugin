using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDAutomate
{
    class MiningSearch
    {
        private const string URL = "https://edtools.cc/miner";
        private const string REFSYSTEMXPATH = "//*[@id=\"ref_sys\"]";
        private const string PAINITEBUTTONXPATH = "//*[@id=\"btn_painite\"]";
        private const string LTDBUTTONXPATH = "//*[@id=\"btn_ltd\"]";
        private const string VOIDOPALSBUTTONXPATH = "//*[@id=\"btn_vop\"]";
        private const string BENITOITEBUTTONXPATH = "//*[@id=\"btn_ben\"]";
        private const string SERENDIBITEBUTTONXPATH = "//*[@id=\"btn_ser\"]";
        private const string MUSGRAVITEBUTTONXPATH = "//*[@id=\"btn_mus\"]";

        private static string TargetPath { get; set; }

        public static void SearchForMiningData(IWebDriver driver, dynamic vaProxy, string lastKnownSystem = "sol")
        {
            try
            {
                
                //vaProxy.WriteToLog($"{URL} - {driver.GetHashCode()}", "red");
                driver.Url = URL;
                Thread.Sleep(1200);
                vaProxy.WriteToLog($"{URL} - {driver.GetHashCode()}", "red");
                var refInput = driver.FindElement(By.XPath(REFSYSTEMXPATH));
                Thread.Sleep(500);
                refInput.SendKeys(lastKnownSystem);
                Thread.Sleep(500);
            }
            catch (Exception)
            {

                vaProxy.WriteToLog("Error: Unable to find the ref system input", "red");
            }

            try
            {
                string? mineral = vaProxy.GetText("miningVariable");
                switch (mineral.ToLower().Replace(" ", ""))
                {
                    case "painite":
                        TargetPath = PAINITEBUTTONXPATH;
                        break;
                    case "voidopals":
                        TargetPath = VOIDOPALSBUTTONXPATH;
                        break;
                    case "benitoite":
                        TargetPath = BENITOITEBUTTONXPATH;
                        break;
                    case "serendibite":
                        TargetPath = SERENDIBITEBUTTONXPATH;
                        break;
                    case "musgravite":
                        TargetPath = MUSGRAVITEBUTTONXPATH;
                        break;
                    default:
                        TargetPath = LTDBUTTONXPATH;
                        break;
                }
                Thread.Sleep(500);
                var target = driver.FindElement(By.XPath(TargetPath));
                Thread.Sleep(500);
                target.Click();
                Thread.Sleep(500);

                vaProxy.SetBoolean("webDriverSuccess", true);

            }
            catch (Exception)
            {
                vaProxy.WriteToLog("Error: Unable to find button for requested mineral", "red");
            }
        }



    }
}

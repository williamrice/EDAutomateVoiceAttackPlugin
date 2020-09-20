/*
 * Copyright 2020 Billy Rice. All rights reserved.
 */

using EDAutomate.Enums;
using EDAutomate.Utilities;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace EDAutomate.Services
{
    class MiningSearchService
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

        /// <summary>
        /// This function opens a web browser and searches for the specified mining mineral on edtools.cc/miner
        /// </summary>
        /// <param name="driver">The webdriver used to display the webpage</param>
        /// <param name="vaProxy">The VoiceAttackProxy object</param>
        /// <param name="lastKnownSystem">The last known system that you want to search for as the reference system</param>
        public static void SearchForMiningData(IWebDriver driver, VoiceAttackProxy vaProxy, string lastKnownSystem = "sol")
        {
            try
            {
                driver.Url = URL;
                Thread.Sleep(1200);
                var refInput = driver.FindElement(By.XPath(REFSYSTEMXPATH));
                Thread.Sleep(500);
                refInput.SendKeys(lastKnownSystem);
                Thread.Sleep(500);
            }
            catch (Exception)
            {
                vaProxy.WriteToLog("Error: Unable to find the ref system input", LogColors.LogColor.red);
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
                vaProxy.WriteToLog("Error: Unable to find button for requested mineral", LogColors.LogColor.red);
            }
        }



    }
}

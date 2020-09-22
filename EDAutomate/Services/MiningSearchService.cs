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
        
        private static string TargetPath { get; set; }

        /// <summary>
        /// This function opens a web browser and searches for the specified mining mineral on edtools.cc/miner
        /// </summary>
        /// <param name="driver">The webdriver used to display the webpage</param>
        /// <param name="vaProxy">The VoiceAttackProxy object</param>
        /// <param name="lastKnownSystem">The last known system that you want to search for as the reference system</param>
        public static void SearchForMiningData(IWebDriver driver, VoiceAttackProxy vaProxy, string lastKnownSystem)
        {
            try
            {
                driver.Url = Constants.MiningSearchUrl;
                Thread.Sleep(1200);
                var refInput = driver.FindElement(By.XPath(Constants.MiningReferenceSystemXPath));
                Thread.Sleep(500);
                refInput.SendKeys(lastKnownSystem);
                Thread.Sleep(500);
            }
            catch (Exception)
            {
                vaProxy.WriteToLog(Constants.ErrorMessageMiningSearchRefSystemInputLocatorFailed, LogColors.LogColor.red);
            }

            try
            {
                string? mineral = vaProxy.GetText(Constants.VoiceAttackMiningVariable);
                switch (mineral.ToLower().Replace(" ", ""))
                {
                    case "painite":
                        TargetPath = Constants.MiningPainiteButtonXPath;
                        break;
                    case "voidopals":
                        TargetPath = Constants.MiningVoidOpalButtonXPath;
                        break;
                    case "benitoite":
                        TargetPath = Constants.MiningBenitoiteButtonXPath;
                        break;
                    case "serendibite":
                        TargetPath = Constants.MiningSerendibiteButtonXPath;
                        break;
                    case "musgravite":
                        TargetPath = Constants.MiningMusgraviteButtonXPath;
                        break;
                    default:
                        TargetPath = Constants.MiningLtdButtonXPath;
                        break;
                }
                Thread.Sleep(500);
                var target = driver.FindElement(By.XPath(TargetPath));
                Thread.Sleep(500);
                target.Click();
                Thread.Sleep(500);

                vaProxy.SetBoolean(Constants.VoiceAttackWebDriverSuccessVariable, true);

            }
            catch (Exception)
            {
                vaProxy.WriteToLog(Constants.ErrorMessageMiningSearchButtonFailed, LogColors.LogColor.red);
            }
        }



    }
}

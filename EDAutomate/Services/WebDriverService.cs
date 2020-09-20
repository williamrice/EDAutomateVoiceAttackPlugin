/*
 * Copyright 2020 Billy Rice. All rights reserved.
 */

using EDAutomate.Enums;
using EDAutomate.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace EDAutomate.Services
{
    public class WebDriverService
    {
        private const string FINDMODULEXPATH = "//*[@id=\"s2id_autogen3\"]";
        private const string DROPDOWNXPATH = "//*[@id=\"select2-chosen-17\"]";
        private const string REFERENCESYSTEMXPATH = "//*[@id=\"s2id_autogen17_search\"]";

        private static string ChromeDriverPath { get; } = @".\Apps\ED Automate\drivers\";

        private static IWebDriver driver = null;
        /// <summary>
        /// Instantiates a new ChromeDriver. Only allows a singleton for the field driver
        /// </summary>
        /// <returns>Returns a new ChromeDriver object</returns>
        private static IWebDriver GetDriver()
        {

            if (driver == null)
            {
                driver = new ChromeDriver(ChromeDriverPath);
            }
            return driver;
        }
        /// <summary>
        /// Opens Inara in a webdriver browser and searches for the specified T criteria. Will automatically put in the fields to search for and the last known system the player exited supercruise at 
        /// </summary>
        /// <typeparam name="T">The enum that you are searching for</typeparam>
        /// <param name="vaProxy">VoiceAttackProxy object</param>
        /// <param name="url">The url that you want the webdriver to open</param>
        /// <param name="vaVarName">The voice attack variable that you want to be parsed to match T</param>
        /// <param name="lastKnownSystem">The last known system that the player exited supercruise at if available(Defaults to Sol)</param>
        public static void OpenInara<T>(VoiceAttackProxy vaProxy, string url, string vaVarName, string lastKnownSystem) where T : Enum
        {

            Enum? _addUrlEnd = EnumParser.ParseStringToEnum<T>(vaProxy, vaVarName, typeof(T));

            if (_addUrlEnd == null)
            {
                vaProxy.WriteToLog($"An error occurred. Parsed value is null", LogColors.LogColor.red);
                return;
            }

            try
            {
                /*Current workaround if the user closes the spawned webdriver or web browser window. This slows down the application as it has to wait on a time out exception
                 * to be throw in order to set the driver to null therefore allowing the GetDriver method to return a new ChromeDriver. This is the only way I can currently enforce
                 * driver to be a singleton in order to prevent the plugin from opening multiple chrome windows each time that a command is ran.
                */
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
                    vaProxy.WriteToLog($"ERROR: Could not connect to the webdriver, Check your network connection and try again", LogColors.LogColor.red);
                }

                if (typeof(T) == typeof(Modules.Module))
                {
                    try
                    {
                        var name = driver.FindElement(By.CssSelector("body > div.maincon > div.containermain > div.maincontentcontainer > div.maincontent1 > div:nth-child(2) > a > span"));
                        var module_name = name.Text;
                        var input = driver.FindElement(By.CssSelector("body > div.maincon > div.containermain > div.maincontentcontainer > div.sidecontent1 > div.mainblock.searchblock.withoverflow > form > div:nth-child(2) > div > div > div > ul.TokensContainer.Autosize > li.TokenSearch > input"));
                        Thread.Sleep(2000);
                        input.SendKeys(module_name);

                        var webElements = driver.FindElements(By.TagName("li"));

                        foreach (var element in webElements)
                        {
                            if (element.Text == module_name)
                            {
                                element.Click();
                            }
                        }

                        var near = driver.FindElement(By.XPath("//*[@id=\"autocompletestar\"]"));
                        near.Clear();
                        near.SendKeys(lastKnownSystem);
                        Thread.Sleep(1000);
                        near.SendKeys(Keys.Enter);

                        var submit = driver.FindElement(By.CssSelector("body > div.maincon > div.containermain > div.maincontentcontainer > div.sidecontent1 > div.mainblock.searchblock.withoverflow > form > div.formelement > input[type=submit]"));
                        submit.Click();
                    }
                    catch (Exception)
                    {
                        vaProxy.WriteToLog($"An error occurred looking up the module", LogColors.LogColor.red);
                    }
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

        /// <summary>
        /// Searches for the specified mineral from the Voice AttackCommand which in return displays the page in the webdriver browser
        /// </summary>
        /// <param name="vaProxy">VoiceAttackProxy object</param>
        /// <param name="lastKnownSystem">The last known system of the user after supercruise exit</param>
        public static void OpenMinerTool(VoiceAttackProxy vaProxy, string lastKnownSystem)
        {
            try
            {
                _ = driver.Url;
            }
            catch (Exception)
            {
                driver = null;
            }

            try
            {
                driver = GetDriver();
                MiningSearchService.SearchForMiningData(driver, vaProxy, lastKnownSystem);
            }
            catch (Exception e)
            {
                DisplayWebDriverError(vaProxy, e);
            }
        }

        /// <summary>
        /// Prints out an error to Voice Attack log
        /// </summary>
        /// <param name="vaProxy">VoiceAttackProxy object</param>
        /// <param name="e">The exception thrown by the webdriver in order to retrieve the stack track and message</param>
        private static void DisplayWebDriverError(VoiceAttackProxy vaProxy, Exception e)
        {
            vaProxy.WriteToLog($"{e.Message} : An error occurred in the web driver", LogColors.LogColor.red);
            vaProxy.WriteToLog($"{e.StackTrace}", LogColors.LogColor.red);
            return;
        }


    }
}

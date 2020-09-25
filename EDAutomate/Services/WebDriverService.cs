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
        private static WebDriverService instance = null;
        private static readonly object padlock = new object();
        public static WebDriverService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new WebDriverService();
                    }
                    return instance;
                }
            }
        }
        public virtual string ChromeDriverPath { get; } = Constants.ChromeDriverPath;
        public virtual IWebDriver Driver { get; set; }

        public bool WasSuccessful { get; set; }


        public WebDriverService()
        {
            Driver = GetDriver();
        }
        /// <summary>
        /// Instantiates a new ChromeDriver. Only allows a singleton for the field driver
        /// </summary>
        /// <returns>Returns a new ChromeDriver object</returns>
        /// 
        public virtual IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                Driver = new ChromeDriver(ChromeDriverPath);
            }
            return Driver;
        }
        /// <summary>
        /// Opens Inara in a webdriver browser and searches for the specified T criteria. Will automatically put in the fields to search for and the last known system the player exited supercruise at 
        /// </summary>
        /// <typeparam name="T">The enum that you are searching for</typeparam>
        /// <param name="vaProxy">VoiceAttackProxy object</param>
        /// <param name="url">The url that you want the webdriver to open</param>
        /// <param name="vaVarName">The voice attack variable that you want to be parsed to match T</param>
        /// <param name="lastKnownSystem">The last known system that the player exited supercruise at if available(Defaults to Sol)</param>
        public bool OpenInara<T>(VoiceAttackProxy vaProxy, string url, string vaVarName, string lastKnownSystem) where T : Enum
        {
            Enum? _addUrlEnd = EnumParser.ParseStringToEnum<T>(vaProxy, vaVarName, typeof(T));

            if (_addUrlEnd == null)
            {
                vaProxy.WriteToLog($"An error occurred. Parsed value is null", LogColors.LogColor.red);
                return false;
            }
            try
            {

                /*Current workaround if the user closes the spawned webdriver or web browser window. This slows down the application as it has to wait on a time out exception
                 * to be throw in order to set the driver to null therefore allowing the GetDriver method to return a new ChromeDriver. This is the only way I can currently enforce
                 * driver to be a singleton in order to prevent the plugin from opening multiple chrome windows each time that a command is ran.
                */
                if (isBrowserClosed())
                {
                    Driver = null;
                }
                Driver = GetDriver();



                try
                {
                    if (typeof(T) == typeof(Ships.Ship))
                    {
                        var shipUrlPost = Constants.ShipSearchPreFix + Convert.ToInt32(_addUrlEnd);
                        Driver.Url = url + shipUrlPost;
                    }
                    else
                    {
                        Driver.Url = url + Convert.ToInt32(_addUrlEnd);
                    }

                }
                catch (Exception)
                {
                    vaProxy.WriteToLog($"ERROR: Could not connect to the webdriver, Check your network connection and try again", LogColors.LogColor.red);
                    return false;
                }

                if (typeof(T) == typeof(Modules.Module) || typeof(T) == typeof(Ships.Ship))
                {
                    try
                    {
                        var name = Driver.FindElement(By.CssSelector(Constants.ModuleNameCssSelector));
                        var module_name = name.Text;
                        var input = Driver.FindElement(By.CssSelector(Constants.ModuleShipInputCssSelector));
                        input.SendKeys(module_name);
                        Thread.Sleep(500);

                        if (typeof(T) == typeof(Ships.Ship))
                        {
                            input.SendKeys(Keys.Enter);
                        }
                        if (typeof(T) == typeof(Modules.Module))
                        {
                            var webElements = Driver.FindElements(By.TagName("li"));

                            foreach (var element in webElements)
                            {
                                if (element.Text.ToLower() == module_name.ToLower())
                                {
                                    element.Click();
                                }
                            }
                        }


                        var near = Driver.FindElement(By.XPath(Constants.ModuleShipNearestSystemInputXPath));

                        near.Clear();
                        near.SendKeys(lastKnownSystem);
                        near.SendKeys(Keys.Enter);

                        var submit = Driver.FindElement(By.CssSelector(Constants.ModuleShipSubmitButtonCssSelector));
                        submit.Click();

                    }
                    catch (Exception e)
                    {
                        vaProxy.WriteToLog($"An error occurred looking up the module", LogColors.LogColor.red);
                        vaProxy.WriteToLog($"{e.StackTrace}", LogColors.LogColor.pink);
                        vaProxy.WriteToLog($"{e.Message}", LogColors.LogColor.pink);
                        return false;
                    }
                }

                if (typeof(T) == typeof(Commodities.Commodity))
                {

                    var starSystemSearch = Driver.FindElement(By.XPath(Constants.CommodityStarSystemSearchXPath));

                    starSystemSearch.SendKeys(lastKnownSystem);

                    starSystemSearch.SendKeys(Keys.Enter);

                    if (vaProxy.GetText("buyorsell") == "buy")
                    {
                        var exports = Driver.FindElement(By.XPath(Constants.CommodityExportsButtonXPath));
                        exports.Click();
                    }
                }


                vaProxy.SetBoolean(Constants.VoiceAttackWebDriverSuccessVariable, true);
                return true;
            }
            catch (Exception e)
            {
                DisplayWebDriverError(vaProxy, e);
                return false;
            }
        }

        /// <summary>
        /// Searches for the specified mineral from the Voice AttackCommand which in return displays the page in the webdriver browser
        /// </summary>
        /// <param name="vaProxy">VoiceAttackProxy object</param>
        /// <param name="lastKnownSystem">The last known system of the user after supercruise exit</param>
        public bool OpenMinerTool(VoiceAttackProxy vaProxy, string lastKnownSystem)
        {
            try
            {
                _ = Driver.Url;
            }
            catch (Exception)
            {
                Driver = null;
            }

            try
            {
                Driver = GetDriver();
                return MiningSearchService.SearchForMiningData(Driver, vaProxy, lastKnownSystem);
            }
            catch (Exception e)
            {
                DisplayWebDriverError(vaProxy, e);
                return false;
            }
        }

        /// <summary>
        /// Prints out an error to Voice Attack log
        /// </summary>
        /// <param name="vaProxy">VoiceAttackProxy object</param>
        /// <param name="e">The exception thrown by the webdriver in order to retrieve the stack track and message</param>
        private void DisplayWebDriverError(VoiceAttackProxy vaProxy, Exception e)
        {
            vaProxy.WriteToLog($"{e.Message} : An error occurred in the web driver", LogColors.LogColor.red);
            vaProxy.WriteToLog($"{e.StackTrace}", LogColors.LogColor.red);
            return;
        }

        private bool isBrowserClosed()
        {
            try
            {
                _ = Driver.Url;
            }
            catch (WebDriverException)
            {
                return true;
            }
            return false;
        }


    }
}

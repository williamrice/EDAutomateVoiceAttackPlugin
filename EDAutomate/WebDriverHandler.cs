﻿using EDAutomate.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace EDAutomate
{
    public class WebDriverHandler
    {
        private const string FINDMODULEXPATH = "//*[@id=\"s2id_autogen3\"]"; 
        private const string DROPDOWNXPATH = "//*[@id=\"select2-chosen-17\"]"; 
        private const string REFERENCESYSTEMXPATH = "//*[@id=\"s2id_autogen17_search\"]";

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
            //vaProxy.WriteToLog($"{vaProxy.GetText(vaVarName)}", "orange");



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
                        vaProxy.WriteToLog($"An error occurred looking up the module", "red");
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

        public static void OpenEddb(dynamic vaProxy, string url, string vaVarName, string lastKnownSystem = "sol")
        {
            var moduleName = ModuleParser.ParseModuleName(vaProxy);

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
                    driver.Url = url;
                }
                catch (Exception)
                {
                    vaProxy.WriteToLog($"ERROR: Could not connect to the webdriver, Check your network connection and try again", "red");
                }

                try
                {

                    
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    driver.Url = "https://eddb.io/station";
                    Thread.Sleep(1000);
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(FINDMODULEXPATH)));

                    var input = driver.FindElement(By.XPath(FINDMODULEXPATH));


                    input.SendKeys(moduleName);

                    

                    Thread.Sleep(2000);
                    input.SendKeys(Keys.Enter);

                    try
                    {
                        var cookieButton = driver.FindElement(By.XPath("/html/body/div[1]/div/a[1]"));
                        cookieButton.Click();
                    }
                    catch (Exception)
                    {

                    }

                    Thread.Sleep(2000);
                   
                    try
                    {
                        var dropDownClick = driver.FindElement(By.XPath(DROPDOWNXPATH));
                        dropDownClick.Click();
                    }
                    catch (Exception)
                    {

                    }


                    Thread.Sleep(2000);
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(REFERENCESYSTEMXPATH)));
                    var refInput = driver.FindElement(By.XPath(REFERENCESYSTEMXPATH)); 
                    refInput.SendKeys(lastKnownSystem);
                    Thread.Sleep(2000);

                    refInput.SendKeys(Keys.Enter);

                    Thread.Sleep(1000);


                    
                    

                    var searchButton = driver.FindElement(By.XPath("//*[@id=\"btFindStations\"]"));
                    searchButton.Click();

                    vaProxy.SetBoolean("webDriverSuccess", true);
                }
                catch (Exception)
                {

                }
            }
            catch (Exception e)
            {
                DisplayWebDriverError(vaProxy, e);
                return;
            }
        }

        public static void OpenMinerTool(dynamic vaProxy, string lastKnownSystem)
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
            MiningSearch.SearchForMiningData(driver, vaProxy, lastKnownSystem);
        }

        private static void DisplayWebDriverError(dynamic vaProxy, Exception e)
        {
            vaProxy.WriteToLog($"{e.Message} : An error occurred in the web driver", "red");
            vaProxy.WriteToLog($"{e.StackTrace}", "red");
            return;
        }


    }
}

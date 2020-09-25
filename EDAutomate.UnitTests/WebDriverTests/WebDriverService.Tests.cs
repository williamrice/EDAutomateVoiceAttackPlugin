using EDAutomate.Enums;
using EDAutomate.Utilities;
using Moq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xunit;

namespace EDAutomate.UnitTests
{
    public class WebDriverService_Tests : WebDriverTestsBase
    {
        /*Fixed Url to hit in order to display a page we would expect the driver to hit in order to properly test the selectors. Appended numbers at the end of the url would
        * normally be added on by a parser from the derived command input. 
        */
        public const string ModuleSelectorTestUrl = Constants.ShipModuleUrl + "127286";
        public const string CommoditySelectorTestUrl = Constants.CommodityUrl + "42";
        public const string ShipSelectorTestUrl = Constants.ShipModuleUrl + Constants.ShipSearchPreFix + "31";

        [Theory]
        [InlineData(CommoditySelectorTestUrl, Constants.CommodityStarSystemSearchXPath)]
        [InlineData(CommoditySelectorTestUrl, Constants.CommodityExportsButtonXPath)]
        public void WebDriverShouldFindElementByXPathSelector_Tests(string url, string selector)
        {
            ChromeDriver.Url = url;
            Assert.True(ChromeDriver.FindElement(By.XPath(selector)).Displayed);
        }

        [Theory]
        [InlineData(ModuleSelectorTestUrl, Constants.ModuleNameCssSelector)]
        [InlineData(ModuleSelectorTestUrl, Constants.ModuleShipInputCssSelector)]
        [InlineData(ModuleSelectorTestUrl, Constants.ModuleShipSubmitButtonCssSelector)]
        [InlineData(ShipSelectorTestUrl, Constants.ModuleShipInputCssSelector)]
        [InlineData(ShipSelectorTestUrl, Constants.ModuleShipSubmitButtonCssSelector)]
        public void WebDriverShouldFindElementByCssSelector_Tests(string url, string selector)
        {
            ChromeDriver.Url = url;
            Assert.True(ChromeDriver.FindElement(By.CssSelector(selector)).Displayed);
        }

        [Theory]
        [InlineData("gold", "buy")]
        [InlineData("void opals", "sell")]
        public void OpenInaraForCommoditySearchShouldReturnTrueIfNoErrorsOccurred(string inputFromCommand, string buyOrSell)
        {
            Proxy.Setup(x => x.GetText(It.Is<string>(s => s == Constants.VoiceAttackCommodityVariable))).Returns(inputFromCommand);
            Proxy.Setup(x => x.GetText(It.Is<string>(s => s == Constants.VoiceAttackBuyOrSellVariable))).Returns(buyOrSell);
            Assert.True(WebDriverService.Object.OpenInara<Commodities.Commodity>(Proxy.Object, Constants.CommodityUrl, Constants.VoiceAttackCommodityVariable, "sol"));
        }
    }
}

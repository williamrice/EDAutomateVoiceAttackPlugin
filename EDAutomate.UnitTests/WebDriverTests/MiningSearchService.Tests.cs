using EDAutomate.Utilities;
using OpenQA.Selenium;
using Xunit;

namespace EDAutomate.UnitTests
{
    public class MiningSearchService_Tests : WebDriverTestsBase
    {
        [Theory]
        [InlineData(Constants.MiningBenitoiteButtonXPath)]
        [InlineData(Constants.MiningVoidOpalButtonXPath)]
        [InlineData(Constants.MiningLtdButtonXPath)]
        public void MiningSearchWebElementShouldBeFoundByXPathSelector_Tests(string selector)
        {
            ChromeDriver.Url = Constants.MiningSearchUrl;
            Assert.True(ChromeDriver.FindElement(By.XPath(selector)).Displayed);
        }
    }
}

namespace EDAutomate.Utilities
{
    public static class Constants
    {
        //Voice Attack Constants

        public const string DisplayName = "Ed Automate Plugin - V0.0.0.10alpha";

        public const string DisplayInfo = "Ed Automate automates input on popular third party Elite Dangerous programs as well as some built in voice commands for OVR Drop";

        //Elite Journal Constants
        public const string DefaultLastKnownSystem = "sol";
        public const string DefaultEliteDangerousJournalPath = @"Saved Games\Frontier Developments\Elite Dangerous";
        public const string UserProfileEnvVariable = "USERPROFILE";

        //Web Element Selector Constants
        public const string ShipSearchPreFix = "xship";
        public const string FindModuleXpath = "//*[@id=\"s2id_autogen3\"]";
        public const string ModulesDropDownXPath = "//*[@id=\"select2-chosen-17\"]";
        public const string ReferenceSystemXPath = "//*[@id=\"s2id_autogen17_search\"]";
        public const string ChromeDriverPath = @".\Apps\ED Automate\drivers\";
        public const string ModuleNameCssSelector = "body > div.maincon > div.containermain > div.maincontentcontainer > div.maincontent1 > div:nth-child(2) > a > span";
        public const string ModuleShipInputCssSelector = "body > div.maincon > div.containermain > div.maincontentcontainer > div.sidecontent1 > div.mainblock.searchblock.withoverflow > form > div:nth-child(2) > div > div > div > ul.TokensContainer.Autosize > li.TokenSearch > input";
        public const string ModuleShipNearestSystemInputXPath = "//*[@id=\"autocompletestar\"]";
        public const string ModuleShipSubmitButtonCssSelector = "body > div.maincon > div.containermain > div.maincontentcontainer > div.sidecontent1 > div.mainblock.searchblock.withoverflow > form > div.formelement > input[type=submit]";
        public const string CommodityStarSystemSearchXPath = "//*[@id=\"autocompletestar\"]";
        public const string CommodityExportsButtonXPath = "//*[@id=\"ui-id-9\"]";
        public const string MiningReferenceSystemXPath = "//*[@id=\"ref_sys\"]";
        public const string MiningPainiteButtonXPath = "//*[@id=\"btn_painite\"]";
        public const string MiningLtdButtonXPath = "//*[@id=\"btn_ltd\"]";
        public const string MiningVoidOpalButtonXPath = "//*[@id=\"btn_vop\"]";
        public const string MiningBenitoiteButtonXPath = "//*[@id=\"btn_ben\"]";
        public const string MiningSerendibiteButtonXPath = "//*[@id=\"btn_ser\"]";
        public const string MiningMusgraviteButtonXPath = "//*[@id=\"btn_mus\"]";

        //Voice Attack Variable Constants
        public const string VoiceAttackWebDriverSuccessVariable = "webDriverSuccess";
        public const string VoiceAttackCommodityVariable = "commodityName";
        public const string VoiceAttackEngineerVariable = "engineerVariable";
        public const string VoiceAttackModuleVariable = "moduleVariable";
        public const string VoiceAttackShipVariable = "shipVariable";
        public const string VoiceAttackMiningVariable = "miningVariable";

        //Voice Attack Context Constants
        public const string CommoditySearchContext = "commodity search";
        public const string EngineerSearchContext = "engineer search";
        public const string ModuleSearchContext = "module search";
        public const string MiningSearchContext = "mining search";
        public const string ShipSearchContext = "ship search";

        //URL Endpoint Constants
        public const string CommodityUrl = "https://inara.cz/galaxy-commodity/";
        public const string EngineerUrl = "https://inara.cz/galaxy-engineer/";
        public const string ShipModuleUrl = "https://inara.cz/galaxy-outfitting-stations/";
        public const string MiningSearchUrl = "https://edtools.cc/miner";

        //AutoUpdate Constants
        public const string EdAutomateAssemblyName = "EDAutomatePlugin";
        public const string UpdateXmlUrl = "https://raw.githubusercontent.com/lawen4cer/EDAutomateVoiceAttackPlugin/update/update.xml";
        public const string UpdateInstallationPath = @".\Apps";
        public const string OnExitMessageBoxText = "Voice attack will now restart to finish updating Ed Automate. If this update requires a profile swap (check the changelog), make sure you delete the old profile and re-import the new one included in the update! ";
        public const string OnExitMessageBoxTitle = "Restart Required";
        public const string VoiceAttackMainFormName = "frmMain";

        //Error Messages
        public const string ErrorMessageMiningSearchButtonFailed = "Error: Unable to find button for requested mineral";
        public const string ErrorMessageMiningSearchRefSystemInputLocatorFailed = "Error: Unable to find the ref system input";

    }
}
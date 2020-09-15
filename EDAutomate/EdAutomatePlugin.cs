using System;

namespace EDAutomate
{
    public class EdAutomatePlugin
    {

        public static readonly string COMMODITY_URL = "https://inara.cz/galaxy-commodity/";
        public static readonly string ENGINEER_URL = "https://inara.cz/galaxy-engineer/";
        public static readonly string MODULE_URL = "https://inara.cz/galaxy-outfitting-stations/";
        public static readonly string COMMODITY_VARIABLE = "commodityName";
        public static readonly string ENGINEER_VARIABLE = "engineerVariable";
        public static readonly string MODULE_VARIABLE = "moduleVariable";

        public static string VA_DisplayName()
        {
            return "Ed Automate Plugin - V0.0.0.6alpha";
        }

        public static string VA_DisplayInfo()
        {
            return "Ed Automate automates some external programs, useful in VR";
        }

        public static Guid VA_Id()
        {
            return new Guid("{3c78a069-2423-4b62-a841-ce4f832e61ab}");
        }

        static Boolean _stopVariableToMonitor = false;

        public static void VA_StopCommand()
        {
            _stopVariableToMonitor = true;
        }

        public static void VA_Init1(dynamic vaProxy)
        {
            AutoUpdate.CheckForUpdates(vaProxy);

            try
            {
                JournalWatcherService.Init(vaProxy);
                vaProxy.WriteToLog($"Listening for journal changes at {JournalWatcherService.JournalPath}", "orange");
            }
            catch (Exception e)
            {
                vaProxy.WriteToLog($"{e.StackTrace}", "orange");
                vaProxy.WriteToLog($"{e.Message}", "orange");
            }
        }

        public static void VA_Invoke1(dynamic vaProxy)
        {
            switch (vaProxy.Context)
            {
                case "commodity search":
                    vaProxy.WriteToLog($"DEBUG: Last known system: {JournalWatcherService.LastKnownSystem}", "orange");
                    WebDriverHandler.OpenInara<Commodities.Commodity>(vaProxy, COMMODITY_URL, COMMODITY_VARIABLE, JournalWatcherService.LastKnownSystem);
                    break;
                case "engineer search":
                    WebDriverHandler.OpenInara<Engineers.Engineer>(vaProxy, ENGINEER_URL, ENGINEER_VARIABLE);
                    break;
                case "module search":
                    WebDriverHandler.OpenInara<Modules.Module>(vaProxy, MODULE_URL, MODULE_VARIABLE, JournalWatcherService.LastKnownSystem);
                    break;
                case "mining search":
                    WebDriverHandler.OpenMinerTool(vaProxy, JournalWatcherService.LastKnownSystem);
                    break;
                default:
                    break;
            }
        }

        public static void VA_Exit1(dynamic vaProxy)
        {

        }
    }
}

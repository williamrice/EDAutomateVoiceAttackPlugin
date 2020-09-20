/*
 * Copyright 2020 Billy Rice. All rights reserved.
 */

using EDAutomate.Enums;
using EDAutomate.Services;
using EDAutomate.Utilities;
using System;

namespace EDAutomate
{
    /// <summary>
    /// 
    /// </summary>
    public class EdAutomatePlugin
    {
        public static readonly string COMMODITY_URL = "https://inara.cz/galaxy-commodity/";
        public static readonly string ENGINEER_URL = "https://inara.cz/galaxy-engineer/";
        public static readonly string MODULE_URL = "https://inara.cz/galaxy-outfitting-stations/";
        public static readonly string COMMODITY_VARIABLE = "commodityName";
        public static readonly string ENGINEER_VARIABLE = "engineerVariable";
        public static readonly string MODULE_VARIABLE = "moduleVariable";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string VA_DisplayName()
        {
            return Constants.DisplayName;
        }

        public static string VA_DisplayInfo()
        {
            return Constants.DisplayInfo;
        }

        public static Guid VA_Id()
        {
            return new Guid("{3c78a069-2423-4b62-a841-ce4f832e61ab}");
        }

        public static void VA_StopCommand()
        {
            _stopVariableToMonitor = true;
        }

        public static void VA_Init1(dynamic vaProxy)
        {
            var proxy = new VoiceAttackProxy(vaProxy);
            AutoUpdateService.CheckForUpdates(proxy);

            try
            {
                JournalWatcherService.Init(proxy);
                proxy.WriteToLog($"EDAutomate is listening for journal changes at {JournalWatcherService.JournalPath}", LogColors.LogColor.blue);
            }
            catch (Exception e)
            {
                proxy.WriteToLog($"{e.StackTrace}", LogColors.LogColor.red);
                proxy.WriteToLog($"{e.Message}", LogColors.LogColor.red);
            }
        }

        public static void VA_Invoke1(dynamic vaProxy)
        {
            var proxy = new VoiceAttackProxy(vaProxy);
            switch (vaProxy.Context)
            {
                case "commodity search":
                    WebDriverService.OpenInara<Commodities.Commodity>(proxy, COMMODITY_URL, COMMODITY_VARIABLE, JournalWatcherService.LastKnownSystem);
                    break;
                case "engineer search":
                    WebDriverService.OpenInara<Engineers.Engineer>(proxy, ENGINEER_URL, ENGINEER_VARIABLE, JournalWatcherService.LastKnownSystem);
                    break;
                case "module search":
                    WebDriverService.OpenInara<Modules.Module>(proxy, MODULE_URL, MODULE_VARIABLE, JournalWatcherService.LastKnownSystem);
                    break;
                case "mining search":
                    WebDriverService.OpenMinerTool(vaProxy, JournalWatcherService.LastKnownSystem);
                    break;
                default:
                    break;
            }
        }

        public static void VA_Exit1(dynamic vaProxy)
        {

        }

        static Boolean _stopVariableToMonitor = false;
    }
}

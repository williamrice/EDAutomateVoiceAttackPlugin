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
            var webDriverService = WebDriverService.Instance;
            var proxy = new VoiceAttackProxy(vaProxy);
            switch (vaProxy.Context)
            {
                case Constants.CommoditySearchContext:
                    _ = webDriverService.OpenInara<Commodities.Commodity>(proxy, Constants.CommodityUrl, Constants.VoiceAttackCommodityVariable, JournalWatcherService.LastKnownSystem);
                    break;
                case Constants.EngineerSearchContext:
                    _ = webDriverService.OpenInara<Engineers.Engineer>(proxy, Constants.EngineerUrl, Constants.VoiceAttackEngineerVariable, JournalWatcherService.LastKnownSystem);
                    break;
                case Constants.ModuleSearchContext:
                    _ = webDriverService.OpenInara<Modules.Module>(proxy, Constants.ShipModuleUrl, Constants.VoiceAttackModuleVariable, JournalWatcherService.LastKnownSystem);
                    break;
                case Constants.MiningSearchContext:
                    _ = webDriverService.OpenMinerTool(proxy, JournalWatcherService.LastKnownSystem);
                    break;
                case Constants.ShipSearchContext:
                    _ = webDriverService.OpenInara<Ships.Ship>(proxy, Constants.ShipModuleUrl, Constants.VoiceAttackShipVariable, JournalWatcherService.LastKnownSystem);
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

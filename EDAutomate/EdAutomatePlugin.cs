using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteJournalReader;
using EliteJournalReader.Events;

namespace EDAutomate
{
    public class EdAutomatePlugin
    {
        public static string VA_DisplayName()
        {
            return "Ed Automate Plugin - V1.0";
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
                case "void opal sell search":
                    vaProxy.WriteToLog($"DEBUG: Last known system: {JournalWatcherService.LastKnownSystem}", "orange");
                    WebDriverHandler.OpenInaraToCheckVoidOpalPrices(JournalWatcherService.LastKnownSystem, vaProxy);
                    break;
                case "focus on elite window":
                    FocusWindow.FocusOnEliteWindow(vaProxy);
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

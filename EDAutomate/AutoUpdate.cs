﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoUpdaterDotNET;
using System.Reflection;
using System.Diagnostics;

namespace EDAutomate
{
    class AutoUpdate
    {
        public static void CheckForUpdates(dynamic vaProxy)
        {
            //var myAssemblyName = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(e => e.Name == "EDAutomatePlugin").FirstOrDefault();
            //vaProxy.WriteToLog($"{myAssemblyName}", "red");
            Assembly.Load("EDAutomatePlugin");
            var myAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(e => e.GetName().Name == "EDAutomatePlugin").FirstOrDefault();
            //vaProxy.WriteToLog($"{myAssembly.GetName().Name}", "red");


            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Mandatory = true;

            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
            

            
            AutoUpdater.InstallationPath = @".\Apps";
            //vaProxy.WriteToLog($"{AutoUpdater.InstallationPath}", "red");

            AutoUpdater.Start("https://raw.githubusercontent.com/lawen4cer/EDAutomateVoiceAttackPlugin/update/update.xml", myAssembly);

        }

        private static void AutoUpdater_ApplicationExitEvent()
        {
            Environment.Exit(0);
        }
    }
}

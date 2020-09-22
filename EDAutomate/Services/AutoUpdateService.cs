/*
 * Copyright 2020 Billy Rice. All rights reserved.
 */

using AutoUpdaterDotNET;
using EDAutomate.Utilities;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EDAutomate.Services
{
    class AutoUpdateService
    {
        /// <summary>
        /// Compares versions on the EDAutomate plugin assembly and triggers an update message to the user if an update is available. 
        /// </summary>
        /// <param name="vaProxy">VoiceAttackProxy object</param>
        public static void CheckForUpdates(VoiceAttackProxy vaProxy)
        {
            Assembly.Load(Constants.EdAutomateAssemblyName);
            var myAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(e => e.GetName().Name == Constants.EdAutomateAssemblyName).FirstOrDefault();

            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Mandatory = true;
            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
            AutoUpdater.InstallationPath = Constants.UpdateInstallationPath;
            AutoUpdater.Start(Constants.UpdateXmlUrl, myAssembly);
        }

        private static void AutoUpdater_ApplicationExitEvent()
        {
            MessageBox.Show(Constants.OnExitMessageBoxText, Constants.OnExitMessageBoxTitle , MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            Application.OpenForms[Constants.VoiceAttackMainFormName].Close();
        }
    }
}

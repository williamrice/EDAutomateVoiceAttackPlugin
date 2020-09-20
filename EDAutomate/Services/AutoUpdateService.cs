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
            Assembly.Load("EDAutomatePlugin");
            var myAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(e => e.GetName().Name == "EDAutomatePlugin").FirstOrDefault();

            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Mandatory = true;
            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
            AutoUpdater.InstallationPath = @".\Apps";
            AutoUpdater.Start("https://raw.githubusercontent.com/lawen4cer/EDAutomateVoiceAttackPlugin/update/update.xml", myAssembly);
        }

        private static void AutoUpdater_ApplicationExitEvent()
        {
            MessageBox.Show("Voice attack will now restart to finish updating Ed Automate. This release includes profile changes! Make sure that you delete the old ED Automate Profile and re-import the new profile found in the Voice Attack Profile folder in the plugin after the restart", "Restart Required", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            Application.OpenForms["frmMain"].Close();
        }
    }
}

using EliteJournalReader;
using EliteJournalReader.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAutomate
{
    class JournalWatcherService
    {
        public static string JournalPath { get; set; } = System.IO.Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Saved Games\\Frontier Developments\\Elite Dangerous");
        public static string LastKnownSystem { get; set; } = "Sol";
        public static void Init(dynamic vaProxy)
        {
            JournalWatcher watcher = new JournalWatcher(JournalPath);
            
            watcher.GetEvent<SupercruiseExitEvent>()?.AddHandler((s, e) => {

                LastKnownSystem = e.StarSystem;
                vaProxy.WriteToLog($"DEBUG: {LastKnownSystem} after supercruise exit", "blue");
            });
            watcher.GetEvent<LoadGameEvent>()?.AddHandler((s,e) => vaProxy.WriteToLog($"{e.Commander} just logged into Elite", "blue"));

            watcher.StartWatching().Wait();

        }
    }
}

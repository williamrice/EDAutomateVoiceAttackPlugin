using EliteJournalReader;
using EliteJournalReader.Events;
using System;

namespace EDAutomate
{
    class JournalWatcherService
    {
        public static readonly string DEFAULT_LAST_SYSTEM = "sol";
        public static string JournalPath { get; set; } = System.IO.Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Saved Games\\Frontier Developments\\Elite Dangerous");
        public static string LastKnownSystem { get; set; } = DEFAULT_LAST_SYSTEM;
        public static void Init(dynamic vaProxy)
        {
            JournalWatcher watcher = new JournalWatcher(JournalPath);

            watcher.GetEvent<SupercruiseExitEvent>()?.AddHandler((s, e) =>
            {

                LastKnownSystem = e.StarSystem;
                vaProxy.WriteToLog($"DEBUG: {LastKnownSystem} after supercruise exit", "blue");
            });
            watcher.GetEvent<LoadGameEvent>()?.AddHandler((s, e) => vaProxy.WriteToLog($"{e.Commander} just logged into Elite", "blue"));

            watcher.StartWatching().Wait();

        }
    }
}

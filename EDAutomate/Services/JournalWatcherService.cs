/*
 * Copyright 2020 Billy Rice. All rights reserved.
 */

using EDAutomate.Utilities;
using EliteJournalReader;
using EliteJournalReader.Events;
using System;

namespace EDAutomate.Services
{
    class JournalWatcherService
    {
        public static string JournalPath { get; set; } = System.IO.Path.Combine(Environment.GetEnvironmentVariable(Constants.UserProfileEnvVariable), Constants.DefaultEliteDangerousJournalPath);
        public static string LastKnownSystem { get; set; }
        /// <summary>
        /// Sets up the journal watcher and registers events that you want to watch
        /// </summary>
        /// <param name="vaProxy">VoiceAttackProxy object</param>
        public static void Init(VoiceAttackProxy vaProxy)
        {
            LastKnownSystem = Constants.DefaultLastKnownSystem;
            JournalWatcher watcher = new JournalWatcher(JournalPath);

            watcher.GetEvent<SupercruiseExitEvent>()?.AddHandler((s, e) =>
            {
                LastKnownSystem = e.StarSystem;
            });

            watcher.StartWatching().Wait();

        }
    }
}

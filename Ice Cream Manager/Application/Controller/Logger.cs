/// <project> IceCreamManager </project>
/// <module> Logger </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using IceCreamManager.Model;

namespace IceCreamManager
{
    public static class Logger
    {
        private static DatabaseEntityFactory<LogEntry> LogEntryFactory = new DatabaseEntityFactory<LogEntry>();

        public static bool Log(LogEntryProperties LogEntryValues)
        {
            LogEntryValues.TimeStamp = DateTime.Now;
            LogEntryFactory.Create(LogEntryValues);
            return true;
        }

        public static bool Log(EntityType EntityType, int EntityID, ActionSource Source, ActionType Action, Outcome Outcome, int BatchFileLine)
        {
            return Log(EntityType, EntityID, EntityType.None, 0, Source, Action, Outcome, BatchFileLine);
        }

        public static bool Log(EntityType MainEntityType, int MainEntityID, EntityType SubEntityType, int SubEntityID, ActionSource Source, ActionType Action, Outcome Outcome, int BatchFileLine)
        {
            LogEntryProperties LogEntryValues = new LogEntryProperties();

            LogEntryValues.MainEntityType = MainEntityType;
            LogEntryValues.MainEntityID = MainEntityID;
            LogEntryValues.SubEntityType = SubEntityType;
            LogEntryValues.SubEntityID = SubEntityID;
            LogEntryValues.Source = Source;
            LogEntryValues.Action = Action;
            LogEntryValues.Outcome = Outcome;
            LogEntryValues.BatchFileLine = BatchFileLine;

            return Log(LogEntryValues);
        }
    }
}

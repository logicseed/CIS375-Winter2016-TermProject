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

        public static bool Log(LogEntryProperties logEntryValues)
        {
            logEntryValues.TimeStamp = DateTime.Now;
            LogEntryFactory.Create(logEntryValues);
            return true;
        }

        public static bool Log(EntityType entityType, int entityID, ActionSource source, ActionType action, Outcome outcome, int batchFileLine)
        {
            return Log(entityType, entityID, EntityType.None, 0, source, action, outcome, batchFileLine);
        }

        public static bool Log(EntityType mainEntityType, int mainEntityID, EntityType subEntityType, int subEntityID, ActionSource source, ActionType action, Outcome outcome, int batchFileLine)
        {
            LogEntryProperties LogEntryValues = new LogEntryProperties();

            LogEntryValues.MainEntityType = mainEntityType;
            LogEntryValues.MainEntityID = mainEntityID;
            LogEntryValues.SubEntityType = subEntityType;
            LogEntryValues.SubEntityID = subEntityID;
            LogEntryValues.Source = source;
            LogEntryValues.Action = action;
            LogEntryValues.Outcome = outcome;
            LogEntryValues.BatchFileLine = batchFileLine;

            return Log(LogEntryValues);
        }
    }
}

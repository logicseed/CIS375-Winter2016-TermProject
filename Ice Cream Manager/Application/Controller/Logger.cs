/// <project> IceCreamManager </project>
/// <module> Logger </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using IceCreamManager.Model;

namespace IceCreamManager.Controller
{
    public static class Logger
    {
        private static LogEntryFactory logEntryFactory = LogEntryFactory.Reference;

        public static bool Log(EntityType mainEntityType, int mainEntityID, EntityType subEntityType, int subEntityID, ActionSource source, ActionType action, Outcome outcome, int batchFileLine)
        {
            LogEntry logEntry = logEntryFactory.New();

            logEntry.MainEntityType = mainEntityType;
            logEntry.MainEntityID = mainEntityID;
            logEntry.SubEntityType = subEntityType;
            logEntry.SubEntityID = subEntityID;
            logEntry.Source = source;
            logEntry.Action = action;
            logEntry.Outcome = outcome;
            logEntry.BatchFileLine = batchFileLine;

            return logEntry.Save();
        }

        public static bool Log(EntityType mainEntityType, int mainEntityID, EntityType subEntityType, int subEntityID, ActionSource source, ActionType action, Outcome outcome)
        {
            return Log(mainEntityType, mainEntityID, subEntityType, subEntityID, source, action, outcome, 0);
        }

        public static bool Log(EntityType entityType, int entityID, ActionSource source, ActionType action, Outcome outcome, int batchFileLine)
        {
            return Log(entityType, entityID, EntityType.None, 0, source, action, outcome, batchFileLine);
        }

        public static bool Log(EntityType entityType, int entityID, ActionSource source, ActionType action, Outcome outcome)
        {
            return Log(entityType, entityID, EntityType.None, 0, source, action, outcome, 0);
        }

        public static bool LogBatch(EntityType mainEntityType, int mainEntityID, EntityType subEntityType, int subEntityID, ActionType action, Outcome outcome, int batchFileLine)
        {
            return Log(mainEntityType, mainEntityID, subEntityType, subEntityID, ActionSource.BatchFile, action, outcome, batchFileLine);
        }

        public static bool LogBatch(EntityType entityType, int entityID, ActionType action, Outcome outcome, int batchFileLine)
        {
            return Log(entityType, entityID, EntityType.None, 0, ActionSource.BatchFile, action, outcome, batchFileLine);
        }

        public static bool LogBatch(EntityType entityType, int entityID, ActionType action, Outcome outcome)
        {
            return Log(entityType, entityID, EntityType.None, 0, ActionSource.BatchFile, action, outcome, 0);
        }

        public static bool LogBatch(BatchFileType batchFileType, ActionType action, Outcome outcome)
        {
            return Log(EntityType.BatchFile, (int)batchFileType, EntityType.None, 0, ActionSource.BatchFile, action, outcome, 0);
        }

        
    }
}

/// <project> IceCreamManager </project>
/// <module> LogEntryFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    public class LogEntryFactory : DatabaseEntityFactory<LogEntry>
    {
        #region Singleton
        private static readonly LogEntryFactory SingletonInstance = new LogEntryFactory();
        public static LogEntryFactory Reference { get { return SingletonInstance; } }
        private LogEntryFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "MainEntityType,MainEntityID,SubEntityType,SubEntityID,ActionSource,ActionType,Outcome,BatchFileLine,DateLogged";

        protected override string DatabaseQueryColumnValuePairs(LogEntry logEntry)
            => $"MainEntityType = {(int)logEntry.MainEntityType},MainEntityID = {logEntry.MainEntityID},SubEntityType = {(int)logEntry.SubEntityType},SubEntityID = {logEntry.SubEntityID},ActionSource = {(int)logEntry.Source},ActionType = {(int)logEntry.Action},Outcome = {(int)logEntry.Outcome},BatchFileLine = {logEntry.BatchFileLine},DateLogged = '{logEntry.DateLogged.ToDatabase()}'";

        protected override string DatabaseQueryValues(LogEntry logEntry)
            => $"{(int)logEntry.MainEntityType},{logEntry.MainEntityID},{(int)logEntry.SubEntityType},{logEntry.SubEntityID},{(int)logEntry.Source},{(int)logEntry.Action},{(int)logEntry.Outcome},{logEntry.BatchFileLine},'{logEntry.DateLogged.ToDatabase()}'";

        protected override LogEntry MapDataRowToProperties(DataRow row)
        {
            LogEntry logEntry = new LogEntry();

            logEntry.ID = row.Col("ID");
            logEntry.MainEntityType = (EntityType)row.Col("MainEntityType");
            logEntry.MainEntityID = row.Col("MainEntityID");
            logEntry.SubEntityType = (EntityType)row.Col("SubEntityType");
            logEntry.SubEntityID = row.Col("SubEntityID");
            logEntry.Source = (ActionSource)row.Col("ActionSource");
            logEntry.Action = (ActionType)row.Col("ActionType");
            logEntry.Outcome = (Outcome)row.Col("Outcome");
            logEntry.BatchFileLine = row.Col("BatchFileLine");
            logEntry.DateLogged = row.Col<DateTime>("DateLogged");
            logEntry.InDatabase = true;
            logEntry.IsSaved = true;

            return logEntry;
        }
    }
}

/// <project> IceCreamManager </project>
/// <module> LogEntry </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    public class LogEntryProperties : DatabaseEntityProperties
    {
        public EntityType MainEntityType;
        public int MainEntityID;
        public EntityType SubEntityType = EntityType.None;
        public int SubEntityID = 0;
        public ActionSource Source;
        public ActionType Action;
        public Outcome Outcome;
        public int BatchFileLine;
        public DateTime TimeStamp;
    }

    public class LogEntry : DatabaseEntity
    {
        private LogEntryProperties LogEntryValues = new LogEntryProperties();

        public LogEntry()
        {
            ID = 0;
        }

        public LogEntry(int ID)
        {
            Load(ID);
        }

        public EntityType MainEntityType
        {
            get
            {
                return LogEntryValues.MainEntityType;
            }
            set
            {
                LogEntryValues.MainEntityType = value;
            }
        }

        // TODO: The properties need error checking.
        public int MainEntityID
        {
            get
            {
                return LogEntryValues.MainEntityID;
            }
            set
            {
                LogEntryValues.MainEntityID = value;
            }
        }

        public EntityType SubEntityType
        {
            get
            {
                return LogEntryValues.SubEntityType;
            }
            set
            {
                LogEntryValues.SubEntityType = value;
            }
        }

        public int SubEntityID
        {
            get
            {
                return LogEntryValues.SubEntityID;
            }
            set
            {
                LogEntryValues.SubEntityID = value;
            }
        }

        public ActionSource Source
        {
            get
            {
                return LogEntryValues.Source;
            }
            set
            {
                LogEntryValues.Source = value;
            }
        }

        public ActionType Action
        {
            get
            {
                return LogEntryValues.Action;
            }
            set
            {
                LogEntryValues.Action = value;
            }
        }

        public Outcome Outcome
        {
            get
            {
                return LogEntryValues.Outcome;
            }
            set
            {
                LogEntryValues.Outcome = value;
            }
        }

        public int BatchFileLine
        {
            get
            {
                return LogEntryValues.BatchFileLine;
            }
            set
            {
                LogEntryValues.BatchFileLine = value;
            }
        }

        public DateTime TimeStamp
        {
            get
            {
                return LogEntryValues.TimeStamp;
            }
            set
            {
                LogEntryValues.TimeStamp = value;
            }
        }

        protected override string TableName => "log_entry";

        protected override string CreateCommand =>
            $"INSERT INTO {TableName} " +
            $"(main_entity_type, main_entity_id, sub_entity_type, sub_entity_id, source, action, outcome, batch_file_line, timestamp) " +
            $"VALUES ({(int)MainEntityType},{MainEntityID},{(int)SubEntityType},{SubEntityID},{(int)Source},{(int)Action},{(int)Outcome},{BatchFileLine},'{TimeStamp.ToDatabase()}')";

        protected override string UpdateCommand =>
            $"UPDATE {TableName} " +
            $"SET (main_entity_type, main_entity_id, sub_entity_type, sub_entity_id, source, action, outcome, batch_file_line, timestamp) " +
            $"VALUES ({(int)MainEntityType},{MainEntityID},{(int)SubEntityType},{SubEntityID},{(int)Source},{(int)Action},{(int)Outcome},{BatchFileLine},'{TimeStamp.ToDatabase()}') " +
            $"WHERE id = {ID}";

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            LogEntryValues = (LogEntryProperties)EntityProperties;

            return true;
        }

        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            MainEntityType = (EntityType)ResultsTable.Row().Col("main_entity_type");
            MainEntityID = ResultsTable.Row().Col("main_entity_id");
            SubEntityType = (EntityType)ResultsTable.Row().Col("sub_entity_type");
            SubEntityID = ResultsTable.Row().Col("sub_entity_id");
            Source = (ActionSource)ResultsTable.Row().Col("source");
            Action = (ActionType)ResultsTable.Row().Col("action");
            Outcome = (Outcome)ResultsTable.Row().Col("outcome");
            BatchFileLine = ResultsTable.Row().Col("batch_file_line");
            TimeStamp = ResultsTable.Row().Col<DateTime>("timestamp");
            InDatabase = true;

            return true;
        }
    }
}

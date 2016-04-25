/// <project> IceCreamManager </project>
/// <module> LogEntryFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using System.Collections.Generic;
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

        protected override string TableName => "LogEntry";

        protected override string DatabaseQueryColumns()
            => "Message,DateLogged,Success";

        protected override string DatabaseQueryColumnValuePairs(LogEntry logEntry)
            => $"Message = '{logEntry.Message}', DateLogged = '{logEntry.DateLogged.ToDatabase()}', Success = {logEntry.Success.ToDatabase()}";

        protected override string DatabaseQueryValues(LogEntry logEntry)
            => $"'{logEntry.Message}','{logEntry.DateLogged.ToDatabase()}',{logEntry.Success.ToDatabase()}";

        protected override LogEntry MapDataRowToProperties(DataRow row)
        {
            LogEntry logEntry = new LogEntry();

            logEntry.ID = row.Col("ID");
            logEntry.Message = row.Col<string>("Message");
            logEntry.DateLogged = row.ColDateTime("DateLogged");
            logEntry.Success = row.Col<bool>("Success");
            logEntry.InDatabase = true;
            logEntry.IsSaved = true;

            return logEntry;
        }

        public DataTable FormatDataTable(DataTable dataTableToFormat = null)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("DateLogged", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("Message", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Success", typeof(bool)));

            if (dataTableToFormat == null) return dataTable;

            foreach (DataRow Row in dataTableToFormat.Rows)
            {
                DataRow RowToReturn = dataTable.NewRow();

                RowToReturn["ID"] = Row.Col("ID");
                RowToReturn["DateLogged"] = Row.Col<DateTime>("DateLogged");
                RowToReturn["Message"] = Row.Col<string>("Message");
                RowToReturn["Success"] = Row.Col<bool>("Success");

                dataTable.Rows.Add(RowToReturn);
            }

            return dataTable;
        }

        public DataTable GetDataTable(int maxEntries)
        {
            var ResultsTable = Database.Query($"SELECT * FROM {TableName} ORDER BY DateLogged DESC LIMIT {maxEntries}");
            return FormatDataTable(ResultsTable);
        }

        public DataTable GetUpdatedRows(DateTime lastUpdate, int maxEntries)
        {
            var ResultsTable = Database.Query($"SELECT * FROM {TableName} WHERE DateLogged > datetime('{lastUpdate.ToDatabase()}') LIMIT {maxEntries}");
            return FormatDataTable(ResultsTable);
        }

        protected override string SaveLogString(LogEntry entity)
        {
            return "#DONTLOGLOG#";
        }
    }
}

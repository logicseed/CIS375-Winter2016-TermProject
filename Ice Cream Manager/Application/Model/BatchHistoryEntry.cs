/// <project> IceCreamManager </project>
/// <module> BatchHistoryEntry </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    public class BatchHistoryEntry : DatabaseEntity
    {
        // ID is BatchFileType
        private int sequenceNumber;

        private DateTime dateUpdated;

        public int SequenceNumber
        {
            get
            {
                return sequenceNumber;
            }

            set
            {
                if (value < Requirement.MinNumber || value > Requirement.MaxNumber)
                    throw new ArgumentOutOfRangeException();

                sequenceNumber = value;
            }
        }

        public DateTime DateUpdated
        {
            get
            {
                return dateUpdated;
            }

            set
            {
                dateUpdated = value;
            }
        }

        protected override string TableName
                            => "batch_history";

        protected override string CreateCommand
            => ""; // New batch file types types should not be created through code.

        protected override string UpdateCommand
            => $"UPDATE {TableName} SET (number,date_updated) VALUES ({SequenceNumber},'{DateUpdated.ToDatabase()}') WHERE id = {ID}";

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            // New batch file types should not be created through code.
            return false;
        }

        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            SequenceNumber = ResultsTable.Row().Col("number");
            DateUpdated = ResultsTable.Row().Col<DateTime>("date_updated");

            return true;
        }
    }
}

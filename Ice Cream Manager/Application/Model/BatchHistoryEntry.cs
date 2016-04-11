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
        private string fileType;

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
                if (!IsNextSequenceNumber(value)) throw new BatchHistorySequenceException(Outcome.NotNextSequence);

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
                if (value.CompareTo(dateUpdated) < 0) throw new BatchHistoryDateUpdatedException(Outcome.DateEarlierThanPreviousFile);
                dateUpdated = value;
            }
        }

        protected override string TableName
                            => "BatchHistory";

        protected override string CreateCommand
            => "";

        protected override string UpdateCommand
            => $"UPDATE {TableName} SET DateUpdated = {DateUpdated.ToDatabase()} WHERE id = {ID}";

        public bool IsNextSequenceNumber(int newSequenceNumber)
        {
            int nextSequenceNumber;

            if (sequenceNumber == 9999) nextSequenceNumber = 1;
            else nextSequenceNumber = sequenceNumber++;

            if (newSequenceNumber == nextSequenceNumber) return true;
            return false;
        }

        public bool IsValidDateUpdated(DateTime newDateUpdated)
        {
            int dateIsBefore = -1;
            if (newDateUpdated.CompareTo(DateUpdated) == dateIsBefore) return false;
            return true;
        }

        // New batch file types types should not be created through code.
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

            SequenceNumber = ResultsTable.Row().Col("Number");
            DateUpdated = ResultsTable.Row().Col<DateTime>("DateUpdated");
            InDatabase = true;
            IsSaved = true;

            return true;
        }
    }
}

/// <project> IceCreamManager </project>
/// <module> BatchHistoryEntry </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;

namespace IceCreamManager.Model
{
    public class BatchHistoryEntry : DatabaseEntity
    {
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
                IsSaved = false;
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
                IsSaved = false;
            }
        }

        public BatchFileType FileType
        {
            get
            {
                return (BatchFileType)ID;
            }
        }

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
            if (newDateUpdated.Date.CompareTo(DateUpdated.Date) == dateIsBefore) return false;
            return true;
        }

        public override bool Save()
        {
            return BatchHistoryEntryFactory.Reference.Save(this);
        }
    }
}

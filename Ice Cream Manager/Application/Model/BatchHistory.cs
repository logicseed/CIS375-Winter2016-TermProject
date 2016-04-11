/// <project> IceCreamManager </project>
/// <module> BatchHistory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;

namespace IceCreamManager.Model
{
    public static class BatchHistory
    {
        private static DatabaseEntityFactory<BatchHistoryEntry> DatabaseBatchHistoryFactory = new DatabaseEntityFactory<BatchHistoryEntry>();
        private static DatabaseManager Database = DatabaseManager.Reference;

        public static int GetSequence(BatchFileType fileType)
        {
            BatchHistoryEntry BatchEntry = Load((int)fileType);
            return BatchEntry.SequenceNumber;
        }

        public static bool SetSequence(BatchFileType fileType, int sequenceNumber)
        {
            BatchHistoryEntry BatchEntry = Load((int)fileType);

            BatchEntry.SequenceNumber = sequenceNumber;
            return BatchEntry.Save();
        }

        public static bool IsValidSequence(BatchFileType fileType, int sequenceNumber)
        {
            BatchHistoryEntry BatchEntry = Load((int)fileType);

            return BatchEntry.IsNextSequenceNumber(sequenceNumber);
        }

        public static DateTime GetDateUpdated(BatchFileType fileType)
        {
            BatchHistoryEntry BatchEntry = Load((int)fileType);
            return BatchEntry.DateUpdated;
        }

        public static bool SetDateUpdated(BatchFileType fileType, DateTime dateUpdated)
        {
            BatchHistoryEntry BatchEntry = Load((int)fileType);

            BatchEntry.DateUpdated = dateUpdated;
            return BatchEntry.Save();
        }

        public static bool IsValidDateUpdated(BatchFileType fileType, DateTime dateUpdated)
        {
            BatchHistoryEntry BatchEntry = Load((int)fileType);

            return BatchEntry.IsValidDateUpdated(dateUpdated);
        }

        private static BatchHistoryEntry Load(int id)
        {
            return DatabaseBatchHistoryFactory.Load(id);
        }
    }
}

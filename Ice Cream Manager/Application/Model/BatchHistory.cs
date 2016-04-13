/// <project> IceCreamManager </project>
/// <module> BatchHistory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;

namespace IceCreamManager.Model
{
    public static class BatchHistory
    {
        private static BatchHistoryEntryFactory batchHistoryEntryFactory = BatchHistoryEntryFactory.Reference;

        public static int GetSequence(BatchFileType fileType)
        {
            BatchHistoryEntry batchHistoryEntry = batchHistoryEntryFactory.Load((int)fileType);
            return batchHistoryEntry.SequenceNumber;
        }

        public static bool SetSequence(BatchFileType fileType, int sequenceNumber)
        {
            BatchHistoryEntry batchHistoryEntry = batchHistoryEntryFactory.Load((int)fileType);
            batchHistoryEntry.SequenceNumber = sequenceNumber;
            return batchHistoryEntry.Save();
        }

        public static bool IsValidSequence(BatchFileType fileType, int sequenceNumber)
        {
            BatchHistoryEntry batchHistoryEntry = batchHistoryEntryFactory.Load((int)fileType);
            return batchHistoryEntry.IsNextSequenceNumber(sequenceNumber);
        }

        public static DateTime GetDateUpdated(BatchFileType fileType)
        {
            BatchHistoryEntry batchHistoryEntry = batchHistoryEntryFactory.Load((int)fileType);
            return batchHistoryEntry.DateUpdated;
        }

        public static bool SetDateUpdated(BatchFileType fileType, DateTime dateUpdated)
        {
            BatchHistoryEntry batchHistoryEntry = batchHistoryEntryFactory.Load((int)fileType);
            batchHistoryEntry.DateUpdated = dateUpdated;
            return batchHistoryEntry.Save();
        }

        public static bool IsValidDateUpdated(BatchFileType fileType, DateTime dateUpdated)
        {
            BatchHistoryEntry batchHistoryEntry = batchHistoryEntryFactory.Load((int)fileType);
            return batchHistoryEntry.IsValidDateUpdated(dateUpdated);
        }
    }
}

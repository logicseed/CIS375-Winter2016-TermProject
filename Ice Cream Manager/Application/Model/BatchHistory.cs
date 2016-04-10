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

        public static int GetSequence(BatchFileType FileType)
        {
            BatchHistoryEntry BatchEntry = Load((int)FileType);
            return BatchEntry.SequenceNumber;
        }

        public static bool SetSequence(BatchFileType FileType, int SequenceNumber)
        {
            BatchHistoryEntry BatchEntry = Load((int)FileType);

            BatchEntry.SequenceNumber = SequenceNumber;
            return BatchEntry.Save();
        }

        public static DateTime GetDateUpdated(BatchFileType FileType)
        {
            BatchHistoryEntry BatchEntry = Load((int)FileType);
            return BatchEntry.DateUpdated;
        }

        public static bool SetDateUpdated(BatchFileType FileType, DateTime DateUpdated)
        {
            BatchHistoryEntry BatchEntry = Load((int)FileType);

            BatchEntry.DateUpdated = DateUpdated;
            return BatchEntry.Save();
        }

        private static BatchHistoryEntry Load(int ID)
        {
            return DatabaseBatchHistoryFactory.Load(ID);
        }
    }
}

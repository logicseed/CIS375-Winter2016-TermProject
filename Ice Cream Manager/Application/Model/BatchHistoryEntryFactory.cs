using System;
using System.Data;

namespace IceCreamManager.Model
{
    class BatchHistoryEntryFactory : DatabaseEntityFactory<BatchHistoryEntry>
    {
        #region Singleton
        private static readonly BatchHistoryEntryFactory SingletonInstance = new BatchHistoryEntryFactory();
        public static BatchHistoryEntryFactory Reference { get { return SingletonInstance; } }
        private BatchHistoryEntryFactory() { }
        #endregion Singleton

        protected override string TableName => "BatchHistory";
        protected override string DatabaseQueryColumns()
            => "SequenceNumber,DateUpdated";

        protected override string DatabaseQueryColumnValuePairs(BatchHistoryEntry batchHistoryEntry)
            => $"SequenceNumber = {batchHistoryEntry.SequenceNumber},DateUpdate = '{batchHistoryEntry.DateUpdated.ToDatabase()}'";

        protected override string DatabaseQueryValues(BatchHistoryEntry batchHistoryEntry)
            => $"{batchHistoryEntry.SequenceNumber},{batchHistoryEntry.DateUpdated.ToDatabase()}";

        protected override BatchHistoryEntry MapDataRowToProperties(DataRow row)
        {
            BatchHistoryEntry batchHistoryEntry = new BatchHistoryEntry();

            batchHistoryEntry.ID = row.Col("ID");
            batchHistoryEntry.SequenceNumber = row.Col("SequenceNumber");
            batchHistoryEntry.DateUpdated = row.Col<DateTime>("DateUpdated");
            batchHistoryEntry.InDatabase = true;
            batchHistoryEntry.IsSaved = false;

            return batchHistoryEntry;
        }
    }
}

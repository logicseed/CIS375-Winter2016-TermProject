/// <project> IceCreamManager </project>
/// <module> BatchHistoryEntryFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Provides methods to load, edit, and create BatchHistoryEntry objects in the database. 
    /// </summary>
    public class BatchHistoryEntryFactory : DatabaseEntityFactory<BatchHistoryEntry>
    {
        #region Singleton

        public static BatchHistoryEntryFactory Reference { get { return SingletonInstance; } }
        private static readonly BatchHistoryEntryFactory SingletonInstance = new BatchHistoryEntryFactory();

        private BatchHistoryEntryFactory()
        {
        }

        #endregion Singleton

        #region Protected Properties

        /// <summary>
        ///   Name of the database table where BatchHistoryEntries are stored. Inherits most of its functionality. 
        /// </summary>
        protected override string TableName => "BatchHistory";

        #endregion Protected Properties

        #region Protected Methods

        /// <summary>
        ///   Names of the fields in the database table. 
        /// </summary>
        /// <returns></returns>
        protected override string DatabaseQueryColumns()
            => "SequenceNumber,DateUpdated";

        /// <summary>
        ///   Creates a string to build an SQL query for saving a BatchHistoryEntry. 
        /// </summary>
        /// <param name="batchHistoryEntry"> The BatchHistoryEntry to create the string for. </param>
        /// <returns> A string containing field-value pairs for use in SQL statements. </returns>
        protected override string DatabaseQueryColumnValuePairs(BatchHistoryEntry batchHistoryEntry)
            => $"SequenceNumber = {batchHistoryEntry.SequenceNumber},DateUpdate = '{batchHistoryEntry.DateUpdated.ToDatabase()}'";

        /// <summary>
        ///   Creates a string to build an SQL query for inserting a BatchHistoryEntry. 
        /// </summary>
        /// <param name="batchHistoryEntry"> The BatchHistoryEntry to create the string for. </param>
        /// <returns> A string containing field values for use in SQL statements. </returns>
        protected override string DatabaseQueryValues(BatchHistoryEntry batchHistoryEntry)
            => $"{batchHistoryEntry.SequenceNumber},{batchHistoryEntry.DateUpdated.ToDatabase()}";

        /// <summary>
        ///   Fills a BatchHistoryEntry with values from a database result row. 
        /// </summary>
        /// <param name="row"> The DataRow contains the values with which to fill the BatchHistoryEntry. </param>
        /// <returns> A BatchHistoryEntry instance filled with the values in the DataRow. </returns>
        protected override BatchHistoryEntry MapDataRowToProperties(DataRow row)
        {
            var batchHistoryEntry = new BatchHistoryEntry();

            batchHistoryEntry.ID = row.Col("ID");
            batchHistoryEntry.sequenceNumber = row.Col("SequenceNumber");
            batchHistoryEntry.DateUpdated = row.Col<DateTime>("DateUpdated");
            batchHistoryEntry.InDatabase = true;
            batchHistoryEntry.IsSaved = false;

            return batchHistoryEntry;
        }

        /// <summary>
        ///   The string used to log actions performed on a BatchHistoryEntry. This is here to fulfill requirements made
        ///   by DatabaseEntityFactory; changes made to the batch history are not logged here.
        /// </summary>
        protected override string SaveLogString(BatchHistoryEntry entry) => "";

        #endregion Protected Methods
    }
}

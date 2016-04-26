/// <project> IceCreamManager </project>
/// <module> BatchHistory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;

using IceCreamManager.Model;

namespace IceCreamManager
{
    /// <summary>
    ///   Provides methods to access and manipulate the batch file history. 
    /// </summary>
    public static class BatchHistory
    {
        #region Public Methods

        /// <summary>
        ///   Gets the last date a specified batch file type was updated. 
        /// </summary>
        /// <param name="fileType"> The batch file type. </param>
        /// <returns> A DateTime containing when the batch file type was last updated. </returns>
        public static DateTime GetDateUpdated(BatchFileType fileType)
        {
            var batchHistoryEntry = Factory.BatchHistory.Load((int)fileType);
            return batchHistoryEntry.DateUpdated;
        }

        /// <summary>
        ///   Gets the current sequence number of a specified batch file type. 
        /// </summary>
        /// <param name="fileType"> The batch file type. </param>
        /// <returns> The current sequence number. </returns>
        public static int GetSequence(BatchFileType fileType)
        {
            var batchHistoryEntry = Factory.BatchHistory.Load((int)fileType);
            return batchHistoryEntry.sequenceNumber;
        }

        /// <summary>
        ///   Checks if the specified DateTime is on or after the last update date of the specified batchfile type. 
        /// </summary>
        /// <param name="fileType"> The batch file type. </param>
        /// <param name="dateUpdated"> The date to check. </param>
        /// <returns> Whether or not the date is on or after the current batch file type update date. </returns>
        public static bool IsValidDateUpdated(BatchFileType fileType, DateTime dateUpdated)
        {
            var batchHistoryEntry = Factory.BatchHistory.Load((int)fileType);
            return batchHistoryEntry.IsValidDateUpdated(dateUpdated);
        }

        /// <summary>
        ///   Checks a provided sequence number for a specified batch file type to see if it is the next expected
        ///   sequence number.
        /// </summary>
        /// <param name="fileType"> The batch file type. </param>
        /// <param name="sequenceNumber"> The sequence number to check. </param>
        /// <returns> Whether or not the sequence number is the next sequence number. </returns>
        public static bool IsValidSequence(BatchFileType fileType, int sequenceNumber)
        {
            var batchHistoryEntry = Factory.BatchHistory.Load((int)fileType);
            return batchHistoryEntry.IsNextSequenceNumber(sequenceNumber);
        }

        /// <summary>
        ///   Sets the date that a specified batch file type was updated. 
        /// </summary>
        /// <param name="fileType"> The batch file type. </param>
        /// <param name="dateUpdated"> The date the batch file was updated. </param>
        /// <returns> Whether or not the batch file update date was set successfully. </returns>
        public static bool SetDateUpdated(BatchFileType fileType, DateTime dateUpdated)
        {
            var batchHistoryEntry = Factory.BatchHistory.Load((int)fileType);
            batchHistoryEntry.DateUpdated = dateUpdated;
            return batchHistoryEntry.Save();
        }

        /// <summary>
        ///   Sets the current sequence number of a specified batch file type. 
        /// </summary>
        /// <param name="fileType"> The batch file type. </param>
        /// <param name="sequenceNumber"> The sequence number. </param>
        /// <returns> Whether or not the set was successful. </returns>
        public static bool SetSequence(BatchFileType fileType, int sequenceNumber)
        {
            var batchHistoryEntry = Factory.BatchHistory.Load((int)fileType);
            batchHistoryEntry.sequenceNumber = sequenceNumber;
            return batchHistoryEntry.Save();
        }

        #endregion Public Methods
    }
}

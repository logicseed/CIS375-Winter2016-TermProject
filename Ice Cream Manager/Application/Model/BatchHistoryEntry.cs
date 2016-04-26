/// <project> IceCreamManager </project>
/// <module> BatchHistoryEntry </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Data access object representing the history of a batch file type.. 
    /// </summary>
    public class BatchHistoryEntry : DatabaseEntity
    {
        #region Public Properties

        /// <summary>
        ///   Provides public access to get and set the last date the batch file type was updated. 
        /// </summary>
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

        /// <summary>
        ///   Provides public access to get the batch file type. 
        /// </summary>
        public BatchFileType FileType
        {
            get
            {
                return (BatchFileType)ID;
            }
        }

        /// <summary>
        ///   Provides public access to get and set the current sequence number of the batch file type. 
        /// </summary>
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

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///   Checks if the provided number is the next sequence number for the batch file type. 
        /// </summary>
        /// <param name="newSequenceNumber"> The sequence number to check. </param>
        /// <returns> Whether or not the number is the next sequence number. </returns>
        public bool IsNextSequenceNumber(int newSequenceNumber)
        {
            int nextSequenceNumber;

            if (sequenceNumber == 9999) nextSequenceNumber = 1;
            else nextSequenceNumber = sequenceNumber++;

            if (newSequenceNumber == nextSequenceNumber) return true;
            return false;
        }

        /// <summary>
        ///   Checks if the provided DateTime is on or after the date the batch file type was last updated. 
        /// </summary>
        /// <param name="newDateUpdated"> The DateTime to check. </param>
        /// <returns> Whether or not the DateTime is on or after the date the batch file type was last updated. </returns>
        public bool IsValidDateUpdated(DateTime newDateUpdated)
        {
            var dateIsBefore = -1; // Output of CompareTo that indicates before.
            if (newDateUpdated.Date.CompareTo(DateUpdated.Date) == dateIsBefore) return false;
            return true;
        }

        /// <summary>
        ///   Saves any changes made to the batch file type history. 
        /// </summary>
        /// <returns> Whether or not saving the batch file type history was successful. </returns>
        public override bool Save()
        {
            return Factory.BatchHistory.Save(this);
        }

        #endregion Public Methods

        #region Private Fields

        /// <summary>
        ///   The last date the batch file type was updated. 
        /// </summary>
        private DateTime dateUpdated;

        /// <summary>
        ///   The current sequence number of the batch file type. 
        /// </summary>
        public int sequenceNumber;

        #endregion Private Fields
    }
}

/// <project> IceCreamManager </project>
/// <module> Logger </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using IceCreamManager.Model;

namespace IceCreamManager.Controller
{
    /// <summary>
    ///   Provides access to methods that allow a developer to log actions performed on the database. 
    /// </summary>
    public static class Log
    {
        #region Public Methods

        /// <summary>
        ///   Create a new log entry of a failed action. 
        /// </summary>
        /// <param name="message"> The message to log. </param>
        /// <returns> Whether or not the log entry was created successfully. </returns>
        public static bool Failure(string message)
        {
            return CreateLogEntry(message, false);
        }

        /// <summary>
        ///   Create a new log entry of a successful action. 
        /// </summary>
        /// <param name="message"> The message to log. </param>
        /// <returns> Whether or not the log entry was created successfully. </returns>
        public static bool Success(string message)
        {
            return CreateLogEntry(message, true);
        }

        #endregion Public Methods

        #region Private Fields

        /// <summary>
        ///   Provides access to the log entries in the database. 
        /// </summary>
        private static LogEntryFactory logEntryFactory = LogEntryFactory.Reference;

        #endregion Private Fields

        #region Private Methods

        /// <summary>
        ///   Creates a new log entry. 
        /// </summary>
        /// <param name="message"> The message to log. </param>
        /// <param name="wasSuccessful"> Whether or not a successful action is being logged. </param>
        /// <returns> Whether or not the log entry was created successfully. </returns>
        private static bool CreateLogEntry(string message, bool wasSuccessful = true)
        {
            var logEntry = Factory.Log.New();

            logEntry.Message = message;
            logEntry.DateLogged = DateTime.Now;
            logEntry.Success = wasSuccessful;

            Manage.Events.NewLogEntry();

            return logEntry.Save();
        }

        #endregion Private Methods
    }
}

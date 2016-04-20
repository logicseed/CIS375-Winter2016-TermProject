/// <project> IceCreamManager </project>
/// <module> Logger </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using IceCreamManager.Model;
using IceCreamManager.View;

namespace IceCreamManager.Controller
{
    public static class Log
    {
        private static LogEntryFactory logEntryFactory = LogEntryFactory.Reference;

        public static bool CreateLogEntry(string message, bool wasSuccessful = true)
        {
            var logEntry = Factory.Log.New();

            logEntry.Message = message;
            logEntry.DateLogged = DateTime.Now;
            logEntry.Success = wasSuccessful;

            Manage.Events.NewLogEntry();

            return logEntry.Save();
        }

        public static bool Success(string message)
        {
            return CreateLogEntry(message, true);
        }

        public static bool Failure(string message)
        {
            return CreateLogEntry(message, false);
        }
        
    }
}

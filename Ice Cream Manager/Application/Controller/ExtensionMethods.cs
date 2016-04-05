/// <project>IceCreamManager</project>
/// <module>ExtensionMethods</module>
/// <author>Marc King</author>
/// <date_created>2016-04-04</date_created>

using System;

namespace IceCreamManager.Controller
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Converts the DateTime to a SQLite datetime string for storing in the database.
        /// </summary>
        /// <remarks>
        /// See https://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx for explanation of
        /// dateTimeFormat string. See https://www.sqlite.org/datatype3.html Section 1.2 for
        /// an explanation of the datetime format expected by SQLite.
        /// </remarks>
        /// <preconditions>DateTime object exists.</preconditions>
        /// <postconditions>No changes made to DateTime object.</postconditions>
        /// <returns>A string with the DateTime in format expected by SQLite.</returns>
        public static string ToSQLite(this DateTime dateTime)
        {
            try
            {
                string dateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
                return dateTime.ToString(dateTimeFormat);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
            
        }
    }
}

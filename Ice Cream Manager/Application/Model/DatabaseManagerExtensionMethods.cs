/// <project> IceCreamManager </project>
/// <module> ExtensionMethods </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-04 </date_created>

using System;
using System.Data;
using System.Globalization;

namespace IceCreamManager.Model
{
    public static class ExtensionMethods
    {
        /// <summary>
        ///   Generic method to get the value in a column as a datatype ReturnType. 
        /// </summary>
        /// <typeparam name="ReturnType"> The datatype to return. </typeparam>
        /// <param name="dataRow"> The DataRow extended by this method. </param>
        /// <param name="name"> The key for the column to return. </param>
        /// <returns> The value in the column as a datatype. </returns>
        /// <exception cref="InvalidCastException" />
        public static ReturnType Col<ReturnType>(this DataRow dataRow, string name)
        {
            return (ReturnType)Convert.ChangeType(dataRow[name], typeof(ReturnType), CultureInfo.InvariantCulture);
        }

        public static DateTime ColDateTime(this DataRow dataRow, string name) 
        {
            DateTime convertedDateTime = new DateTime();
            DateTime.TryParse(dataRow[name].ToString(), out convertedDateTime);
            return convertedDateTime;
        }

        /// <summary>
        ///   Generic method to get the value in a column as a datatype ReturnType. 
        /// </summary>
        /// <typeparam name="ReturnType"> The datatype to return. </typeparam>
        /// <param name="dataRow"> The DataRow extended by this method. </param>
        /// <param name="index"> The index of the column to return. </param>
        /// <returns> The value in the column as a datatype. </returns>
        public static ReturnType Col<ReturnType>(this DataRow dataRow, int index = 0)
        {
            string Name = dataRow.Table.Columns[index].ColumnName;
            return dataRow.Col<ReturnType>(Name);
        }

        /// <summary>
        ///   Gets the value in a column as an integer. 
        /// </summary>
        /// <param name="dataRow"> The DataRow extended by this method. </param>
        /// <param name="name"> The key for the column to return. </param>
        /// <returns> The value in the column as an integer. </returns>
        public static int Col(this DataRow dataRow, string name)
        {
            return dataRow.Col<int>(name);
        }

        /// <summary>
        ///   Gets the value in a column as an integer. 
        /// </summary>
        /// <param name="dataRow"> The DataRow extended by this method. </param>
        /// <param name="index"> The index of the column to return. </param>
        /// <returns> The value in the column as an integer. </returns>
        public static int Col(this DataRow dataRow, int index = 0)
        {
            string Name = dataRow.Table.Columns[index].ColumnName;
            return dataRow.Col<int>(Name);
        }

        /// <summary>
        ///   Retrieves a DataRow from a DataTable by index; defaults to the first row. 
        /// </summary>
        /// <param name="dataTable"> The DataTable extended by this method. </param>
        /// <param name="index"> The index of the row to return. </param>
        /// <returns> The DataRow at the specified index. </returns>
        public static DataRow Row(this DataTable dataTable, int index = 0)
        {
            return dataTable.Rows[index];
        }

        /// <summary>
        ///   Converts the DateTime to a formatted string for storing in the database. 
        /// </summary>
        /// <remarks>
        ///   See https://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx for explanation of dateTimeFormat string. See
        ///   https://www.sqlite.org/datatype3.html Section 1.2 for an explanation of the datetime format expected by the database.
        /// </remarks>
        /// <preconditions> DateTime object exists. </preconditions>
        /// <postconditions> No changes made to DateTime object. </postconditions>
        /// <returns> A string with the DateTime in format expected by the database. </returns>
        public static string ToDatabase(this DateTime dateTime)
        {
            try
            {
                string DateTimeFormatForDatabase = "yyyy-MM-dd HH:mm:ss.fff";
                return dateTime.ToString(DateTimeFormatForDatabase);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static int ToDatabase(this bool boolean)
        {
            return Convert.ToInt32(boolean);
        }
    }
}

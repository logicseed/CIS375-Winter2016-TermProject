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
        /// <param name="BaseDataRow"> The DataRow extended by this method. </param>
        /// <param name="Name"> The key for the column to return. </param>
        /// <returns> The value in the column as a datatype. </returns>
        /// <exception cref="InvalidCastException" />
        public static ReturnType Col<ReturnType>(this DataRow BaseDataRow, string Name)
        {
            return (ReturnType)Convert.ChangeType(BaseDataRow[Name], typeof(ReturnType), CultureInfo.InvariantCulture);
        }

        // IDEA: Test task something.

        /// <summary>
        ///   Generic method to get the value in a column as a datatype ReturnType. 
        /// </summary>
        /// <typeparam name="ReturnType"> The datatype to return. </typeparam>
        /// <param name="BaseDataRow"> The DataRow extended by this method. </param>
        /// <param name="Index"> The index of the column to return. </param>
        /// <returns> The value in the column as a datatype. </returns>
        public static ReturnType Col<ReturnType>(this DataRow BaseDataRow, int Index = 0)
        {
            string Name = BaseDataRow.Table.Columns[Index].ColumnName;
            return BaseDataRow.Col<ReturnType>(Name);
        }

        /// <summary>
        ///   Gets the value in a column as an integer. 
        /// </summary>
        /// <param name="BaseDataRow"> The DataRow extended by this method. </param>
        /// <param name="Name"> The key for the column to return. </param>
        /// <returns> The value in the column as an integer. </returns>
        public static int Col(this DataRow BaseDataRow, string Name)
        {
            return BaseDataRow.Col<int>(Name);
        }

        /// <summary>
        ///   Gets the value in a column as an integer. 
        /// </summary>
        /// <param name="BaseDataRow"> The DataRow extended by this method. </param>
        /// <param name="Index"> The index of the column to return. </param>
        /// <returns> The value in the column as an integer. </returns>
        public static int Col(this DataRow BaseDataRow, int Index = 0)
        {
            string Name = BaseDataRow.Table.Columns[Index].ColumnName;
            return BaseDataRow.Col<int>(Name);
        }

        /// <summary>
        ///   Retrieves a DataRow from a DataTable by index; defaults to the first row. 
        /// </summary>
        /// <param name="BaseDataTable"> The DataTable extended by this method. </param>
        /// <param name="Index"> The index of the row to return. </param>
        /// <returns> The DataRow at the specified index. </returns>
        public static DataRow Row(this DataTable BaseDataTable, int Index = 0)
        {
            return BaseDataTable.Rows[Index];
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
        public static string ToDatabase(this DateTime BaseDateTime)
        {
            try
            {
                string DateTimeFormatForDatabase = "yyyy-MM-dd HH:mm:ss.fff";
                return BaseDateTime.ToString(DateTimeFormatForDatabase);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }
    }
}

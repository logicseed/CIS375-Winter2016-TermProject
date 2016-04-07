/// <project>IceCreamManager</project>
/// <module>ExtensionMethods</module>
/// <author>Marc King</author>
/// <date_created>2016-04-04</date_created>

using System;
using System.Data;
using IceCreamManager.Model;

namespace IceCreamManager.Controller
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Converts the DateTime to a formatted string for storing in the database.
        /// </summary>
        /// <remarks>
        /// See https://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx for explanation of
        /// dateTimeFormat string. See https://www.sqlite.org/datatype3.html Section 1.2 for
        /// an explanation of the datetime format expected by the database.
        /// </remarks>
        /// <preconditions>DateTime object exists.</preconditions>
        /// <postconditions>No changes made to DateTime object.</postconditions>
        /// <returns>A string with the DateTime in format expected by the database.</returns>
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


        public static DataRow Row(this DataTable BaseDataTable, int Index = 0)
        {
            try
            {
                return BaseDataTable.Rows[Index];
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static int IntCol(this DataRow BaseDataRow, int Index = 0)
        {
            try
            {
                string Name = BaseDataRow.Table.Columns[Index].ColumnName;
                return BaseDataRow.IntCol(Name);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static int IntCol(this DataRow BaseDataRow, string Name)
        {
            try
            {
                return Convert.ToInt32(BaseDataRow[Name]);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static string StringCol(this DataRow BaseDataRow, int Index = 0)
        {
            try
            {
                string Name = BaseDataRow.Table.Columns[Index].ColumnName;
                return BaseDataRow.StringCol(Name);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static string StringCol(this DataRow BaseDataRow, string Name)
        {
            try
            {
                return Convert.ToString(BaseDataRow[Name]);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }


        public static bool BoolCol(this DataRow BaseDataRow, int Index = 0)
        {
            try
            {
                string Name = BaseDataRow.Table.Columns[Index].ColumnName;
                return BaseDataRow.BoolCol(Name);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static bool BoolCol(this DataRow BaseDataRow, string Name)
        {
            try
            {
                return Convert.ToBoolean(BaseDataRow[Name]);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static DateTime DateTimeCol(this DataRow BaseDataRow, int Index = 0)
        {
            try
            {
                string Name = BaseDataRow.Table.Columns[Index].ColumnName;
                return BaseDataRow.DateTimeCol(Name);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static DateTime DateTimeCol(this DataRow BaseDataRow, string Name)
        {
            try
            {
                return Convert.ToDateTime(BaseDataRow[Name]);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static double DoubleCol(this DataRow BaseDataRow, int Index = 0)
        {
            try
            {
                string Name = BaseDataRow.Table.Columns[Index].ColumnName;
                return BaseDataRow.DoubleCol(Name);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

        public static double DoubleCol(this DataRow BaseDataRow, string Name)
        {
            try
            {
                return Convert.ToDouble(BaseDataRow[Name]);
            }
            catch (Exception)
            {
                throw; // Handled up the stack.
            }
        }

    }

}

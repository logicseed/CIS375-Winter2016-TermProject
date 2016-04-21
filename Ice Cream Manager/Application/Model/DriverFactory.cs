
using System;
/// <project> IceCreamManager </project>
/// <module> DriverFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>
using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Provides an interface for the creation and loading of drivers. 
    /// </summary>
    public class DriverFactory : DatabaseEntityFactory<Driver>
    {
        #region Singleton
        private static readonly DriverFactory SingletonInstance = new DriverFactory();
        public static DriverFactory Reference { get { return SingletonInstance; } }
        private DriverFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "Number,Name,HourlyRate,IsDeleted";

        protected override string DatabaseQueryColumnValuePairs(Driver driver)
            => $"Number = {driver.Number},Name = '{driver.Name}',HourlyRate = {driver.HourlyRate},IsDeleted = {driver.IsDeleted.ToDatabase()}";

        protected override string DatabaseQueryValues(Driver driver)
            => $"{driver.Number},'{driver.Name}',{driver.HourlyRate},{driver.IsDeleted.ToDatabase()}";

        protected override Driver MapDataRowToProperties(DataRow row)
        {
            Driver driver = new Driver();

            driver.ID = row.Col("ID");
            driver.Number = row.Col("Number");
            driver.Name = row.Col<string>("Name");
            driver.HourlyRate = row.Col<double>("HourlyRate");
            driver.IsDeleted = row.Col<bool>("IsDeleted");
            driver.InDatabase = true;
            driver.IsSaved = true;

            return driver;
        }

        protected override string SaveLogString(Driver driver)
        {
            return $"Driver {driver.Number} - {driver.Name} who is paid {driver.HourlyRate} per hour.";
        }

        public override DataTable GetDataTable(bool includeDeleted = true)
        {
            var TableFromDatabase = GetAllDataTable(includeDeleted);
            var TableToReturn = new DataTable();

            TableToReturn.Columns.Add(new DataColumn("ID", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Number", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Name", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("HourlyRate", typeof(double)));
            TableToReturn.Columns.Add(new DataColumn("IsDeleted", typeof(bool)));

            foreach (DataRow Row in TableFromDatabase.Rows)
            {
                DataRow RowToReturn = TableToReturn.NewRow();

                RowToReturn["ID"] = Row.Col("ID");
                RowToReturn["Number"] = Row.Col("Number");
                RowToReturn["Name"] = Row.Col<string>("Name");
                RowToReturn["HourlyRate"] = Row.Col<double>("HourlyRate");
                RowToReturn["IsDeleted"] = Row.Col<bool>("IsDeleted");

                TableToReturn.Rows.Add(RowToReturn);
            }

            return TableToReturn;
        }

        internal string GetNameByID(int id)
        {
            Driver driver = Load(id);
            return driver.Name;
        }
    }
}

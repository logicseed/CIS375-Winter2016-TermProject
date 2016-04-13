
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
    }
}

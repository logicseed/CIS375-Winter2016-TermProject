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
    public static class DriverFactory
    {
        private static DatabaseEntityFactory<Driver> DatabaseDriverFactory = new DatabaseEntityFactory<Driver>();
        private static DatabaseManager Database = DatabaseManager.Reference;

        /// <summary>
        ///   Loads a driver from the database and adds it to the cache. 
        /// </summary>
        /// <param name="id"> The unique identity of the driver. </param>
        /// <returns> A reference to the driver in memory. </returns>
        public static Driver Load(int id)
        {
            return DatabaseDriverFactory.Load(id);
        }

        /// <summary>
        ///   Creates a new driver, until Driver.Save() is called the new city only exists in the cache. 
        /// </summary>
        /// <param name="entityProperties"></param>
        /// <returns></returns>
        public static Driver Create(DriverProperties entityProperties)
        {
            return DatabaseDriverFactory.Create(entityProperties);
        }

        /// <summary>
        /// Creates a new Driver based on a Truck/Driver relationship.
        /// </summary>
        /// <param name="truckID">The identity of the Truck this Driver is assigned to.</param>
        /// <returns>The Driver assigned to the provided Truck.</returns>
        public static Driver LoadTruckDriver(int truckID)
        {
            Driver DriverToAdd = null;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT DriverID FROM TruckDriver WHERE TruckID = {truckID} AND IsDeleted = 0");

            if (ResultsTable.Rows.Count != 0)
            {
                DriverToAdd = Load(ResultsTable.Row().Col("DriverID"));
            }
            return DriverToAdd;
        }
    }
}

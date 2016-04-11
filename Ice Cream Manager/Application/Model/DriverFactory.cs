/// <project> IceCreamManager </project>
/// <module> DriverFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Provides an interface for the creation and loading of drivers. 
    /// </summary>
    public static class DriverFactory
    {
        private static DatabaseEntityFactory<Driver> DatabaseDriverFactory = new DatabaseEntityFactory<Driver>();

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
    }
}

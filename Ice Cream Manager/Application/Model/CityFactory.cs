/// <project> IceCreamManager </project>
/// <module> CityFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    public static class CityFactory
    {
        private static DatabaseEntityFactory<City> DatabaseCityFactory = new DatabaseEntityFactory<City>();
        private static DatabaseManager Database = DatabaseManager.Reference;

        public static City Load(int id)
        {
            return DatabaseCityFactory.Load(id);
        }

        /// <summary>
        ///   Creates a new city, until City.Save() is called the new city only exists in the cache. 
        /// </summary>
        /// <param name="entityProperties"></param>
        /// <returns></returns>
        public static City Create(CityProperties entityProperties)
        {
            string DatabaseCommand = $"SELECT ID FROM City WHERE Label = '{entityProperties.Label}' AND Name = '{entityProperties.Name}' AND State = '{entityProperties.State}'";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            // If the city has the same properties as a previous city then we load that city instead of creating a new one.
            if (ResultsTable.Rows.Count > 0)
            {
                return DatabaseCityFactory.Load(ResultsTable.Row().Col("ID"));
            }

            return DatabaseCityFactory.Create(entityProperties);
        }

        /// <summary>
        ///   Marks all the current cities as deleted in the database. 
        /// </summary>
        /// <returns> Whether or not there were any cities to mark as deleted. </returns>
        public static bool DeleteAll()
        {
            string DatabaseCommand = "SELECT ID FROM City WHERE IsDeleted = 0";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            foreach (DataRow Row in ResultsTable.Rows)
            {
                Database.MarkAsDeleted("City", Row.Col("ID"));
            }

            if (ResultsTable.Rows.Count > 0) return true;
            else return false;
        }
    }
}

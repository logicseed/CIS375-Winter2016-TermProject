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

        public static City Load(int ID)
        {
            return DatabaseCityFactory.Load(ID);
        }

        public static City Create(CityProperties EntityProperties)
        {
            DatabaseManager Database = DatabaseManager.Reference;
            string DatabaseCommand = $"SELECT id FROM city WHERE label = '{EntityProperties.Label}' AND name = '{EntityProperties.Name}' AND state = '{EntityProperties.State}'";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            // If the city has the same properties as a previous city then we load that city instead of creating a new one.
            if (ResultsTable.Rows.Count > 0)
            {
                return DatabaseCityFactory.Load(ResultsTable.Row().Col("id"));
            }

            return DatabaseCityFactory.Create(EntityProperties);
        }
    }
}

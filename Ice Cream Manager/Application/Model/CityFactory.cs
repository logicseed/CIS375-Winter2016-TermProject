/// <project> IceCreamManager </project>
/// <module> CityFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

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
            // TODO: This needs to handle searching the database for the same propertires before truly creating a new city.
            return DatabaseCityFactory.Create(EntityProperties);
        }
    }
}

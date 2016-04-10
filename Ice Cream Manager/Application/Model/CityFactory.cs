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
            return DatabaseCityFactory.Create(EntityProperties);
        }
    }
}

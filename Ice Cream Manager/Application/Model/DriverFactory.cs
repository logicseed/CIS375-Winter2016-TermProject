/// <project> IceCreamManager </project>
/// <module> DriverFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

namespace IceCreamManager.Model
{
    public static class DriverFactory
    {
        private static DatabaseEntityFactory<Driver> DatabaseDriverFactory = new DatabaseEntityFactory<Driver>();

        public static Driver Load(int ID)
        {
            return DatabaseDriverFactory.Load(ID);
        }

        public static Driver Create(DriverProperties EntityProperties)
        {
            return DatabaseDriverFactory.Create(EntityProperties);
        }
    }
}

/// <project> IceCreamManager </project>
/// <module> TruckFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

namespace IceCreamManager.Model
{
    public static class TruckFactory
    {
        private static DatabaseEntityFactory<Truck> DatabaseTruckFactory = new DatabaseEntityFactory<Truck>();

        public static Truck Load(int ID)
        {
            return DatabaseTruckFactory.Load(ID);
        }

        public static Truck Create(TruckProperties EntityProperties)
        {
            return DatabaseTruckFactory.Create(EntityProperties);
        }
    }
}

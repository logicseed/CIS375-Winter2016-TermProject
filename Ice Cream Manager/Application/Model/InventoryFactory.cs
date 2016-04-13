/// <project> IceCreamManager </project>
/// <module> InventoryFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

namespace IceCreamManager.Model
{
    public static class InventoryFactory
    {
        private static DatabaseEntityFactory<Inventory> DatabaseInventoryFactory = new DatabaseEntityFactory<Inventory>();

        public static Inventory Load(int ID)
        {
            return DatabaseInventoryFactory.Load(ID);
        }

        public static Inventory Create(InventoryProperties EntityProperties)
        {
            return DatabaseInventoryFactory.Create(EntityProperties);
        }
    }
}

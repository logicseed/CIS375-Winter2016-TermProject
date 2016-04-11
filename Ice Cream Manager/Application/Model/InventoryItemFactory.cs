/// <project> IceCreamManager </project>
/// <module> InventoryItemFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

namespace IceCreamManager.Model
{
    public static class InventoryItemFactory
    {
        private static DatabaseEntityFactory<InventoryItem> DatabaseInventoryItemFactory = new DatabaseEntityFactory<InventoryItem>();

        public static InventoryItem Load(int ID)
        {
            return DatabaseInventoryItemFactory.Load(ID);
        }

        public static InventoryItem Create(InventoryItemProperties EntityProperties)
        {
            return DatabaseInventoryItemFactory.Create(EntityProperties);
        }
    }
}

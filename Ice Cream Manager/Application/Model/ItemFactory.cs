/// <project> IceCreamManager </project>
/// <module> ItemFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-08 </date_created>

namespace IceCreamManager.Model
{
    public static class ItemFactory
    {
        private static DatabaseEntityFactory<Item> DatabaseItemFactory = new DatabaseEntityFactory<Item>();

        public static Item Load(int ID)
        {
            return DatabaseItemFactory.Load(ID);
        }

        public static Item Create(ItemProperties EntityProperties)
        {
            return DatabaseItemFactory.Create(EntityProperties);
        }
    }
}

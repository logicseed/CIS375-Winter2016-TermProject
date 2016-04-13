/// <project> IceCreamManager </project>
/// <module> ItemWasteFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    public class ItemWasteFactory : DatabaseEntityFactory<ItemWaste>
    {
        #region Singleton
        private static readonly ItemWasteFactory SingletonInstance = new ItemWasteFactory();
        public static ItemWasteFactory Reference { get { return SingletonInstance; } }
        private ItemWasteFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "ItemID,RouteID,TruckID,DateExpired";

        protected override string DatabaseQueryColumnValuePairs(ItemWaste itemWaste)
            => $"ItemID = {itemWaste.ItemID},RouteID = {itemWaste.RouteID},TruckID = {itemWaste.TruckID},DateExpired = '{itemWaste.DateExpired.ToDatabase()}'";

        protected override string DatabaseQueryValues(ItemWaste itemWaste)
            => $"{itemWaste.ItemID},{itemWaste.RouteID},{itemWaste.TruckID},'{itemWaste.DateExpired.ToDatabase()}'";

        protected override ItemWaste MapDataRowToProperties(DataRow row)
        {
            ItemWaste itemWaste = new ItemWaste();

            itemWaste.ID = row.Col("ID");
            itemWaste.ItemID = row.Col("ItemID");
            itemWaste.RouteID = row.Col("RouteID");
            itemWaste.TruckID = row.Col("TruckID");
            itemWaste.DateExpired = row.Col<DateTime>("DateExpired");
            itemWaste.InDatabase = true;
            itemWaste.IsSaved = true;

            return itemWaste;
        }
    }
}

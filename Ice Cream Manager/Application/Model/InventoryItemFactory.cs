/// <project> IceCreamManager </project>
/// <module> InventoryItemFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using System.Collections.Generic;
using System.Data;

namespace IceCreamManager.Model
{
    public class InventoryItemFactory : DatabaseEntityFactory<InventoryItem>
    {
        #region Singleton
        private static readonly InventoryItemFactory SingletonInstance = new InventoryItemFactory();
        public static InventoryItemFactory Reference { get { return SingletonInstance; } }
        private InventoryItemFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "ItemID,TruckID,DateCreated,IsDeleted";

        protected override string DatabaseQueryColumnValuePairs(InventoryItem inventoryItem)
            => $"ItemID = {inventoryItem.ItemID},TruckID = {inventoryItem.TruckID},DateCreated = '{inventoryItem.DateCreated.ToDatabase()}',IsDeleted = {inventoryItem.IsDeleted.ToDatabase()}";

        protected override string DatabaseQueryValues(InventoryItem inventoryItem)
            => $"{inventoryItem.ItemID},{inventoryItem.TruckID},'{inventoryItem.DateCreated.ToDatabase()}',{inventoryItem.IsDeleted.ToDatabase()}";

        protected override InventoryItem MapDataRowToProperties(DataRow row)
        {
            InventoryItem inventoryItem = new InventoryItem();

            inventoryItem.ID = row.Col("ID");
            inventoryItem.ItemID = row.Col("ItemID");
            inventoryItem.TruckID = row.Col("TruckID");
            inventoryItem.DateCreated = row.Col<DateTime>("DateCreated");
            inventoryItem.IsDeleted = row.Col<bool>("IsDeleted");
            inventoryItem.InDatabase = true;
            inventoryItem.IsSaved = true;

            return inventoryItem;
        }

        internal Item LoadItem(int itemID)
        {
            throw new NotImplementedException();
        }

        internal Truck LoadTruck(int truckID)
        {
            throw new NotImplementedException();
        }

        protected override string SaveLogString(InventoryItem entity)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Item, int> GetTruckItemListByID(int id)
        {
            var sql = $"SELECT * FROM InventoryItem WHERE TruckID = {id}";
            var table = Database.Query(sql);

            var itemIDQuantity = new Dictionary<int, int>();
            foreach (DataRow row in table.Rows)
            {
                if (itemIDQuantity.ContainsKey(row.Col("ItemID"))) itemIDQuantity[row.Col("ItemID")]++;
                else itemIDQuantity.Add(row.Col("ItemID"), 1);
            }

            var listToReturn = new Dictionary<Item, int>();
            foreach (KeyValuePair<int,int> pair in itemIDQuantity)
            {
                listToReturn.Add(Factory.Item.Load(pair.Key), pair.Value);
            }

            return listToReturn;
        }
    }
}

/// <project> IceCreamManager </project>
/// <module> InventoryItemFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using System.Collections.Generic;
using System.Data;
using IceCreamManager.Controller;

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
            => "ItemID,TruckID,DateCreated";

        protected override string DatabaseQueryColumnValuePairs(InventoryItem inventoryItem)
            => $"ItemID = {inventoryItem.ItemID},TruckID = {inventoryItem.TruckID},DateCreated = '{inventoryItem.DateCreated.ToDatabase()}'";

        protected override string DatabaseQueryValues(InventoryItem inventoryItem)
            => $"{inventoryItem.ItemID},{inventoryItem.TruckID},'{inventoryItem.DateCreated.ToDatabase()}'";

        protected override InventoryItem MapDataRowToProperties(DataRow row)
        {
            InventoryItem inventoryItem = new InventoryItem();

            inventoryItem.ID = row.Col("ID");
            inventoryItem.ItemID = row.Col("ItemID");
            inventoryItem.TruckID = row.Col("TruckID");
            inventoryItem.DateCreated = row.Col<DateTime>("DateCreated");
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
            var itemIDQuantity = GetTruckItemIDQuantity(id);

            var listToReturn = new Dictionary<Item, int>();
            foreach (KeyValuePair<int,int> pair in itemIDQuantity)
            {
                listToReturn.Add(Factory.Item.Load(pair.Key), pair.Value);
            }

            return listToReturn;
        }

        public Dictionary<int, int> GetTruckItemIDQuantity(int id)
        {
            var sql = $"SELECT * FROM InventoryItem WHERE TruckID = {id}";
            var table = Database.Query(sql);

            var itemIDQuantity = new Dictionary<int, int>();
            foreach (DataRow row in table.Rows)
            {
                if (itemIDQuantity.ContainsKey(row.Col("ItemID"))) itemIDQuantity[row.Col("ItemID")]++;
                else itemIDQuantity.Add(row.Col("ItemID"), 1);
            }

            return itemIDQuantity;
        }

        public DataTable GetItemDataTable(int truckID)
        {
            var DatabaseCommand = $"SELECT * FROM InventoryItem WHERE TruckID = {truckID}";
            var TableFromDatabase = Database.Query(DatabaseCommand);
            var TableToReturn = new DataTable();

            
            TableToReturn.Columns.Add(new DataColumn("ItemDescription", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("ItemID", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Quantity", typeof(int)));
            TableToReturn.Columns["Quantity"].DefaultValue = 0;
            TableToReturn.Columns.Add(new DataColumn("Change", typeof(int)));
            TableToReturn.Columns["Change"].DefaultValue = 0;
            TableToReturn.Columns.Add(new DataColumn("Sale", typeof(int)));
            TableToReturn.Columns["Sale"].DefaultValue = 0;
            TableToReturn.Columns.Add(new DataColumn("Waste", typeof(int)));
            TableToReturn.Columns["Waste"].DefaultValue = 0;
            TableToReturn.Columns.Add(new DataColumn("IsDefault", typeof(bool)));
            TableToReturn.Columns["IsDefault"].DefaultValue = false;
            TableToReturn.Columns.Add(new DataColumn("TotalQuantity", typeof(int)));
            TableToReturn.Columns["TotalQuantity"].DefaultValue = 0;
            //TableToReturn.PrimaryKey = new DataColumn[] { TableToReturn.Columns["ItemID"] };

            if (truckID == 0) return TableToReturn;

            foreach (DataRow Row in TableFromDatabase.Rows)
            {
                
                bool notAdded = true;
                foreach (DataRow RowInReturn in TableToReturn.Rows)
                {
                    if ((int)RowInReturn["ItemID"] == Row.Col("ItemID"))
                    {
                        RowInReturn["Quantity"] = (int)RowInReturn["Quantity"] + 1;
                        notAdded = false;
                    }
                }
                if (notAdded)
                {
                    DataRow RowToReturn = TableToReturn.NewRow();

                    RowToReturn["ItemID"] = Row.Col("ItemID");
                    RowToReturn["ItemDescription"] = Factory.Item.GetNameByID(Row.Col("ItemID"));
                    RowToReturn["Quantity"] = 1;

                    TableToReturn.Rows.Add(RowToReturn);
                }
            }
            
            foreach (var defaultItemID in Factory.Truck.GetDefaultInventoryList())
            {
                var notAdded = true;
                foreach (DataRow row in TableToReturn.Rows)
                {
                    if (row.Col("ItemID") == defaultItemID) notAdded = false;
                }
                if(notAdded)
                {
                    DataRow RowToReturn = TableToReturn.NewRow();

                    RowToReturn["ItemID"] = defaultItemID;
                    RowToReturn["ItemDescription"] = Factory.Item.GetNameByID(defaultItemID);
                    RowToReturn["Quantity"] = 0;

                    TableToReturn.Rows.Add(RowToReturn);
                }
            }

            return TableToReturn;
        }

        private void Add(int itemID, int truckID, int quantity = 1)
        {
            if (quantity == 0) return;
            var sql = $"INSERT INTO InventoryItem (ItemID, TruckID, DateCreated) VALUES ";
            for (int i = 0; i < quantity; i++)
            {
                sql += $"({itemID},{truckID},'{DateTime.Now.ToDatabase()}'),";
            }
            sql = sql.TrimEnd(',');
            
            Database.NonQuery(sql);
            Log.Success($"Added {quantity} {Factory.Item.GetNameByID(itemID)} to truck number {Factory.Truck.GetNumberByID(truckID)}.");
        }

        private void Remove(int itemID, int truckID, int quantity = 1)
        {
            if (quantity == 0) return;
            var sql = $"DELETE FROM InventoryItem WHERE ID IN (SELECT ID FROM InventoryItem WHERE ItemID = {itemID} AND TruckID = {truckID} ORDER BY DateCreated ASC LIMIT {quantity})";
            Database.NonQuery(sql);
            Log.Success($"Removed {quantity} {Factory.Item.GetNameByID(itemID)} from truck number {Factory.Truck.GetNumberByID(truckID)}.");
        }

        public void ChangeMany(int itemID, int truckID, int quantity)
        {
            if (Factory.Item.GetWarehouseQuantity(itemID) < quantity) quantity = Factory.Item.GetWarehouseQuantity(itemID);
            if (quantity == 0) return;
            if (quantity < 0) Remove(itemID, truckID, quantity * -1);
            else
            {
                Add(itemID, truckID, quantity);
                var item = Factory.Item.Load(itemID);
                item.Quantity = item.Quantity - quantity;
                item.ReplaceOnSave = false;
                item.Save();
            }
        }

        public void SellMany(int itemID, int truckID, int quantity)
        {
            if (quantity == 0) return;
            Factory.Sale.SellMany(itemID, truckID, quantity);
            var sql = $"DELETE FROM InventoryItem WHERE ID IN (SELECT ID FROM InventoryItem WHERE ItemID = {itemID} AND TruckID = {truckID} ORDER BY DateCreated ASC LIMIT {quantity})";
            Database.NonQuery(sql);
        }

        public void WasteMany(int itemID, int truckID, int quantity)
        {
            if (quantity == 0) return;
            Factory.ItemWaste.WasteMany(itemID, truckID, quantity);
            var sql = $"DELETE FROM InventoryItem WHERE ID IN (SELECT ID FROM InventoryItem WHERE ItemID = {itemID} AND TruckID = {truckID} ORDER BY DateCreated ASC LIMIT {quantity})";
            Database.NonQuery(sql);
        }

        public void ChangeTruckID(int oldID, int newID)
        {
            var sql = $"UPDATE InventoryItem SET TruckID = {newID} WHERE TruckID = {oldID}";
            Database.NonQuery(sql);
        }

        public void ChangeItemID(int oldID, int newID)
        {
            var sql = $"UPDATE InventoryItem SET ItemID = {newID} WHERE ItemID = {oldID}";
            Database.NonQuery(sql);
        }

        public int GetInventoryQuantity(int truckID, int itemID)
        {
            var sql = $"SELECT count(*) FROM IventoryItem WHERE TruckID = {truckID} AND ItemID = {itemID}";
            var table = Database.Query(sql);
            return table.Row().Col();
        }
    }
}

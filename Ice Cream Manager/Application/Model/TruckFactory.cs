/// <project> IceCreamManager </project>
/// <module> TruckFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using System.Collections.Generic;
using System.Data;
using IceCreamManager.Controller;

namespace IceCreamManager.Model
{
    public class TruckFactory : DatabaseEntityFactory<Truck>
    {
        #region Singleton
        private static readonly TruckFactory SingletonInstance = new TruckFactory();
        public static TruckFactory Reference { get { return SingletonInstance; } }
        private TruckFactory() { }
        #endregion Singleton

        private LanguageManager Language = LanguageManager.Reference;

        protected override string DatabaseQueryColumns()
            => "Number,RouteID,DriverID,FuelRate,IsDeleted";

        protected override string DatabaseQueryColumnValuePairs(Truck truck)
            => $"Number = {truck.Number},RouteID = {truck.RouteID},DriverID = {truck.DriverID},FuelRate = {truck.FuelRate},IsDeleted = {truck.IsDeleted.ToDatabase()}";

        protected override string DatabaseQueryValues(Truck truck)
            => $"{truck.Number},{truck.RouteID},{truck.DriverID},{truck.FuelRate},{truck.IsDeleted.ToDatabase()}";

        protected override Truck MapDataRowToProperties(DataRow row)
        {
            Truck truck = new Truck();

            truck.ID = row.Col("ID");
            truck.Number = row.Col("Number");
            truck.RouteID = row.Col("RouteID");
            truck.DriverID = row.Col("DriverID");
            truck.FuelRate = row.Col<double>("FuelRate");
            truck.IsDeleted = row.Col<bool>("IsDeleted");
            truck.InDatabase = true;
            truck.IsSaved = true;

            return truck;
        }

        public List<InventoryItem> LoadInventoryList(int truckID)
        {
            //throw new NotImplementedException();
            return new List<InventoryItem>();
        }

        public override DataTable GetDataTable(bool includeDeleted)
        {
            var TableFromDatabase = GetAllDataTable(includeDeleted);
            var TableToReturn = new DataTable();

            TableToReturn.Columns.Add(new DataColumn("ID", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Number", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Driver", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("Route", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("FuelRate", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("Items", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("IsDeleted", typeof(bool)));

            foreach (DataRow Row in TableFromDatabase.Rows)
            {
                DataRow RowToReturn = TableToReturn.NewRow();

                RowToReturn["ID"] = Row.Col("ID");
                RowToReturn["Number"] = Row.Col("Number");
                RowToReturn["FuelRate"] = Row.Col<double>("FuelRate");
                RowToReturn["IsDeleted"] = Row.Col<bool>("IsDeleted");

                if (Row.Col("DriverID") != 0) RowToReturn["Driver"] = Factory.Driver.GetNameByID(Row.Col("DriverID"));
                else RowToReturn["Driver"] = "—";

                if (Row.Col("RouteID") != 0) RowToReturn["Route"] = Factory.Route.GetNumberByID(Row.Col("RouteID"));
                else RowToReturn["Route"] = "—";

                var ItemsColumn = "";
                var TruckItemList = Factory.InventoryItem.GetTruckItemListByID(Row.Col("ID"));
                foreach (KeyValuePair<Item, int> pair in TruckItemList)
                {
                    ItemsColumn += $"{pair.Key.Description} ({pair.Value}), ";
                }
                if (ItemsColumn.Length > 0) ItemsColumn = ItemsColumn.Substring(0, ItemsColumn.Length - 2);
                RowToReturn["Items"] = ItemsColumn.Trim() == "" ? "—" : ItemsColumn;

                

                TableToReturn.Rows.Add(RowToReturn);
            }

            return TableToReturn;
        }

        internal DataTable GetDefaultInventoryTable()
        {
            var DatabaseCommand = "SELECT * FROM DefaultInventory";
            var TableFromDatabase = Database.Query(DatabaseCommand);
            var TableToReturn = new DataTable();

            TableToReturn.Columns.Add(new DataColumn("ID", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("ItemID", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("ItemDescription", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("Quantity", typeof(int)));

            foreach (DataRow Row in TableFromDatabase.Rows)
            {
                DataRow RowToReturn = TableToReturn.NewRow();

                RowToReturn["ID"] = Row.Col("ID");
                RowToReturn["ItemID"] = Row.Col("ItemID");
                RowToReturn["ItemDescription"] = Factory.Item.GetNameByID(Row.Col("ItemID"));
                RowToReturn["Quantity"] = Row.Col("Quantity");

                TableToReturn.Rows.Add(RowToReturn);
            }

            return TableToReturn;
        }

        public void ChangeDefaultInventoryItem(int itemID, int quantity)
        {
            // Does it already exist?
            var sql = $"SELECT ID FROM DefaultInventory WHERE ItemID = {itemID}";
            var table = Database.Query(sql);
            
            if (table.Rows.Count == 0 && quantity == 0) return;

            var item = Factory.Item.Load(itemID);

            if (table.Rows.Count > 0 && quantity == 0)
            {
                sql = $"DELETE FROM DefaultInventory WHERE ItemID = {itemID}";
                Log.Success($"Removed {item.Description} from the default truck inventory.");
            }
            else if (table.Rows.Count > 0)
            {
                sql = $"UPDATE DefaultInventory SET Quantity = {quantity} WHERE ItemID = {itemID}";
                Log.Success($"Changed {item.Description} to have {quantity} in the default truck inventory.");
            }
            else
            {
                sql = $"INSERT INTO DefaultInventory (ItemID,Quantity) VALUES ({itemID},{quantity})";
                Log.Success($"Added {quantity} {item.Description} to the default truck inventory.");
            }

            Database.NonQuery(sql);
        }

        public void ChangeItemID(int oldID, int newID)
        {
            var sql = $"UPDATE DefaultInventory SET ItemID = {newID} WHERE ItemID = {oldID}";
            Database.NonQuery(sql);
        }

        internal List<int> GetDefaultInventoryList()
        {
            var sql = "SELECT ItemID FROM DefaultInventory";
            var table = Database.Query(sql);
            var list = new List<int>();

            if (table.Rows.Count == 0) return list;

            foreach (DataRow row in table.Rows)
            {
                list.Add(row.Col());
            }
            return list;
        }

        public int GetNumberByID(int truckID)
        {
            var sql = $"SELECT Number FROM Truck WHERE ID = {truckID}";
            var table = Database.Query(sql);

            return table.Row().Col();
        }

        public Dictionary<int,int> StockTruck(int truckID)
        {
            var sql = "SELECT * FROM DefaultInventory";
            var table = Database.Query(sql);

            var changes = new Dictionary<int, int>();
            if (table.Rows.Count == 0) return changes;

            foreach (DataRow row in table.Rows)
            {
                changes.Add(row.Col("ItemID"), row.Col("Quantity"));
            }

            return changes;
        }

        protected override string SaveLogString(Truck truck)
        {
            string driver = truck.DriverID == 0 ? "no driver" : truck.Driver.Name;
            string route = truck.RouteID == 0 ? "no route" : "route number "+truck.Route.Number;
            return $"Truck {truck.Number} - Driven by {driver} assigned {route} with a fuel rate of {Language.UserCurrency}{truck.FuelRate} per mile.";
        }

        protected override bool Replace(Truck truck)
        {
            var oldID = truck.ID;
            EntityCache.Remove(TableName, truck);
            DatabaseMan.MarkAsDeleted(TableName, truck.ID);
            if (Insert(truck))
            {
                Log.Success($"Edited {SaveLogString(truck)}");

                if (truck.ID != oldID && oldID != 0) Factory.InventoryItem.ChangeTruckID(oldID, truck.ID);
                return true;
            }
            else return false;
        }

        internal void GetTruckNumberList(ref Dictionary<int, string> truckList)
        {
            var sql = $"SELECT * FROM Truck WHERE IsDeleted = 0 ORDER BY Number";
            var table = Database.Query(sql);

            foreach (DataRow row in table.Rows)
            {
                var name = $"{row.Col("Number")}";
                var driverID = row.Col("DriverID");
                var routeID = row.Col("RouteID");
                if (driverID != 0 || routeID != 0) name += " - ";
                if (driverID != 0) name += Factory.Driver.GetNameByID(row.Col("DriverID"));
                if (driverID != 0 && routeID != 0) name += ", ";
                if (routeID != 0) name += $"Route {Factory.Route.GetNumberByID(row.Col("RouteID"))}";

                truckList.Add(row.Col("Number"), name);
            }
        }

    }
}

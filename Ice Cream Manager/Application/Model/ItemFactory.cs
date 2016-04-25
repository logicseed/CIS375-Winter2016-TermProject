/// <project> IceCreamManager </project>
/// <module> ItemFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-08 </date_created>

using System;
using System.Collections.Generic;
using System.Data;
using IceCreamManager.Controller;

namespace IceCreamManager.Model
{
    public class ItemFactory : DatabaseEntityFactory<Item>
    {
        private LanguageManager Language = LanguageManager.Reference;
        #region Singleton
        private static readonly ItemFactory SingletonInstance = new ItemFactory();
        public static ItemFactory Reference { get { return SingletonInstance; } }
        private ItemFactory() { }
        #endregion Singleton

        protected override string TableName => "Item";

        

        protected override string DatabaseQueryColumns()
            => "Number,Description,Price,Lifetime,Quantity,IsDeleted";

        protected override string DatabaseQueryColumnValuePairs(Item item)
            => $"Number = {item.Number},Description = '{item.Description}',Price = {item.Price},Lifetime = {item.Lifetime},Quantity = {item.Quantity},IsDeleted = {item.IsDeleted.ToDatabase()}";

        protected override string DatabaseQueryValues(Item item)
            => $"{item.Number},'{item.Description}',{item.Price},{item.Lifetime},{item.Quantity},{item.IsDeleted.ToDatabase()}";

        protected override Item MapDataRowToProperties(DataRow row)
        {
            Item item = new Item();

            item.ID = row.Col("ID");
            item.Number = row.Col("Number");
            item.Description = row.Col<string>("Description");
            item.Price = row.Col<double>("Price");
            item.Lifetime = row.Col("Lifetime");
            item.Quantity = row.Col("Quantity");
            item.IsDeleted = row.Col<bool>("IsDeleted");
            item.InDatabase = true;
            item.IsSaved = true;

            return item;
        }

        

        public override DataTable GetDataTable(bool includeDeleted)
        {
            var TableFromDatabase = GetAllDataTable(includeDeleted);
            var TableToReturn = new DataTable();

            TableToReturn.Columns.Add(new DataColumn("ID", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Number", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Description", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("Price", typeof(double)));
            TableToReturn.Columns.Add(new DataColumn("Quantity", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Lifetime", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("IsDeleted", typeof(bool)));

            foreach (DataRow Row in TableFromDatabase.Rows)
            {
                DataRow RowToReturn = TableToReturn.NewRow();

                RowToReturn["ID"] = Row.Col("ID");
                RowToReturn["Number"] = Row.Col("Number");
                RowToReturn["Description"] = Row.Col<string>("Description");
                RowToReturn["Price"] = Row.Col<double>("Price");
                RowToReturn["Quantity"] = Row.Col("Quantity");
                RowToReturn["Lifetime"] = Row.Col("Lifetime");
                RowToReturn["IsDeleted"] = Row.Col<bool>("IsDeleted");

                TableToReturn.Rows.Add(RowToReturn);
            }

            return TableToReturn;
        }

        public List<Item> GetAvailableItemList()
        {
            var sql = "SELECT ID FROM Item WHERE IsDeleted = 0";
            var table = Database.Query(sql);

            var list = new List<Item>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(Load(row.Col("ID")));
            }

            return list;
        }

        public Item LoadItem(int ID)
        {
            var DatabaseCommand = $"SELECT * FROM Item WHERE ID = {ID}";
            var ResultsTable = DatabaseMan.DataTableFromCommand(DatabaseCommand);

            return MapDataRowToProperties(ResultsTable.Rows[0]);
        }

        protected override string SaveLogString(Item item)
        {
            return $"Item {item.Number} - {item.Description} for {Language.UserCurrency}{item.Price}, with {item.Quantity} in stock that will last {item.Lifetime} days.";
        }

        public string GetNameByID(int itemID)
        {
            var sql = $"SELECT Description FROM Item WHERE ID = {itemID}";
            var table = Database.Query(sql);
            return table.Row().Col<string>("Description");
        }

        internal void GetItemNumberList(ref Dictionary<int, string> itemList)
        {
            var sql = $"SELECT * FROM Item WHERE IsDeleted = 0 ORDER BY Description";
            var table = Database.Query(sql);

            foreach (DataRow row in table.Rows)
            {
                itemList.Add(row.Col("Number"), row.Col<string>("Description"));
            }
        }

        internal int GetWarehouseQuantity(int itemID)
        {
            var sql = $"SELECT Quantity FROM Item WHERE ID = {itemID}";
            var table = Database.Query(sql);
            return table.Row().Col();
        }

        protected override bool Replace(Item item)
        {
            var oldID = item.ID;
            EntityCache.Remove(TableName, item);
            DatabaseMan.MarkAsDeleted(TableName, item.ID);
            if (Insert(item))
            {
                Log.Success($"Edited {SaveLogString(item)}");
                Factory.InventoryItem.ChangeItemID(oldID, item.ID);
                Factory.Truck.ChangeItemID(oldID, item.ID);
                return true;
            }
            else return false;
        }
    }
}

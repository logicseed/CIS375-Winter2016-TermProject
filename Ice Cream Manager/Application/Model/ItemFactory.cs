
using System;
using System.Collections.Generic;
using System.Data;
/// <project> IceCreamManager </project>
/// <module> ItemFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-08 </date_created>
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

        public decimal NextNumber()
        {
            var DatabaseCommand = $"SELECT Max(Number) FROM {TableName} WHERE IsDeleted = 0";
            var ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            return ResultsTable.Row().Col() + 1;
        }

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

        public bool Delete(int itemID)
        {
            return Database.MarkAsDeleted(TableName, itemID);
        }

        public List<Item> GetList(bool includeDeleted = false)
        {
            var Items = new List<Item>();
            var DatabaseCommand = $"SELECT * FROM {TableName}";
            if (!includeDeleted) DatabaseCommand += " WHERE IsDeleted = 0";
            var ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            foreach (DataRow Row in ResultsTable.Rows)
            {
                Items.Add(MapDataRowToProperties(Row));
            }

            return Items;
        }

        public new Item LoadItem(int ID)
        {
            var DatabaseCommand = $"SELECT * FROM Item WHERE ID = {ID}";
            var ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            return MapDataRowToProperties(ResultsTable.Rows[0]);
        }

    }
}

/// <project> IceCreamManager </project>
/// <module> InventoryItem </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    public class InventoryItemProperties : DatabaseEntityProperties
    {
        public Item ItemType;
        public int InventoryID;
        public DateTime DateCreated;
    }

    public class InventoryItem : DatabaseEntity
    {
        private InventoryItemProperties InventoryItemValues = new InventoryItemProperties();

        public InventoryItem()
        {
            ID = 0;
        }

        public InventoryItem(int ID)
        {
            Load(ID);
        }

        public DateTime DateCreated
        {
            get
            {
                return InventoryItemValues.DateCreated;
            }

            set
            {
                InventoryItemValues.DateCreated = value;
            }
        }

        public Item ItemType
        {
            get
            {
                return InventoryItemValues.ItemType;
            }

            set
            {
                InventoryItemValues.ItemType = value;
            }
        }

        public int InventoryID
        {
            get
            {
                return InventoryItemValues.InventoryID;
            }

            set
            {
                InventoryItemValues.InventoryID = value;
            }
        }

        protected override string TableName => "inventory_item";

        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (item_id,inventory_id,date_created) VALUES ({ItemType.ID},{InventoryID},'{DateCreated.ToDatabase()}')";

        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (item_id,inventory_id,date_created,deleted) VALUES ({ItemType.ID},{InventoryID},'{DateCreated.ToDatabase()}',{IsDeleted.ToDatabase()})";

        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            int ItemTypeID = ResultsTable.Row().Col("item_id");
            ItemType = ItemFactory.Load(ItemTypeID);
            InventoryID = ResultsTable.Row().Col("inventory_id");
            DateCreated = ResultsTable.Row().Col<DateTime>("date_created");

            return true;
        }

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            InventoryItemValues = (InventoryItemProperties)EntityProperties;

            return true;
        }

        public bool RemoveFromInventory()
        {
            IsDeleted = true;
            return Save();
        }
    }
}

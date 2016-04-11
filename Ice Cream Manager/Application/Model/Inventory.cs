/// <project> IceCreamManager </project>
/// <module> Inventory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;
using System.Collections.Generic;
using System.Data;

namespace IceCreamManager.Model
{
    public class InventoryProperties : DatabaseEntityProperties
    {
        public List<InventoryItem> Items;
    }

    public class Inventory : DatabaseEntity
    {
        private InventoryProperties InventoryValues = new InventoryProperties();

        public Inventory()
        {
            ID = 0;
        }

        public Inventory(int ID)
        {
            Load(ID);
        }

        public List<InventoryItem> Items
        {
            get { return InventoryValues.Items; }
            private set { }
        }

        protected override string TableName => "inventory";

        protected override string CreateCommand =>
            $"INSERT INTO {TableName} VALUES (null)";

        protected override string UpdateCommand =>
            $"";

        public bool AddItem(int ItemID, int Quantity)
        {
            for (int Index = 0; Index < Quantity; Index++)
            {
                InventoryItemProperties InventoryItemValues = new InventoryItemProperties();
                InventoryItemValues.InventoryID = ID;
                InventoryItemValues.ItemType = ItemFactory.Load(ItemID);
                InventoryItemValues.DateCreated = DateTime.Now;

                InventoryItem ItemToAdd = InventoryItemFactory.Create(InventoryItemValues);
                Items.Add(ItemToAdd);
            }

            return true;
        }

        public bool AddItem(int ItemID)
        {
            return AddItem(ItemID, 1);
        }

        public bool RemoveItem(int ItemID, int Quantity)
        {
            for (int Index = 0; Index < Quantity; Index++)
            {
                InventoryItem ItemToRemove = Items.Find(InventoryItem => InventoryItem.ItemType.ID == ItemID);
                Items.Remove(ItemToRemove);
                ItemToRemove.RemoveFromInventory();
            }

            return true;
        }

        public bool RemoveItem(int ItemID)
        {
            return RemoveItem(ItemID, 1);
        }

        public override bool Load(int ID)
        {
            this.ID = ID;
            string DatabaseCommand = $"SELECT id FROM inventory_item WHERE inventory_id = {ID}";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            if (ResultsTable.Rows.Count == 0) return false;

            foreach (DataRow Row in ResultsTable.Rows)
            {
                int InventoryItemID = Row.Col();
                InventoryItem ItemToAdd = InventoryItemFactory.Load(InventoryItemID);
                Items.Add(ItemToAdd);
            }

            Items.Sort((First, Second) => DateTime.Compare(Second.DateCreated, First.DateCreated));

            return true;
        }

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            InventoryValues = (InventoryProperties)EntityProperties;

            return true;
        }
    }
}

/// <project> IceCreamManager </project>
/// <module> InventoryItem </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;

namespace IceCreamManager.Model
{
    public class InventoryItemProperties : DatabaseEntityProperties
    {
        public Item ItemType;
        public DateTime DateCreated;
    }

    public class InventoryItem : DatabaseEntity
    {
        private Item itemType;
        private DateTime dateCreated;

        public InventoryItem(int ID)
        {
            Load(ID);
        }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }

            set
            {
                dateCreated = value;
            }
        }

        public Item ItemType
        {
            get
            {
                return itemType;
            }

            set
            {
                itemType = value;
            }
        }

        protected override string TableName => "inventory_item";

        protected override string CreateCommand =>
            $"";

        protected override string UpdateCommand =>
            $"";

        public override bool Load(int ID)
        {
            //this.ID = ID;
            //DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            //if (ResultsTable.Rows.Count == 0) return false;

            //int ItemTypeID = ResultsTable.Row().Col("item_id");
            //ItemType = ItemFactory.Load(ItemTypeID);
            //DateCreated = ResultsTable.Row().Col<DateTime>("date_created");

            return true;
        }

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            InventoryItemProperties InventoryItemValues = EntityProperties as InventoryItemProperties;

            ItemType = InventoryItemValues.ItemType;
            DateCreated = InventoryItemValues.DateCreated;
            //Number = ItemValues.Number;
            //Description = ItemValues.Description;
            //Price = ItemValues.Price;
            //Lifetime = ItemValues.Lifetime;

            return true;
        }
    }
}

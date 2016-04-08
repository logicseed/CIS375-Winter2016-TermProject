/// <project>IceCreamManager</project>
/// <module>Inventory</module>
/// <author>Marc King</author>
/// <date_created>2016-04-07</date_created>

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamManager
{
    class Inventory : DatabaseEntity
    {

        int id;

        Dictionary<int, InventoryItem> items;
        Dictionary<int, Item> itemTypes;

        public Inventory(int ID, bool LoadNow)
        {
            this.ID = ID;
            if (LoadNow)
            {
                Load();
            }
        }

        internal Dictionary<int, InventoryItem> Items
        {
            get
            {
                return items;
            }
        }

        public int ID
        {
            get
            {
                return id;
            }

            private set
            {
                id = value;
            }
        }

        public bool IsSaved
        {
            get
            {
                return saved;
            }

            private set
            {
                saved = value;
            }
        }

        public bool IsLoaded
        {
            get
            {
                return loaded;
            }

            private set
            {
                loaded = value;
            }
        }

        override public bool Load()
        {
            string DatabaseCommand = String.Format("SELECT id, item_id, date_created FROM inventory_item WHERE inventory_id = {0}", ID);
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            foreach (DataRow Row in ResultsTable.Rows)
            {
                int id = Row.IntCol("id");
                int itemID = Row.IntCol("item_id");
                DateTime dateCreated = Row.DateTimeCol("date_created");


                if (itemTypes.ContainsKey(itemID) == false)
                {
                    itemTypes.Add(itemID, new Item(itemID, false));
                }
                Items.Add(id, new InventoryItem(id, itemTypes[itemID], dateCreated));

            }
            IsLoaded = true;


            return IsLoaded;
        }

        public void AddItem(int ItemID)
        {
            throw new NotImplementedException();
        }
    }
}

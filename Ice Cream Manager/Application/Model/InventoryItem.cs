/// <project>IceCreamManager</project>
/// <module>InventoryItem</module>
/// <author>Marc King</author>
/// <date_created>2016-04-07</date_created>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamManager
{
    class InventoryItem
    {
        DatabaseManager Database = DatabaseManager.DatabaseReference;

        int id;
        Item itemType;
        DateTime dateCreated;

        public InventoryItem(int ID, Item ItemType, DateTime DateCreated)
        {
            this.ID = ID;
            this.ItemType = ItemType;
            this.DateCreated = DateCreated;
        }

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
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
    }
}

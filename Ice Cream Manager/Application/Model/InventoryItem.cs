/// <project> IceCreamManager </project>
/// <module> InventoryItem </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   An instance of an Item that exists within a trucks inventory and tracks its expiration. 
    /// </summary>
    public class InventoryItem : DatabaseEntity
    {
        private InventoryItemFactory inventoryItemFactory = InventoryItemFactory.Reference;

        private int itemID = 0;
        private int truckID = 0;
        private DateTime dateCreated;

        private Item item;
        private Truck truck;

        public InventoryItem()
        {
            ID = 0;
            dateCreated = DateTime.Now;
        }

        /// <summary>
        ///   Date the InventoryItem was created; used for tracking expiration. 
        /// </summary>
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

        /// <summary>
        ///   The Item stereotype of which this InventoryItem is an instance. 
        /// </summary>
        public Item Item
        {
            get
            {
                if (item == null && itemID != 0) item = inventoryItemFactory.LoadItem(itemID);
                return item;
            }
        }

        /// <summary>
        ///   The identity of the Item stereotype of which this InventoryItem is an instance. 
        /// </summary>
        public int ItemID
        {
            get
            {
                return itemID;
            }

            set
            {
                // BUG: Check items existence before changing.
                itemID = value;
            }
        }

        /// <summary>
        ///   The truck on which this InventoryItem is carried. 
        /// </summary>
        public int TruckID
        {
            get
            {
                return truckID;
            }

            set
            {
                // BUG: Check trucks existence before changing.
                truckID = value;
            }
        }

        /// <summary>
        ///   The Truck to which this InventoryItem belongs. 
        /// </summary>
        public Truck Truck
        {
            get
            {
                if (truck == null && truckID != 0) truck = inventoryItemFactory.LoadTruck(truckID);
                return truck;
            }
        }

        public override bool Save()
        {
            return InventoryItemFactory.Reference.Save(this);
        }
    }
}

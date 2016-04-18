/// <project> IceCreamManager </project>
/// <module> ItemWaste </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamManager.Model
{
    public class ItemWaste : DatabaseEntity
    {
        ItemWasteFactory itemWasteFactory = ItemWasteFactory.Reference;

        private int itemID = 0;
        private int truckID = 0;
        private int routeID = 0;
        private DateTime dateExpired;

        private Item item = null;
        private Truck truck = null;
        private Route route = null;

        public int ItemID
        {
            get
            {
                return itemID;
            }
            set
            {
                if (value != itemID) item = null;
                itemID = value;
                IsSaved = false;
            }
        }

        public int TruckID
        {
            get
            {
                return truckID;
            }
            set
            {
                if (value != truckID) truck = null;
                truckID = value;
                IsSaved = false;
            }
        }

        public int RouteID
        {
            get
            {
                return routeID;
            }
            set
            {
                if (value != routeID) route = null;
                routeID = value;
                IsSaved = false;
            }
        }

        public DateTime DateExpired
        {
            get
            {
                return dateExpired;
            }
            set
            {
                dateExpired = value;
                IsSaved = false;
            }
        }

        public Item Item
        {
            get
            {
                if (item == null) item = itemWasteFactory.LoadItem(itemID);
                return item;
            }
        }

        public Truck Truck
        {
            get
            {
                if (truck == null) truck = itemWasteFactory.LoadTruck(truckID);
                return truck;
            }
        }

        public Route Route
        {
            get
            {
                if (route == null) route = itemWasteFactory.LoadRoute(routeID);
                return route;
            }
        }

        public override bool Save()
        {
            return ItemWasteFactory.Reference.Save(this);
        }
    }
}

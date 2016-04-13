/// <project> IceCreamManager </project>
/// <module> Sale </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;

namespace IceCreamManager.Model
{
    public class Sale : DatabaseEntity
    {
        SaleFactory saleFactory = SaleFactory.Reference;

        private int itemID = 0;
        private int truckID = 0;
        private int routeID = 0;
        private int driverID = 0;
        private DateTime dateSold;

        private Item item = null;
        private Truck truck = null;
        private Route route = null;
        private Driver driver = null;

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

        public int DriverID
        {
            get
            {
                return driverID;
            }
            set
            {
                if (value != driverID) driver = null;
                driverID = value;
                IsSaved = false;
            }
        }

        public DateTime DateSold
        {
            get
            {
                return dateSold;
            }
            set
            {
                dateSold = value;
                IsSaved = false;
            }
        }

        public Item Item
        {
            get
            {
                if (item == null) item = saleFactory.LoadItem(itemID);
                return item;
            }
        }

        public Truck Truck
        {
            get
            {
                if (truck == null) truck = saleFactory.LoadTruck(truckID);
                return truck;
            }
        }

        public Route Route
        {
            get
            {
                if (route == null) route = saleFactory.LoadRoute(truckID);
                return route;
            }
        }

        public Driver Driver
        {
            get
            {
                if (driver == null) driver = saleFactory.LoadDriver(driverID);
                return driver;
            }
        }
    }
}

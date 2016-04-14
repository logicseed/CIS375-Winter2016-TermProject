
using System;
/// <project> IceCreamManager </project>
/// <module> Truck </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>
using System.Collections.Generic;
using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Represents a complete ice cream truck with inventory, driver, and route. 
    /// </summary>
    public class Truck : DatabaseEntity
    {
        private TruckFactory truckFactory = TruckFactory.Reference;

        private int number;
        private int routeID = 0;
        private int driverID = 0;
        private double fuelRate;

        private List<InventoryItem> inventory = null;
        private Route route = null;
        private Driver driver = null;

        /// <summary>
        ///   User provided number to distinguish the Truck. Changing this value marks a truck to be deleted. 
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (value < Requirement.MinTruckNumber) throw new TruckNumberException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxTruckNumber) throw new TruckNumberException(Outcome.ValueTooLarge);
                number = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        /// <summary>
        ///   The amount of currency this Truck spends on fuel per mile. Changing this value marks a truck to be deleted. 
        /// </summary>
        public double FuelRate
        {
            get
            {
                return fuelRate;
            }

            set
            {
                if (value < Requirement.MinTruckFuelRate) throw new TruckFuelRateException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxTruckFuelRate) throw new TruckFuelRateException(Outcome.ValueTooLarge);
                fuelRate = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        /// <summary>
        ///   A collection of InventoryItems that represent this Truck's inventory. 
        /// </summary>
        public List<InventoryItem> Inventory
        {
            get
            {
                if (inventory == null) inventory = truckFactory.LoadInventoryList(ID);
                return inventory;
            }

            protected set
            { }
        }

        /// <summary>
        ///   The unique identity of the Route assigned to this Truck. 
        /// </summary>
        public int RouteID
        {
            get
            {
                return routeID;
            }
            set
            {
                routeID = value;
                IsSaved = false;
            }
        }

        /// <summary>
        ///   A reference to this truck's Route in memory. 
        /// </summary>
        public Route Route
        {
            get
            {
                if (route == null) route = truckFactory.LoadTruckRoute(routeID);
                return route;
            }

            protected set
            { }
        }

        /// <summary>
        ///   The unique identity of the Driver assigned to this truck. 
        /// </summary>
        public int DriverID
        {
            get
            {
                return driverID;
            }
            set
            {
                driverID = value;
                IsSaved = false;
            }
        }

        /// <summary>
        ///   A reference to this truck's Driver in memory. 
        /// </summary>
        public Driver Driver
        {
            get
            {
                if (driver == null) driver = truckFactory.LoadTruckDriver(driverID);
                return driver;
            }
            set
            { }
        }

        
    }
}

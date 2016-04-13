/// <project> IceCreamManager </project>
/// <module> SalaryCost </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;

namespace IceCreamManager.Model
{
    class SalaryCost : DatabaseEntity
    {
        SalaryCostFactory salaryCostFactory = SalaryCostFactory.Reference;

        private int routeID = 0;
        private int driverID = 0;
        private DateTime dateWorked;

        private Route route = null;
        private Driver driver = null;

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

        public DateTime DateWorked
        {
            get
            {
                return dateWorked;
            }
            set
            {
                dateWorked = value;
                IsSaved = false;
            }
        }

        public Route Route
        {
            get
            {
                if (route == null) route = salaryCostFactory.LoadRoute(routeID);
                return route;
            }
        }

        public Driver Driver
        {
            get
            {
                if (driver == null) driver = salaryCostFactory.LoadDriver(driverID);
                return driver;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamManager.Model
{
    public sealed class Factory
    {
        #region Singleton
        private static readonly Factory SingletonInstance = new Factory();
        public static Factory Reference { get { return SingletonInstance; } }
        private Factory() { }
        #endregion Singleton

        public static CityFactory City { get { return CityFactory.Reference; } }
        public static DriverFactory Driver { get { return DriverFactory.Reference; } }
        public static ItemFactory Item { get { return ItemFactory.Reference; } }
        public static RouteFactory Route { get { return RouteFactory.Reference; } }
        public static TruckFactory Truck { get { return TruckFactory.Reference; } }
        public static InventoryItemFactory InventoryItem { get { return InventoryItemFactory.Reference; } }
        public static LogEntryFactory Log { get { return LogEntryFactory.Reference; } }
    }
}

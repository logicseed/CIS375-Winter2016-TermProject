/// <project> IceCreamManager </project>
/// <module> Factory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-18 </date_created>

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
        public static SaleFactory Sale { get { return SaleFactory.Reference; } }
        public static ItemWasteFactory ItemWaste { get { return ItemWasteFactory.Reference; } }
        public static FuelUseFactory FuelUse { get { return FuelUseFactory.Reference; } }
        public static SalaryCostFactory SalaryCost { get { return SalaryCostFactory.Reference; } }
        public static BatchHistoryEntryFactory BatchHistory { get { return BatchHistoryEntryFactory.Reference; } }
    }
}

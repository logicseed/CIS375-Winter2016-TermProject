/// <project> IceCreamManager </project>
/// <module> EntityType </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Represents an entity type in the log entries. 
    /// </summary>
    public enum EntityType
    {
        None,
        City,
        Route,
        Truck,
        Item,
        InventoryItem,
        Inventory,
        Preset,
        Poll,
        Sale,
        Driver,
        BatchFile,
    }
}

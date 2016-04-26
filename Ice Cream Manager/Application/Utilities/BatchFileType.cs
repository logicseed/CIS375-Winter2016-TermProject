﻿/// <project> IceCreamManager </project>
/// <module> BatchFileType </module>
/// <author> Marc King and Rodney Lewis </author>
/// <date_created> 2016-04-10 </date_created>

namespace IceCreamManager
{
    /// <summary>
    ///   The type of batch file. 
    /// </summary>
    public enum BatchFileType
    {
        City = 1,
        CityExtension = 2,
        Route = 3,
        Driver = 4,
        Truck = 5,
        TruckFuel = 6,
        TruckInventory = 7,
        OverallInventory = 8,
        OverallIventoryExtension = 9,
        TruckDriver = 10,
        TruckRoute = 11,
        Sales = 12,

        /*
        City = 1,
        CityExtension = 2,
        Route = 3,
        Truck = 4,
        TruckRoute = 5,
        TruckInventory = 6,
        Sales = 7,
        TruckFuel = 8,
        Item = 9,
        ItemExtension = 10,
        Driver = 11
        */
    }
}

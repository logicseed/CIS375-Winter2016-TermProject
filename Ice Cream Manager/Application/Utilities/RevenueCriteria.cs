/// <project> IceCreamManager </project>
/// <module> RevenueCriteria </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-24 </date_created>

using System;

namespace IceCreamManager
{
    /// <summary>
    /// Allows the Revenue form to pass multiple query criteria to the table builder.
    /// </summary>
    public struct RevenueCriteria
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public int RouteNumber;
        public string CityLabel;
        public int TruckNumber;
        public int DriverNumber;
        public int ItemNumber;
    }
}

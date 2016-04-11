/// <project> IceCreamManager </project>
/// <module> RequirementConstants </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

namespace IceCreamManager
{
    public static class Requirement
    {
        // Common requirements

        public static int MinNumber { get { return Properties.Requirements.Default.MinNumber; } }
        public static int MaxNumber { get { return Properties.Requirements.Default.MaxNumber; } }
        public static int MaxMaxDeafultItems { get { return Properties.Requirements.Default.MaxDefaultItems; } }
        public static int MaxItems { get { return Properties.Requirements.Default.MaxItems; } }
        public static int MinLabelLength { get { return Properties.Requirements.Default.MaxLabelLength; } }
        public static int MaxLabelLength { get { return Properties.Requirements.Default.MaxLabelLength; } }
        public static int MinNameLength { get { return Properties.Requirements.Default.MinNameLength; } }
        public static int MaxNameLength { get { return Properties.Requirements.Default.MaxNameLength; } }
        public static int MinStateLength { get { return Properties.Requirements.Default.MinStateLength; } }
        public static int MaxStateLength { get { return Properties.Requirements.Default.MaxStateLength; } }
        public static double MinFuelCost { get { return Properties.Requirements.Default.MinFuelCost; } }
        public static double MaxFuelCost { get { return Properties.Requirements.Default.MaxFuelCost; } }
        public static double MinHourCost { get { return Properties.Requirements.Default.MinHourCost; } }
        public static double MaxHourCost { get { return Properties.Requirements.Default.MaxHourCost; } }
        public static double MaxPrice { get { return Properties.Requirements.Default.MaxPrice; } }
        public static double MinPrice { get { return Properties.Requirements.Default.MinPrice; } }
        public static int MinLifetime { get { return Properties.Requirements.Default.MinItemLifetime; } }
        public static int MaxLifetime { get { return Properties.Requirements.Default.MaxItemLifetime; } }
        public static int MaxCacheHours { get { return Properties.Requirements.Default.MaxCacheHours; } }
        public static int MaxCacheMinutes { get { return Properties.Requirements.Default.MaxCacheMinutes; } }
        public static int MaxCacheSeconds { get { return Properties.Requirements.Default.MaxCacheSeconds; } }
        public static int MaxRouteCities { get { return Properties.Requirements.Default.MaxRouteCities; } }

        public static int MinID => Properties.Requirements.Default.MinID;

        public static int MinItemNumber => Properties.Requirements.Default.MinItemNumber;

        public static int MaxItemNumber => Properties.Requirements.Default.MaxItemNumber;

        public static double MinItemPrice => Properties.Requirements.Default.MinItemPrice;

        public static double MaxItemPrice => Properties.Requirements.Default.MaxItemPrice;

        public static int MinItemDescriptionLength => Properties.Requirements.Default.MinItemDescriptionLength;

        public static int MaxItemDescriptionLength => Properties.Requirements.Default.MaxItemDescriptionLength;

        public static int MinItemLifetime => Properties.Requirements.Default.MinItemLifetime;

        public static int MaxItemLifetime => Properties.Requirements.Default.MaxItemLifetime;

        public static int MinItemQuantity => Properties.Requirements.Default.MinItemQuantity;

        public static int MaxItemQuantity => Properties.Requirements.Default.MaxItemQuantity;
    }
}

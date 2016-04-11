/// <project> IceCreamManager </project>
/// <module> RequirementConstants </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

namespace IceCreamManager
{
    public static class Requirement
    {
        // Common requirements

        public static int MaxCacheHours => Properties.Requirements.Default.MaxCacheHours;

        public static int MaxCacheMinutes => Properties.Requirements.Default.MaxCacheMinutes;

        public static int MaxCacheSeconds => Properties.Requirements.Default.MaxCacheSeconds;

        // Item requirements

        public static int MaxInventoryItems => Properties.Requirements.Default.MaxInventoryItems;

        public static int MaxInventoryDefaultItems => Properties.Requirements.Default.MaxInventoryDefaultItems;

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

        // City requirements
        public static int MinCityLabelLength => Properties.Requirements.Default.MinCityLabelLength;

        public static int MaxCityLabelLength => Properties.Requirements.Default.MaxCityLabelLength;

        public static int MinCityNameLength => Properties.Requirements.Default.MinCityNameLength;

        public static int MaxCityNameLength => Properties.Requirements.Default.MaxCityNameLength;

        public static int MinCityStateLength => Properties.Requirements.Default.MinCityStateLength;

        public static int MaxCityStateLength => Properties.Requirements.Default.MaxCityStateLength;

        public static double MinCityHours => Properties.Requirements.Default.MinCityHours;

        public static double MaxCityHours => Properties.Requirements.Default.MaxCityHours;

        public static double MinCityMiles => Properties.Requirements.Default.MinCityMiles;

        public static double MaxCityMiles => Properties.Requirements.Default.MaxCityMiles;

        public static int MinDriverNumber => Properties.Requirements.Default.MinDriverNumber;

        public static int MaxDriverNumber => Properties.Requirements.Default.MaxDriverNumber;

        public static int MinDriverNameLength => Properties.Requirements.Default.MinDriverNameLength;

        public static int MaxDriverNameLength => Properties.Requirements.Default.MaxDriverNameLength; // BUG: Check to make sure this is right.

        public static double MinDriverHourlyRate => Properties.Requirements.Default.MinDriverHourlyRate;

        public static double MaxDriverHourlyRate => Properties.Requirements.Default.MaxDriverHourlyRate;
    }
}

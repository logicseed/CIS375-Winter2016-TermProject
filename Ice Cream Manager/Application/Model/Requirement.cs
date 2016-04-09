/// <project>IceCreamManager</project>
/// <module>RequirementConstants</module>
/// <author>Marc King</author>
/// <date_created>2016-04-07</date_created>

using System;

namespace IceCreamManager
{
    public static class Requirement
    {
        public static int MinID {  get { return Properties.Requirements.Default.MinID; } }
        public static int MinNumber { get { return Properties.Requirements.Default.MinNumber; } }
        public static int MaxNumber { get { return Properties.Requirements.Default.MaxNumber; } }
        public static int MaxMaxDeafultItems { get { return Properties.Requirements.Default.MaxDefaultItems; } }
        public static int MaxItems { get { return Properties.Requirements.Default.MaxItems; } }
        public static int MaxDescription { get { return Properties.Requirements.Default.MaxDescription; } }
        public static int MaxName { get { return Properties.Requirements.Default.MaxName; } }
        public static int MaxLabel { get { return Properties.Requirements.Default.MaxLabel; } }
        public static double MaxPrice { get { return Properties.Requirements.Default.MaxPrice; } }
        public static double MinPrice { get { return Properties.Requirements.Default.MinPrice; } }
        public static int MinLifetime { get { return Properties.Requirements.Default.MinLifetime; } }
        public static int MaxLifetime { get { return Properties.Requirements.Default.MaxLifetime; } }
        public static int MaxCacheHours { get { return Properties.Requirements.Default.MaxCacheHours; } }
        public static int MaxCacheMinutes { get { return Properties.Requirements.Default.MaxCacheMinutes; } }
        public static int MaxCacheSeconds { get { return Properties.Requirements.Default.MaxCacheSeconds; } }
    }
}

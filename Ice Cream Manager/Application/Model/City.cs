/// <project> IceCreamManager </project>
/// <module> City </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Represents a zone of a city that can be part of a route. 
    /// </summary>
    public class City : DatabaseEntity
    {
        private string label;
        private string name;
        private string state;
        private double miles;
        private double hours;

        public City()
        {
            ID = 0;
        }

        /// <summary>
        ///   User provided label to distinguish the zone. Changing this value marks a city to be deleted. 
        /// </summary>
        public string Label
        {
            get
            {
                return label;
            }

            set
            {
                if (value.Length < Requirement.MinCityLabelLength) throw new CityLabelException(Outcome.ValueTooSmall);
                if (value.Length > Requirement.MaxCityLabelLength) throw new CityLabelException(Outcome.ValueTooLarge);

                label = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        /// <summary>
        ///   Name of the city the zone belongs to. Changing this value marks a city to be deleted. 
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value.Length < Requirement.MinCityNameLength) throw new CityNameException(Outcome.ValueTooSmall);
                if (value.Length > Requirement.MaxCityNameLength) throw new CityNameException(Outcome.ValueTooLarge);

                name = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        /// <summary>
        ///   Name of the state the zone belongs to. Changing this value marks a city to be deleted. 
        /// </summary>
        public string State
        {
            get
            {
                return state;
            }

            set
            {
                if (value.Length < Requirement.MinCityStateLength) throw new CityStateException(Outcome.ValueTooSmall);
                if (value.Length > Requirement.MaxCityStateLength) throw new CityStateException(Outcome.ValueTooLarge);

                state = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        /// <summary>
        ///   Number of miles required to service the zone. Changing this value marks a city to be deleted. 
        /// </summary>
        public double Miles
        {
            get
            {
                return miles;
            }

            set
            {
                if (value < Requirement.MinCityMiles) throw new CityMilesException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxCityMiles) throw new CityMilesException(Outcome.ValueTooLarge);

                miles = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        /// <summary>
        ///   Number of hours required to service the zone. Changing this value marks a city to be deleted. 
        /// </summary>
        public double Hours
        {
            get
            {
                return hours;
            }

            set
            {
                if (value < Requirement.MinCityHours) throw new CityHoursException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxCityHours) throw new CityHoursException(Outcome.ValueTooLarge);

                hours = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        public override bool Save()
        {
            return Factory.City.Save(this);
        }
    }
}

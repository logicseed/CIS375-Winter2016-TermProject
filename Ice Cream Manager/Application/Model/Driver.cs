/// <project> IceCreamManager </project>
/// <module> Driver </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Represents the driver of an ice cream truck. 
    /// </summary>
    public class Driver : DatabaseEntity
    {
        private int number;
        private string name;
        private double hourlyRate;

        public Driver()
        {
            ID = 0;
        }

        /// <summary>
        ///   User provided number to distinguish the driver. Changing this value marks an item to be deleted. 
        /// </summary>
        public override int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (value < Requirement.MinDriverNumber) throw new DriverNumberException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxDriverNumber) throw new DriverNumberException(Outcome.ValueTooLarge);

                number = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        /// <summary>
        ///   User provided name to distinguish the driver. Changing this value marks an item to be deleted. 
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value.Length < Requirement.MinDriverNameLength) throw new DriverNameException(Outcome.ValueTooSmall);
                if (value.Length > Requirement.MaxDriverNameLength) throw new DriverNameException(Outcome.ValueTooLarge);

                name = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        /// <summary>
        ///   The amount of currency a driver is paid per hour. Changing this value marks an item to be deleted. 
        /// </summary>
        public double HourlyRate
        {
            get
            {
                return hourlyRate;
            }

            set
            {
                if (value < Requirement.MinDriverHourlyRate) throw new DriverHourlyRateException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxDriverHourlyRate) throw new DriverHourlyRateException(Outcome.ValueTooLarge);

                hourlyRate = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        public override bool Save()
        {
            return Factory.Driver.Save(this);
        }
    }
}

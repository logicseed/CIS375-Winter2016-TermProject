/// <project> IceCreamManager </project>
/// <module> Driver </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Contains the properties of an Driver. 
    /// </summary>
    /// <remarks>
    ///   A class was chosen over struct because of how struct will be boxed when passing as the implemented type.
    /// </remarks>
    public class DriverProperties : DatabaseEntityProperties
    {
        public int Number;
        public string Name;
        public double HourlyRate;
    }

    /// <summary>
    ///   Represents the driver of an ice cream truck. 
    /// </summary>
    public class Driver : DatabaseEntity
    {
        private DriverProperties DriverValues = new DriverProperties();

        public Driver()
        {
            ID = 0;
        }

        public Driver(int id)
        {
            Load(id);
        }

        /// <summary>
        ///   User provided number to distinguish the driver. Changing this value marks an item to be deleted. 
        /// </summary>
        public int Number
        {
            get
            {
                return DriverValues.Number;
            }

            set
            {
                if (value < Requirement.MinDriverNumber) throw new DriverNumberException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxDriverNumber) throw new DriverNumberException(Outcome.ValueTooLarge);

                DriverValues.Number = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   User provided name to distinguish the driver. Changing this value marks an item to be deleted. 
        /// </summary>
        public string Name
        {
            get
            {
                return DriverValues.Name;
            }

            set
            {
                if (value.Length < Requirement.MinDriverNameLength) throw new DriverNameException(Outcome.ValueTooSmall);
                if (value.Length > Requirement.MaxDriverNameLength) throw new DriverNameException(Outcome.ValueTooLarge);

                DriverValues.Name = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   The amount of currency a driver is paid per hour. Changing this value marks an item to be deleted. 
        /// </summary>
        public double HourlyRate
        {
            get
            {
                return DriverValues.HourlyRate;
            }

            set
            {
                if (value < Requirement.MinDriverHourlyRate) throw new DriverHourlyRateException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxDriverHourlyRate) throw new DriverHourlyRateException(Outcome.ValueTooLarge);

                DriverValues.HourlyRate = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   The SQL command used to create a driver in the database with this object's properties. 
        /// </summary>
        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (Number,Name,HourlyRate) VALUES ({Number},'{Name}',{HourlyRate})";

        /// <summary>
        ///   The name of the database table that stores drivers. 
        /// </summary>
        protected override string TableName => "Driver";

        /// <summary>
        ///   The SQL command used to update a driver in the database with this object's properties. 
        /// </summary>
        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (Number,Name,HourlyRate) VALUES ({Number},'{Name}',{HourlyRate})";

        /// <summary>
        ///   Fills this driver's properties with values. 
        /// </summary>
        /// <param name="entityProperties"> A DatabaseEntityProperties object with the values to use. </param>
        /// <returns> Whether or not the driver was successfully filled with the values. </returns>
        public override bool Fill(DatabaseEntityProperties entityProperties)
        {
            DriverValues = (DriverProperties)entityProperties;

            return true;
        }

        /// <summary>
        ///   Load a driver from the database based on the provided identity. 
        /// </summary>
        /// <param name="id"> The unique driver identity. </param>
        /// <returns> Whether or not the driver was successfully loaded. </returns>
        public override bool Load(int id
            )
        {
            this.ID = id;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {id}");

            if (ResultsTable.Rows.Count == 0) return false;

            Number = ResultsTable.Row().Col("number");
            Name = ResultsTable.Row().Col<string>("name");
            HourlyRate = ResultsTable.Row().Col<double>("hourly_rate");

            return true;
        }
    }
}

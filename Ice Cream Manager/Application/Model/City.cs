/// <project> IceCreamManager </project>
/// <module> City </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Contains the properties of a City. 
    /// </summary>
    /// <remarks>
    ///   A class was chosen over struct because of how struct will be boxed when passing as the implemented type.
    /// </remarks>
    public class CityProperties : DatabaseEntityProperties
    {
        public string Label;
        public string Name;
        public string State;
        public double Miles;
        public double Hours;
    }

    /// <summary>
    ///   Represents a zone of a city that can be part of a route. 
    /// </summary>
    public class City : DatabaseEntity
    {
        private CityProperties CityValues = new CityProperties();

        public City()
        {
            ID = 0;
        }

        public City(int ID)
        {
            Load(ID);
        }

        /// <summary>
        ///   User provided label to distinguish the zone. Changing this value marks a city to be deleted. 
        /// </summary>
        public string Label
        {
            get
            {
                return CityValues.Label;
            }

            set
            {
                if (value.Length < Requirement.MinCityLabelLength) throw new CityLabelInvalidException(Outcome.ValueTooSmall);
                if (value.Length > Requirement.MaxCityLabelLength) throw new CityLabelInvalidException(Outcome.ValueTooLarge);

                CityValues.Label = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   Name of the city the zone belongs to. Changing this value marks a city to be deleted. 
        /// </summary>
        public string Name
        {
            get
            {
                return CityValues.Name;
            }

            set
            {
                if (value.Length < Requirement.MinCityNameLength) throw new CityNameInvalidException(Outcome.ValueTooSmall);
                if (value.Length > Requirement.MaxCityNameLength) throw new CityNameInvalidException(Outcome.ValueTooLarge);

                CityValues.Name = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   Name of the state the zone belongs to. Changing this value marks a city to be deleted. 
        /// </summary>
        public string State
        {
            get
            {
                return CityValues.State;
            }

            set
            {
                if (value.Length < Requirement.MinCityStateLength) throw new CityStateInvalidException(Outcome.ValueTooSmall);
                if (value.Length > Requirement.MaxCityStateLength) throw new CityStateInvalidException(Outcome.ValueTooLarge);

                CityValues.State = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   Number of miles required to service the zone. Changing this value marks a city to be deleted. 
        /// </summary>
        public double Miles
        {
            get
            {
                return CityValues.Miles;
            }

            set
            {
                if (value < Requirement.MinCityMiles) throw new CityMilesInvalidException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxCityMiles) throw new CityMilesInvalidException(Outcome.ValueTooLarge);

                CityValues.Miles = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   Number of hours required to service the zone. Changing this value marks a city to be deleted. 
        /// </summary>
        public double Hours
        {
            get
            {
                return CityValues.Hours;
            }

            set
            {
                if (value < Requirement.MinCityHours) throw new CityHoursInvalidException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxCityHours) throw new CityHoursInvalidException(Outcome.ValueTooLarge);

                CityValues.Hours = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   The name of the database table that stores cities. 
        /// </summary>
        protected override string TableName => "City";

        /// <summary>
        ///   The SQL command used to update a city in the database with this object's properties. 
        /// </summary>
        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (Label,Name,State,Miles,Hours) VALUES ({Label},'{Name}',{State},{Miles},{Hours}) WHERE ID = {ID}";

        /// <summary>
        ///   The SQL command used to create a city in the database with this object's properties. 
        /// </summary>
        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (Label,Name,State,Miles,Hours) VALUES ({Label},'{Name}',{State},{Miles},{Hours})";

        /// <summary>
        ///   Load a city from the database based on the provided identity. 
        /// </summary>
        /// <param name="id"> The unique city identity. </param>
        /// <returns> Whether or not the city was successfully loaded. </returns>
        public override bool Load(int id)
        {
            ID = id;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE ID = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            Label = ResultsTable.Row().Col<string>("Label");
            Name = ResultsTable.Row().Col<string>("Name");
            State = ResultsTable.Row().Col<string>("State");
            Miles = ResultsTable.Row().Col<double>("Miles");
            Hours = ResultsTable.Row().Col<double>("Hours");

            return true;
        }

        /// <summary>
        ///   Fills this city's properties with values. 
        /// </summary>
        /// <param name="entityProperties"> A DatabaseEntityProperties object with the values to use. </param>
        /// <returns> Whether or not the city was successfully filled with the values. </returns>
        public override bool Fill(DatabaseEntityProperties entityProperties)
        {
            CityValues = (CityProperties)entityProperties;

            return true;
        }
    }
}

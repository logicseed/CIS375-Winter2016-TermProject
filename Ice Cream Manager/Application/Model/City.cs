/// <project> IceCreamManager </project>
/// <module> City </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    // TODO: File needs comments.
    public class CityProperties : DatabaseEntityProperties
    {
        public string Label;
        public string Name;
        public string State;
        public double Miles;
        public double Hours;
    }

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

        public string Label
        {
            get
            {
                return CityValues.Label;
            }

            set
            {
                if (value.Length < Requirement.MinLabelLength)
                {
                    throw new CityLabelInvalidException(Outcome.ValueTooSmall);
                }
                else if (value.Length > Requirement.MaxLabelLength)
                {
                    throw new CityLabelInvalidException(Outcome.ValueTooLarge);
                }

                CityValues.Label = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        public string Name
        {
            get
            {
                return CityValues.Name;
            }

            set
            {
                if (value.Length < Requirement.MinNameLength)
                {
                    throw new CityNameInvalidException(Outcome.ValueTooSmall);
                }
                else if (value.Length > Requirement.MaxNameLength)
                {
                    throw new CityNameInvalidException(Outcome.ValueTooLarge);
                }

                CityValues.Name = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        public string State
        {
            get
            {
                return CityValues.State;
            }

            set
            {
                if (value.Length < Requirement.MinStateLength)
                {
                    throw new CityStateInvalidException(Outcome.ValueTooSmall);
                }
                else if (value.Length > Requirement.MaxStateLength)
                {
                    throw new CityStateInvalidException(Outcome.ValueTooLarge);
                }

                CityValues.State = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        public double Miles
        {
            get
            {
                return CityValues.Miles;
            }

            set
            {
                if (value < Requirement.MinPrice)
                {
                    throw new CityMilesInvalidException(Outcome.ValueTooSmall);
                }
                else if (value > Requirement.MaxPrice)
                {
                    throw new CityMilesInvalidException(Outcome.ValueTooLarge);
                }

                CityValues.Miles = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        public double Hours
        {
            get
            {
                return CityValues.Hours;
            }

            set
            {
                if (value < Requirement.MinPrice)
                {
                    throw new CityHoursInvalidException(Outcome.ValueTooSmall);
                }
                else if (value > Requirement.MaxPrice)
                {
                    throw new CityHoursInvalidException(Outcome.ValueTooLarge);
                }

                CityValues.Hours = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        protected override string TableName => "city";

        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (label,name,state,miles,hours) VALUES ({Label},'{Name}',{State},{Miles},{Hours}) WHERE id = {ID}";

        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (label,name,state,miles,hours) VALUES ({Label},'{Name}',{State},{Miles},{Hours})";

        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            Label = ResultsTable.Row().Col<string>("label");
            Name = ResultsTable.Row().Col<string>("name");
            State = ResultsTable.Row().Col<string>("state");
            Miles = ResultsTable.Row().Col<double>("miles");
            Hours = ResultsTable.Row().Col<double>("hours");

            return true;
        }

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            CityValues = (CityProperties)EntityProperties;

            return true;
        }
    }
}

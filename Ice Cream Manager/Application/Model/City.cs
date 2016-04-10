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
        public double FuelCost;
        public double HourCost;
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

        public double FuelCost
        {
            get
            {
                return CityValues.FuelCost;
            }

            set
            {
                if (value < Requirement.MinStateLength)
                {
                    throw new CityFuelCostInvalidException(Outcome.ValueTooSmall);
                }
                else if (value > Requirement.MaxStateLength)
                {
                    throw new CityFuelCostInvalidException(Outcome.ValueTooLarge);
                }

                CityValues.FuelCost = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        public double HourCost
        {
            get
            {
                return CityValues.HourCost;
            }

            set
            {
                if (value < Requirement.MinStateLength)
                {
                    throw new CityFuelCostInvalidException(Outcome.ValueTooSmall);
                }
                else if (value > Requirement.MaxStateLength)
                {
                    throw new CityFuelCostInvalidException(Outcome.ValueTooLarge);
                }

                CityValues.HourCost = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        protected override string TableName => "city";

        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (label,name,state,fuel_cost,hour_cost) VALUES ({Label},'{Name}',{State},{FuelCost},{HourCost}) WHERE id = {ID}";

        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (label,name,state,fuel_cost,hour_cost) VALUES ({Label},'{Name}',{State},{FuelCost},{HourCost})";

        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            Label = ResultsTable.Row().Col<string>("label");
            Name = ResultsTable.Row().Col<string>("name");
            State = ResultsTable.Row().Col<string>("state");
            FuelCost = ResultsTable.Row().Col<double>("fuel_cost");
            HourCost = ResultsTable.Row().Col<double>("hour_cost");

            return true;
        }

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            CityValues = (CityProperties)EntityProperties;

            return true;
        }
    }
}

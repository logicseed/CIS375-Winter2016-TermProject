/// <project> IceCreamManager </project>
/// <module> City </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System.Data;
using IceCreamManager.Controller;
using IceCreamManager.Exceptions;

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
        private string label;
        private string name;
        private string state;
        private double fuelCost;
        private double hourCost;

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
                return label;
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

                label = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        public string Name
        {
            get
            {
                return name;
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

                name = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        public string State
        {
            get
            {
                return state;
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

                state = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        public double FuelCost
        {
            get
            {
                return fuelCost;
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

                fuelCost = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        public double HourCost
        {
            get
            {
                return hourCost;
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

                hourCost = value;
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
            CityProperties CityValues = EntityProperties as CityProperties;

            Label = CityValues.Label;
            Name = CityValues.Name;
            State = CityValues.State;
            FuelCost = CityValues.FuelCost;
            HourCost = CityValues.HourCost;

            return true;
        }
    }
}

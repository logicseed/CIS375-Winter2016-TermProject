/// <project> IceCreamManager </project>
/// <module> Driver </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    public class DriverProperties : DatabaseEntityProperties
    {
        public int Number;
        public string Name;
        public double HourlyRate;
    }

    public class Driver : DatabaseEntity
    {
        private DriverProperties DriverValues = new DriverProperties();

        public Driver()
        {
            ID = 0;
        }

        public Driver(int ID)
        {
            Load(ID);
        }

        public int Number
        {
            get
            {
                return DriverValues.Number;
            }

            set
            {
                DriverValues.Number = value;
            }
        }

        public string Name
        {
            get
            {
                return DriverValues.Name;
            }

            set
            {
                DriverValues.Name = value;
            }
        }

        public double HourlyRate
        {
            get
            {
                return DriverValues.HourlyRate;
            }

            set
            {
                DriverValues.HourlyRate = value;
            }
        }

        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (number,name,hourly_rate) VALUES ({Number},'{Name}',{HourlyRate})";

        protected override string TableName => "driver";

        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (number,name,hourly_rate) VALUES ({Number},'{Name}',{HourlyRate})";

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            DriverValues = (DriverProperties)EntityProperties;

            return true;
        }

        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            Number = ResultsTable.Row().Col("number");
            Name = ResultsTable.Row().Col<string>("name");
            HourlyRate = ResultsTable.Row().Col<double>("hourly_rate");

            return true;
        }
    }
}

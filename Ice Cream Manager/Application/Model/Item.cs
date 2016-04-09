/// <project> IceCreamManager </project>
/// <module> Item </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    // COMMENT: A comment needs to be created here.
    internal class ItemProperties : DatabaseEntityProperties
    {
        public int Number;
        public string Description;
        public double Price;
        public int Lifetime;
    }

    // COMMENT: A comment needs to be created here.
    internal class Item : DatabaseEntity
    {
        private int number;
        private string description;
        private double price;
        private int lifetime;

        public Item(int ID)
        {
            Load(ID);
        }

        // COMMENT: A comment needs to be created here.
        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (value < Requirement.MinNumber || value > Requirement.MaxNumber)
                {
                    throw new ArgumentOutOfRangeException("Number out of range.");
                }
                number = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        // COMMENT: A comment needs to be created here.
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value.Length > Requirement.MaxDescription)
                {
                    throw new ArgumentOutOfRangeException("Description longer than 30 characters.");
                }
                description = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        // COMMENT: A comment needs to be created here.
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value < Requirement.MinPrice || value > Requirement.MaxPrice)
                {
                    throw new ArgumentOutOfRangeException("Price out of range.");
                }
                price = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        // COMMENT: A comment needs to be created here.
        public int Lifetime
        {
            get
            {
                return lifetime;
            }

            set
            {
                if (value < Requirement.MinLifetime || value > Requirement.MaxLifetime)
                {
                    throw new ArgumentOutOfRangeException("Lifetime out of range");
                }
                lifetime = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        // COMMENT: A comment needs to be created here.
        protected override string TableName => "item";

        // COMMENT: A comment needs to be created here.
        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (number,description,price,lifetime) VALUES ({Number},'{Description}',{Price},{Lifetime}) WHERE id = {ID}";

        // COMMENT: A comment needs to be created here.
        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (number,description,price,lifetime) VALUES ({Number},'{Description}',{Price},{Lifetime})";

        // COMMENT: A comment needs to be created here.
        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            Number = ResultsTable.Row().Col("number");
            Description = ResultsTable.Row().Col<string>("description");
            Price = ResultsTable.Row().Col<double>("price");
            Lifetime = ResultsTable.Row().Col("lifetime");
            IsDeleted = ResultsTable.Row().Col<bool>("deleted");

            return true;
        }

        // COMMENT: A comment needs to be created here.
        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            ItemProperties ItemValues = EntityProperties as ItemProperties;

            Number = ItemValues.Number;
            Description = ItemValues.Description;
            Price = ItemValues.Price;
            Lifetime = ItemValues.Lifetime;

            return true;
        }
    }
}

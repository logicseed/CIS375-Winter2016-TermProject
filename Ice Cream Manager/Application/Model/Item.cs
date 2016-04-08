/// <project>IceCreamManager</project>
/// <module>Item</module>
/// <author>Marc King</author>
/// <date_created>2016-04-07</date_created>

using System;
using System.Data;
using System.Text;

namespace IceCreamManager
{
    internal class Item : DatabaseEntity
    {
        private int number;
        private string description;
        private double price;
        private int lifetime;
        private bool deleted = false;

        public Item(int ID, bool LoadProperties = true)
        {
            this.ID = ID;
            if(LoadProperties)
            {
                Load();
                Database.ToString();
            }
        }


        public Item(int Number, string Description, double Price, int Lifetime)
        {
            this.Number = Number;
            this.Description = Description;
            this.Price = Price;
            this.Lifetime = Lifetime;
        }


        public int Number
        {
            get
            {
                LoadIfNotLoaded();
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
            }
        }

        protected override string UpdateCommand
        {
            get
            {
                return String.Format("UPDATE item SET (number,description) VALUES ({0},{1}) WHERE id = {2}", number, description,ID );
            }
        }

        protected override string CreateCommand
        {
            get
            {
                return String.Format("INSERT INTO item (number, description) VALUES ({3},{4})", "number", number, "description", description);
            }
        }

        private void LoadIfNotLoaded()
        {
            if (IsLoaded == false && )
            {
                
            }
        }

        public string Description
        {
            get { return description; }

            set
            {
                if (value.Length > Requirement.MaxDescription)
                {
                    throw new ArgumentOutOfRangeException("Description longer than 30 characters.");
                }
                description = value;
                IsSaved = false;
            }
        }

        public double Price
        {
            get { return price; }

            set
            {
                if (value < Requirement.MinPrice || value > Requirement.MaxPrice)
                {
                    throw new ArgumentOutOfRangeException("Price out of range.");
                }
                price = value;
                IsSaved = false;
            }
        }

        public int Lifetime
        {
            get { return lifetime; }

            set
            {
                if (value < Requirement.MinLifetime || value > Requirement.MaxLifetime)
                {
                    throw new ArgumentOutOfRangeException("Lifetime out of range");
                }
                lifetime = value;
                IsSaved = false;
            }
        }

        override public bool Load()
        {
            // A database entity cannot have an id of zero.
            if (ID == 0) throw new Exception("Error loading properties of item not in database.");

            try
            {
                string DatabaseCommand = String.Format("SELECT * FROM item WHERE id = {0}", ID);
                DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

                Number = ResultsTable.Row().IntCol("number");
                Description = ResultsTable.Row().StringCol("description");
                Price = ResultsTable.Row().DoubleCol("price");
                Lifetime = ResultsTable.Row().IntCol("lifetime");
                IsDeleted = ResultsTable.Row().BoolCol("deleted");
            }
            catch (Exception e)
            {
                throw new Exception("Could not load item properties from database.", e);
            }
            IsLoaded = true;
            return IsLoaded;
        }
    }
}

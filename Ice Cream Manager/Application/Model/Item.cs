/// <project>IceCreamManager</project>
/// <module>Item</module>
/// <author>Marc King</author>
/// <date_created>2016-04-07</date_created>

using System;
using System.Data;

namespace IceCreamManager
{
    public class Item
    {
        DatabaseManager Database = DatabaseManager.DatabaseReference;

        private int id = 0;
        private int number;
        private string description;
        private double price;
        private int lifetime;
        private bool deleted = false;
        private bool saved = false;
        private bool loaded = false;

        public Item(int ID, bool LoadProperties = true)
        {
            this.ID = ID;
            if(LoadProperties)
            {
                LoadPropertiesFromDatabase();
                IsLoaded = true;
            }
        }

        public Item(int Number, string Description, double Price, int Lifetime)
        {
            this.Number = Number;
            this.Description = Description;
            this.Price = Price;
            this.Lifetime = Lifetime;
        }

        public int ID
        {
            get
            {
                return id;
            }
            private set
            {
                if (value < Requirement.MinID)
                {
                    throw new ArgumentOutOfRangeException("ID out of range.");
                }
                id = value;
            }
        }

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
                saved = false;
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
                saved = false;
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
                saved = false;
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
                saved = false;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return deleted;
            }

            set
            {
                deleted = value;
                saved = false;
            }
        }

        public bool IsSaved
        {
            get
            {
                return saved;
            }

            private set
            {
                saved = value;
            }
        }

        public bool IsLoaded
        {
            get
            {
                return loaded;
            }

            private set
            {
                loaded = value;
            }
        }

        private void LoadPropertiesFromDatabase()
        {
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
   
        }



        

    }
}

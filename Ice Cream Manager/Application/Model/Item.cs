using System;
using System.Data;
using IceCreamManager;

namespace IceCreamManager.Model
{
    class Item
    {
        DatabaseManager Database = DatabaseManager.DatabaseReference;
        private DateTime date_deleted;
        private bool deleted;
        private string description;
        private int id;
        private int lifetimeInDays;
        private int number;
        private int price;

        public Item(int ID)
        {
            FillItemProperties(ID);

        }

        private void FillItemProperties(int ID)
        {
            this.ID = ID;
            try
            {
                string DatabaseCommand = String.Format("SELECT * FROM item WHERE id = {0}", ID);
                DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

                Number = Convert.ToInt32(ResultsTable.Rows[0]["number"]);
                Price = Convert.ToInt32(ResultsTable.Rows[0]["price"]);
                Description = Convert.ToString(ResultsTable.Rows[0]["description"]);
                LifetimeInDays = Convert.ToInt32(ResultsTable.Rows[0]["lifetime"]);
                Deleted = Convert.ToBoolean(ResultsTable.Rows[0]["deleted"]);
                Date_deleted = Convert.ToDateTime(ResultsTable.Rows[0]["date_deleted"]);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            
            
        }

        public DateTime Date_deleted
        {
            get
            {
                return date_deleted;
            }

            set
            {
                date_deleted = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return deleted;
            }

            set
            {
                deleted = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int LifetimeInDays
        {
            get
            {
                return lifetimeInDays;
            }

            set
            {
                lifetimeInDays = value;
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
                if (value > 9999 || value < 0)
                {
                    throw new Exception();
                }
                number = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}

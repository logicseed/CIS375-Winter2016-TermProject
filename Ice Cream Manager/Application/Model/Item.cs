/// <project> IceCreamManager </project>
/// <module> Item </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    // COMMENT: This file needs comments.

    /// <summary>
    ///   Contains the properties of an Item. 
    /// </summary>
    /// <remarks>
    ///   A class was chosen over struct because of how struct will be boxed when passing as the implemented type.
    /// </remarks>
    public class ItemProperties : DatabaseEntityProperties
    {
        public int Number;
        public string Description;
        public double Price;
        public int Lifetime;
        public int Quantity;
    }

    /// <summary>
    ///   Represents a type of ice cream sold by ice cream trucks. 
    /// </summary>
    public class Item : DatabaseEntity
    {
        private int number;
        private string description;
        private double price;
        private int lifetime;
        private int quantity;

        public Item()
        {
            ID = 0;
        }

        public Item(int ID)
        {
            Load(ID);
        }

        /// <summary>
        ///   User provided number to distinguish the item. 
        /// </summary>
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

        /// <summary>
        ///   User provided description of the item. 
        /// </summary>
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

        /// <summary>
        ///   The price of the item used in calculating sales and waste. 
        /// </summary>
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

        /// <summary>
        ///   How many days an item will last after being created. An item is considered to have been created when it is
        ///   placed on a truck.
        /// </summary>
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

        /// <summary>
        ///   The warehouse quantity of this ice type. 
        /// </summary>
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value < Requirement.MinNumber || value > Requirement.MaxLifetime)
                {
                    throw new ArgumentOutOfRangeException("Quantity out of range.");
                }
            }
        }

        /// <summary>
        ///   The naem of the database table that stores items. 
        /// </summary>
        protected override string TableName => "item";

        /// <summary>
        ///   The SQL command used to update an item in the database with this object's properties. 
        /// </summary>
        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (number,description,price,lifetime,quantity) VALUES ({Number},'{Description}',{Price},{Lifetime},{Quantity}) WHERE id = {ID}";

        /// <summary>
        ///   The SQL command used to create an item in the database with this object's properties. 
        /// </summary>
        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (number,description,price,lifetime,quantity) VALUES ({Number},'{Description}',{Price},{Lifetime},{Quantity})";

        /// <summary>
        ///   Load an item from the database based on the provided identity. 
        /// </summary>
        /// <param name="ID"> The unique item identity. </param>
        /// <returns> Whether or not the item was successfully loaded. </returns>
        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            Number = ResultsTable.Row().Col("number");
            Description = ResultsTable.Row().Col<string>("description");
            Price = ResultsTable.Row().Col<double>("price");
            Lifetime = ResultsTable.Row().Col("lifetime");
            Quantity = ResultsTable.Row().Col("quantity");
            IsDeleted = ResultsTable.Row().Col<bool>("deleted");

            return true;
        }

        /// <summary>
        ///   Fills this item's properties with values. 
        /// </summary>
        /// <param name="EntityProperties"> A DatabaseEntityProperties object with the values to use. </param>
        /// <returns> Whether or not the item was successfully filled with the values. </returns>
        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            ItemProperties ItemValues = EntityProperties as ItemProperties;

            Number = ItemValues.Number;
            Description = ItemValues.Description;
            Price = ItemValues.Price;
            Lifetime = ItemValues.Lifetime;
            Quantity = ItemValues.Quantity;

            return true;
        }
    }
}

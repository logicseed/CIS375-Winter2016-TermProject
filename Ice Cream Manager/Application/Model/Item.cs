/// <project> IceCreamManager </project>
/// <module> Item </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

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
        ///   User provided number to distinguish the item. Changing this value marks an item to be deleted. 
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (value < Requirement.MinItemNumber) throw new ItemNumberException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxItemNumber) throw new ItemNumberException(Outcome.ValueTooLarge);

                number = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   User provided description of the item. Changing this value marks an item to be deleted. 
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value.Length < Requirement.MinItemDescriptionLength) throw new ItemDescriptionException(Outcome.ValueTooSmall);
                if (value.Length > Requirement.MaxItemDescriptionLength) throw new ItemDescriptionException(Outcome.ValueTooLarge);

                description = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   The price of the item used in calculating sales and waste. Changing this value marks an item to be deleted. 
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value < Requirement.MinItemPrice) throw new ItemPriceException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxItemPrice) throw new ItemPriceException(Outcome.ValueTooLarge);

                price = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   How many days an item will last after being created. An item is considered to have been created when it is
        ///   placed on a truck. Changing this value marks an item to be deleted.
        /// </summary>
        public int Lifetime
        {
            get
            {
                return lifetime;
            }

            set
            {
                if (value < Requirement.MinItemLifetime) throw new ItemLifetimeException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxItemLifetime) throw new ItemLifetimeException(Outcome.ValueTooLarge);

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
                if (value < Requirement.MinItemQuantity) throw new ItemQuantityException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxItemQuantity) throw new ItemQuantityException(Outcome.ValueTooLarge);

                quantity = value;
                IsSaved = false;
            }
        }

        /// <summary>
        ///   The name of the database table that stores items. 
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

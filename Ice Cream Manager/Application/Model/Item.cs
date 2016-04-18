/// <project> IceCreamManager </project>
/// <module> Item </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
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
                ReplaceOnSave = true;
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
                ReplaceOnSave = true;
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
                ReplaceOnSave = true;
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
                ReplaceOnSave = true;
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

        public override bool Save()
        {
            return Factory.Item.Save(this);
        }
    }
}

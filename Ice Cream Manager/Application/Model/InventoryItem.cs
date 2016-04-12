/// <project> IceCreamManager </project>
/// <module> InventoryItem </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Contains the properties of an InventoryItem. 
    /// </summary>
    /// <remarks>
    ///   A class was chosen over struct because of how struct will be boxed when passing as the implemented type.
    /// </remarks>
    public class InventoryItemProperties : DatabaseEntityProperties
    {
        public int ItemID;
        public Item ItemType;
        public int TruckID;
    }

    /// <summary>
    ///   An instance of an Item that exists within a trucks inventory and tracks its expiration. 
    /// </summary>
    public class InventoryItem : DatabaseEntity
    {
        private InventoryItemProperties InventoryItemValues = new InventoryItemProperties();
        private DateTime dateCreated;

        public InventoryItem()
        {
            ID = 0;
        }

        public InventoryItem(int ID)
        {
            Load(ID);
        }

        /// <summary>
        ///   Date the InventoryItem was created; used for tracking expiration. 
        /// </summary>
        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }

            protected set
            {
                dateCreated = value;
            }
        }

        /// <summary>
        ///   The Item stereotype of which this InventoryItem is an instance. 
        /// </summary>
        public Item ItemType
        {
            get
            {
                return InventoryItemValues.ItemType;
            }

            protected set
            {
                InventoryItemValues.ItemType = value;
            }
        }

        /// <summary>
        ///   The identity of the Item stereotype of which this InventoryItem is an instance. 
        /// </summary>
        public int ItemID
        {
            get
            {
                return InventoryItemValues.ItemID;
            }

            protected set
            {
                InventoryItemValues.ItemID = value;
            }
        }

        /// <summary>
        ///   The truck on which this InventoryItem is carried. 
        /// </summary>
        public int TruckID
        {
            get
            {
                return InventoryItemValues.TruckID;
            }

            set
            {
                InventoryItemValues.TruckID = value;
            }
        }

        protected override string TableName => "InventoryItem";

        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (ItemID,TruckID,DateCreated) VALUES ({ItemID},{TruckID},'{DateTime.Now.ToDatabase()}')";

        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET IsDeleted = {IsDeleted.ToDatabase()} WHERE ID = {ID}";

        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE ID = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            ItemID = ResultsTable.Row().Col("ItemID");
            ItemType = ItemFactory.Load(ItemID);
            TruckID = ResultsTable.Row().Col("TruckID");
            DateCreated = ResultsTable.Row().Col<DateTime>("DateCreated");
            InDatabase = true;
            IsSaved = true;

            return true;
        }

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            InventoryItemValues = (InventoryItemProperties)EntityProperties;

            return true;
        }

        public bool RemoveFromInventory()
        {
            IsDeleted = true;
            return Save();
        }
    }
}

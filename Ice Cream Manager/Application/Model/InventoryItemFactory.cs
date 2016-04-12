/// <project> IceCreamManager </project>
/// <module> InventoryItemFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using System.Collections.Generic;
using System.Data;

namespace IceCreamManager.Model
{
    public static class InventoryItemFactory
    {
        private static DatabaseEntityFactory<InventoryItem> DatabaseInventoryItemFactory = new DatabaseEntityFactory<InventoryItem>();
        private static DatabaseManager Database = DatabaseManager.Reference;

        public static InventoryItem Load(int ID)
        {
            return DatabaseInventoryItemFactory.Load(ID);
        }

        public static InventoryItem Create(InventoryItemProperties EntityProperties)
        {
            return DatabaseInventoryItemFactory.Create(EntityProperties);
        }

        internal static List<InventoryItem> LoadInventory(int truckID)
        {
            List<InventoryItem> Inventory = new List<InventoryItem>();

            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT ID FROM InventoryItem WHERE TruckID = {truckID} ORDER BY DateCreated ASC");

            if (ResultsTable.Rows.Count == 0) return Inventory;

            foreach (DataRow Row in ResultsTable.Rows)
            {
                int InventoryItemID = Row.Col();
                InventoryItem InventoryItemToAdd = Load(InventoryItemID);
                Inventory.Add(InventoryItemToAdd);
            }

            return Inventory;
        }
    }
}

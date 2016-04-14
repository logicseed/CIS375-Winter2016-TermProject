
using System;
using System.Data;
/// <project> IceCreamManager </project>
/// <module> ItemFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-08 </date_created>
namespace IceCreamManager.Model
{
    public class ItemFactory : DatabaseEntityFactory<Item>
    {
        #region Singleton
        private static readonly ItemFactory SingletonInstance = new ItemFactory();
        public static ItemFactory Reference { get { return SingletonInstance; } }
        private ItemFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "Number,Description,Price,Lifetime,Quantity,IsDeleted";

        protected override string DatabaseQueryColumnValuePairs(Item item)
            => $"Number = {item.Number},Description = '{item.Description}',Price = {item.Price},Lifetime = {item.Lifetime},Quantity = {item.Quantity},IsDeleted = {item.IsDeleted.ToDatabase()}";

        protected override string DatabaseQueryValues(Item item)
            => $"{item.Number},'{item.Description}',{item.Price},{item.Lifetime},{item.Quantity},{item.IsDeleted.ToDatabase()}";

        protected override Item MapDataRowToProperties(DataRow row)
        {
            Item item = new Item();

            item.ID = row.Col("ID");
            item.Number = row.Col("Number");
            item.Description = row.Col<string>("Description");
            item.Price = row.Col<double>("Price");
            item.Lifetime = row.Col("Lifetime");
            item.Quantity = row.Col("Quantity");
            item.IsDeleted = row.Col<bool>("IsDeleted");
            item.InDatabase = true;
            item.IsSaved = true;

            return item;
        }
    }
}

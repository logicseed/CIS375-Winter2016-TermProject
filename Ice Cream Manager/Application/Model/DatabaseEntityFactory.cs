/// <project> IceCreamManager </project>
/// <module> DatabaseEntityFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    abstract public class DatabaseEntityFactory<DatabaseEntityType>
        where DatabaseEntityType : DatabaseEntity, new()
    {
        #region Public Constructors

        public DatabaseEntityFactory()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public bool Exists(int id)
        {
            string DatabaseCommand = $"SELECT ID FROM {TableName} WHERE ID = {id}";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            if (ResultsTable.Rows.Count > 0) return true;
            return false;
        }

        public DatabaseEntityType Load(int id)
        {
            DatabaseEntityType entity = new DatabaseEntityType();
            entity.ID = id;
            Load(entity);
            //SubscribeToEntityEvents(entity);
            return entity;
        }

        public bool Load(DatabaseEntityType entity)
        {
            string DatabaseCommand = $"SELECT * FROM {TableName} WHERE ID = {entity.ID}";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);
            entity = MapDataRowToProperties(ResultsTable.Row());
            return true;
        }

        public DatabaseEntityType New()
        {
            DatabaseEntityType entity = new DatabaseEntityType();
            SubscribeToEntityEvents(entity);
            return new DatabaseEntityType();
        }

        #endregion Public Methods

        #region Protected Fields

        protected static DatabaseManager Database = DatabaseManager.Reference;
        protected static DatabaseEntityCache EntityCache = DatabaseEntityCache.Reference;

        #endregion Protected Fields

        #region Protected Properties

        protected virtual string TableName => typeof(DatabaseEntityType).Name;

        #endregion Protected Properties

        #region Protected Methods

        protected bool Create(DatabaseEntityType entity)
        {
            // TODO: Make this search for existing entities with the same values to reduce db clutter.
            string DatabaseCommand = $"INSERT INTO {TableName} ({DatabaseQueryColumns()}) VALUES ({DatabaseQueryValues(entity)})";
            if (Database.ExecuteCommand(DatabaseCommand) > 0)
            {
                entity.ID = Database.LastInsertID;
                entity.InDatabase = true;
                entity.IsSaved = true;
                EntityCache.Add(TableName, entity);
                return true;
            }
            return false;
        }

        abstract protected string DatabaseQueryColumns();

        abstract protected string DatabaseQueryColumnValuePairs(DatabaseEntityType entity);

        abstract protected string DatabaseQueryValues(DatabaseEntityType entity);

        abstract protected DatabaseEntityType MapDataRowToProperties(DataRow row);

        protected bool Replace(DatabaseEntityType entity)
        {
            EntityCache.Remove(TableName, entity);
            Database.MarkAsDeleted(TableName, entity.ID);
            return Create(entity);
        }

        public virtual bool Save(DatabaseEntityType entity)
        {
            if (entity.InDatabase && entity.ReplaceOnSave)
            {
                return Replace(entity); // Changes that result in deletion
            }
            else if (entity.InDatabase && !entity.ReplaceOnSave)
            {
                return Update(entity); // Changes that don't result in deletion
            }
            else if (!entity.InDatabase)
            {
                return Create(entity); // New entity
            }
            return false;
        }

        protected bool Update(DatabaseEntityType entity)
        {
            string DatabaseCommand = $"UPDATE {TableName} SET {DatabaseQueryColumnValuePairs(entity)} WHERE ID = {entity.ID}";
            if (Database.ExecuteCommand(DatabaseCommand) > 0)
            {
                entity.InDatabase = true;
                entity.IsSaved = true;
                return true;
            }
            return false;
        }

        #endregion Protected Methods

        #region Private Methods

        private void DatabaseEntityProperties_SaveImmediately(DatabaseEntity entity)
        {
            Save((DatabaseEntityType)entity);
        }

        private void DatabaseEntityProperties_UndoImmediately(DatabaseEntity entity)
        {
            Load((DatabaseEntityType)entity);
        }

        private void SubscribeToEntityEvents(DatabaseEntityType entity)
        {
            entity.OnSaveImmediately += DatabaseEntityProperties_SaveImmediately;
            entity.OnUndoImmediately += DatabaseEntityProperties_UndoImmediately;
        }

        #endregion Private Methods

        #region Factory Network

        // All factories know how to ask all the other factories for an entity

        public City LoadCity(int cityID)
        {
            CityFactory cityFactory = CityFactory.Reference;
            return cityFactory.Load(cityID);
        }

        public Driver LoadDriver(int driverID)
        {
            DriverFactory driverFactory = DriverFactory.Reference;
            return driverFactory.Load(driverID);
        }

        public InventoryItem LoadInventoryItem(int inventoryItemID)
        {
            InventoryItemFactory inventoryItemFactory = InventoryItemFactory.Reference;
            return inventoryItemFactory.Load(inventoryItemID);
        }

        public Item LoadItem(int itemID)
        {
            ItemFactory itemFactory = ItemFactory.Reference;
            return itemFactory.Load(itemID);
        }

        public Route LoadRoute(int routeID)
        {
            RouteFactory routeFactory = RouteFactory.Reference;
            return routeFactory.Load(routeID);
        }

        public Truck LoadTruck(int truckID)
        {
            TruckFactory truckFactory = TruckFactory.Reference;
            return truckFactory.Load(truckID);
        }

        #endregion Factory Network
    }
}

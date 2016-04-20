
using System;
/// <project> IceCreamManager </project>
/// <module> DatabaseEntityFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>
using System.Data;
using IceCreamManager.Controller;

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

        public bool Delete(int entityID)
        {
            return DatabaseMan.MarkAsDeleted(TableName, entityID);
        }

        public bool Exists(int id)
        {
            string DatabaseCommand = $"SELECT ID FROM {TableName} WHERE ID = {id}";
            DataTable ResultsTable = DatabaseMan.DataTableFromCommand(DatabaseCommand);

            if (ResultsTable.Rows.Count > 0) return true;
            return false;
        }

        public virtual DataTable GetDataTable(bool includeDeleted = true)
        {
            return GetAllDataTable(includeDeleted);
        }

        public DatabaseEntityType Load(int id)
        {
            string DatabaseCommand = $"SELECT * FROM {TableName} WHERE ID = {id}";
            DataTable ResultsTable = DatabaseMan.DataTableFromCommand(DatabaseCommand);
            return MapDataRowToProperties(ResultsTable.Rows[0]);
        }

        public bool Load(DatabaseEntityType entity)
        {
            string DatabaseCommand = $"SELECT * FROM {TableName} WHERE ID = {entity.ID}";
            DataTable ResultsTable = DatabaseMan.DataTableFromCommand(DatabaseCommand);
            entity = MapDataRowToProperties(ResultsTable.Rows[0]);
            return true;
        }

        public DatabaseEntityType New()
        {
            DatabaseEntityType entity = new DatabaseEntityType();
            SubscribeToEntityEvents(entity);
            return new DatabaseEntityType();
        }

        public decimal NextNumber()
        {
            var DatabaseCommand = $"SELECT Max(Number) FROM {TableName} WHERE IsDeleted = 0";
            var ResultsTable = DatabaseMan.DataTableFromCommand(DatabaseCommand);

            return ResultsTable.Row().Col() + 1;
        }

        protected DataTable GetAllDataTable(bool includeDeleted = true)
        {
            string DatabaseCommand = $"SELECT * FROM {TableName}";
            if (!includeDeleted) DatabaseCommand += " WHERE IsDeleted = 0";
            return DatabaseMan.DataTableFromCommand(DatabaseCommand);
        }

        #endregion Public Methods

        #region Protected Fields

        protected static DatabaseManager DatabaseMan = DatabaseManager.Reference;
        protected static DatabaseEntityCache EntityCache = DatabaseEntityCache.Reference;

        #endregion Protected Fields

        #region Protected Properties

        protected virtual string TableName => typeof(DatabaseEntityType).Name;

        #endregion Protected Properties

        #region Protected Methods

        public virtual bool Save(DatabaseEntityType entity)
        {
            if (entity.IsSaving || entity.IsSaved) return true;
            else entity.IsSaving = true;

            if (!SaveChildren(entity)) return false;

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

        protected virtual bool SaveChildren(DatabaseEntityType entity)
        {
            return true;
        }

        protected bool Create(DatabaseEntityType entity)
        {
            if (Insert(entity))
            {
                if (typeof(DatabaseEntityType).Name == "LogEntry") return true;
                Log.Success($"Added {SaveLogString(entity)}");
                return true;
            }
            else return false;
        }

        abstract protected string DatabaseQueryColumns();

        abstract protected string DatabaseQueryColumnValuePairs(DatabaseEntityType entity);

        abstract protected string DatabaseQueryValues(DatabaseEntityType entity);

        protected bool Insert(DatabaseEntityType entity)
        {
            // TODO: Make this search for existing entities with the same values to reduce db clutter.
            string DatabaseCommand = $"INSERT INTO {TableName} ({DatabaseQueryColumns()}) VALUES ({DatabaseQueryValues(entity)})";
            if (DatabaseMan.ExecuteCommand(DatabaseCommand) > 0)
            {
                entity.ID = DatabaseMan.LastInsertID;
                entity.InDatabase = true;
                entity.IsSaved = true;
                entity.IsSaving = false;
                EntityCache.Add(TableName, entity);
                return true;
            }
            else return false;
        }

        abstract protected DatabaseEntityType MapDataRowToProperties(DataRow row);

        protected bool Replace(DatabaseEntityType entity)
        {
            EntityCache.Remove(TableName, entity);
            DatabaseMan.MarkAsDeleted(TableName, entity.ID);
            if (Insert(entity))
            {
                if (typeof(DatabaseEntityType).Name == "LogEntry") return true;
                Log.Success($"Edited {SaveLogString(entity)}");
                return true;
            }
            else return false;
        }

        abstract protected string SaveLogString(DatabaseEntityType entity);

        protected bool Update(DatabaseEntityType entity)
        {
            string DatabaseCommand = $"UPDATE {TableName} SET {DatabaseQueryColumnValuePairs(entity)} WHERE ID = {entity.ID}";
            if (DatabaseMan.ExecuteCommand(DatabaseCommand) > 0)
            {
                entity.InDatabase = true;
                entity.IsSaved = true;
                entity.IsSaving = false;
                if (typeof(DatabaseEntityType).Name == "LogEntry") return true;
                Log.Success($"Edited {SaveLogString(entity)}");
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

    }
}

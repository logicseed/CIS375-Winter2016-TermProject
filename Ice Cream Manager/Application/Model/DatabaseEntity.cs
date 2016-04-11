/// <project> IceCreamManager </project>
/// <module> DatabaseEntity </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Represents any class that can be saved and loaded from the database. Contains methods common to all database
    ///   entities and forces classes that inherit this class to provide a method for loading the entity, and properties
    ///   that contain database commands for creating, updating, or deleting the entity.
    /// </summary>
    public abstract class DatabaseEntity
    {
        protected int id = 0;

        public event EventHandler<IDChangedEventArgs> IDChanged;

        /// <summary>
        ///   The unique identity of the database entity. 
        /// </summary>
        public virtual int ID
        {
            get
            {
                return id;
            }

            protected set
            {
                int oldID = id;
                id = value;
                if (oldID != value) OnIDChanged(oldID, id);
            }
        }

        /// <summary>
        ///   This entity exists in the database. 
        /// </summary>
        public bool InDatabase { get; protected set; } = false;

        /// <summary>
        ///   The current properties match the values in the database. 
        /// </summary>
        public bool IsSaved { get; protected set; } = false;

        /// <summary>
        ///   The current properties are outdated and only exists for historical accuracy. 
        /// </summary>
        public bool IsDeleted { get; protected set; } = false;

        /// <summary>
        ///   Access layer for interacting with the database. 
        /// </summary>
        protected DatabaseManager Database { get; } = DatabaseManager.Reference;

        /// <summary>
        ///   A change to a property has occurred that dictates the current properties should be marked as deleted when
        ///   being saved to the database.
        /// </summary>
        protected bool DeleteOnSave { get; set; } = false;

        /// <summary>
        ///   The table in the database in which this entity is stored. 
        /// </summary>
        abstract protected string TableName { get; }

        /// <summary>
        ///   The database command used to insert the current properties into the database. 
        /// </summary>
        abstract protected string CreateCommand { get; }

        /// <summary>
        ///   The database command use to update the database with any changes. 
        /// </summary>
        abstract protected string UpdateCommand { get; }

        /// <summary>
        ///   Loads the entity properties from the database. 
        /// </summary>
        /// <returns> Whether or not the load was successful. </returns>
        abstract public bool Load(int ID);

        /// <summary>
        ///   Fills an entity with values from a class that implements DatabaseEntityProperties. 
        /// </summary>
        /// <param name="entityProperties"></param>
        /// <returns> Whether or not the entity's values were filled successfully. </returns>
        abstract public bool Fill(DatabaseEntityProperties entityProperties);

        /// <summary>
        ///   Saves any changes made to the entity into the database. 
        /// </summary>
        /// <returns> Whether or not the save process was successful. </returns>
        public virtual bool Save()
        {
            if (InDatabase && DeleteOnSave)
            {
                Delete(); // Changes that result in deletion
            }
            else if (InDatabase && !DeleteOnSave)
            {
                Update(); // Changes that don't result in deletion
            }
            else if (!InDatabase)
            {
                Create(); // New entity
            }

            return InDatabase;
        }

        /// <summary>
        ///   Reverts the properties back to the values in the database. 
        /// </summary>
        /// <returns> Whether or not the undo process was successful. </returns>
        public bool Undo()
        {
            IsSaved = Load(ID);
            return IsSaved;
        }

        /// <summary>
        ///   Updates the values of the entity in the database. 
        /// </summary>
        /// <returns> Whether or not the values of the entity were updated in the database. </returns>
        protected bool Update()
        {
            if (UpdateCommand == "") return true;
            return (Database.ExecuteCommand(UpdateCommand) > 0);
        }

        /// <summary>
        ///   Creates a new copy of the entity in the database. Used with new entities and with entities that had changed
        ///   that resulted in deletion.
        /// </summary>
        /// <returns> Whether or not the entity was created in the database. </returns>
        protected bool Create()
        {
            if (InDatabase == false)
            {
                if (Database.ExecuteCommand(CreateCommand) > 0)
                {
                    ID = Database.LastInsertID;
                    InDatabase = true;
                    IsSaved = true;
                    DeleteOnSave = false;
                }
            }
            return InDatabase;
        }

        /// <summary>
        ///   Creates a new copy of the entity in the database and marks the old copy as deleted. 
        /// </summary>
        /// <returns> Whether or not the deletion process was successful. </returns>
        protected bool Delete()
        {
            InDatabase = false;
            Database.MarkAsDeleted(TableName, ID);
            return Create();
        }

        /// <summary>
        ///   An event that is triggered when an entity's ID changes. This event is subscribed to by the cache to allow
        ///   it to update its reference to that entity.
        /// </summary>
        /// <param name="oldID"></param>
        /// <param name="newID"></param>
        protected virtual void OnIDChanged(int oldID, int newID)
        {
            IDChanged?.Invoke(this, new IDChangedEventArgs(this.GetType().Name, oldID, newID));
        }
    }

    /// <summary>
    ///   A collection of values sent with the OnIDChanged event to provide the details of the change. 
    /// </summary>
    public class IDChangedEventArgs : EventArgs
    {
        public readonly string CacheName;
        public readonly int OldID;
        public readonly int NewID;

        public IDChangedEventArgs(string cacheName, int oldID, int newID)
        {
            this.CacheName = cacheName;
            this.OldID = oldID;
            this.NewID = newID;
        }
    }
}

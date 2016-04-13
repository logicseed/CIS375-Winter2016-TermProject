/// <project> IceCreamManager </project>
/// <module> DatabaseEntity </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;

namespace IceCreamManager.Model
{
    public abstract class DatabaseEntity
    {
        public int ID { get; set; } = 0;
        public bool InDatabase { get; set; } = false;
        public bool IsSaved { get; set; } = false;
        // public bool IsLoaded { get; set; } = false; // TODO: delete me if nothing breaks
        public bool ReplaceOnSave { get; set; } = false;
        public bool IsDeleted { get; set; } = false;


        public DatabaseEntity()
        {
            ID = 0;
        }

        public delegate void SaveImmediatelyHandler(DatabaseEntity databaseEntity);
        public delegate void UndoImmediatelyHandler(DatabaseEntity databaseEntity);

        public event SaveImmediatelyHandler OnSaveImmediately;
        public event UndoImmediatelyHandler OnUndoImmediately;

        public bool SaveImmediately()
        {
            if (OnSaveImmediately == null) return false;
            OnSaveImmediately(this);
            return true;
        }

        public bool UndoImmediately()
        {
            if (OnUndoImmediately == null) return false;
            OnUndoImmediately(this);
            return true;
        }

        public bool Save()
        {
            return SaveImmediately();
        }

        public bool Undo()
        {
            return UndoImmediately();
        }
    }
}

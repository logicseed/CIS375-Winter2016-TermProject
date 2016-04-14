/// <project> IceCreamManager </project>
/// <module> DatabaseEntity </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

namespace IceCreamManager.Model
{
    public abstract class DatabaseEntity
    {
        #region Public Constructors

        public DatabaseEntity()
        {
            ID = 0;
        }

        #endregion Public Constructors

        #region Public Delegates

        /// <summary>
        ///   Allows factories to subscribe to an entity's save event. 
        /// </summary>
        /// <param name="databaseEntity"> A reference to the DatabaseEntity that needs to be saved. </param>
        public delegate void SaveImmediatelyHandler(DatabaseEntity databaseEntity);

        /// <summary>
        ///   Allows factories to subscribe to an entity's undo event. 
        /// </summary>
        /// <param name="databaseEntity"> A reference to the DatabaseEntity that needs changes undone. </param>
        public delegate void UndoImmediatelyHandler(DatabaseEntity databaseEntity);

        #endregion Public Delegates

        #region Public Events

        /// <summary>
        ///   Allows an entity to notify its factory that it needs to be saved. 
        /// </summary>
        public event SaveImmediatelyHandler OnSaveImmediately;

        /// <summary>
        ///   Allows an entity to notify its factory that it has changes to be undone. 
        /// </summary>
        public event UndoImmediatelyHandler OnUndoImmediately;

        #endregion Public Events

        #region Public Properties

        public int ID { get; set; } = 0;
        public bool InDatabase { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public bool IsSaved { get; set; } = false;
        public bool ReplaceOnSave { get; set; } = false;

        #endregion Public Properties

        #region Public Methods

        public bool Save()
        {
            return SaveImmediately();
        }

        public bool Undo()
        {
            return UndoImmediately();
        }

        #endregion Public Methods

        #region Protected Methods

        protected bool SaveImmediately()
        {
            if (OnSaveImmediately == null) return false;
            OnSaveImmediately(this);
            return true;
        }

        protected bool UndoImmediately()
        {
            if (OnUndoImmediately == null) return false;
            OnUndoImmediately(this);
            return true;
        }

        #endregion Protected Methods
    }
}

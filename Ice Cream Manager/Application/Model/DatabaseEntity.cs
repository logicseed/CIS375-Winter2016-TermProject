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

        #region Public Properties

        public int ID { get; set; } = 0;
        public bool InDatabase { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public bool IsSaved { get; set; } = false;
        public bool ReplaceOnSave { get; set; } = false;
        public bool IsSaving { get; set; } = false;
        public virtual int Number { get; set; } = 0;

        #endregion Public Properties

        #region Public Methods
        public abstract bool Save();


        #endregion Public Methods
    }
}

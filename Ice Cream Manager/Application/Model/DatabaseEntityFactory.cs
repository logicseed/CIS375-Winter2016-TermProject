/// <project> IceCreamManager </project>
/// <module> DatabaseEntityFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

namespace IceCreamManager.Model
{
    public class DatabaseEntityFactory<EntityType> where EntityType : DatabaseEntity, new()
    {
        /// <summary>
        ///   Provides caching for database entities to improve query performance. 
        /// </summary>
        private DatabaseEntityCache EntityCache = DatabaseEntityCache.Reference;

        /// <summary>
        ///   Load an entity from the database from its id and add it to the cache. 
        /// </summary>
        /// <param name="ID"> The identity of the entity in the database. </param>
        /// <preconditions></preconditions>
        /// <returns> The entity loaded from the database. </returns>
        public EntityType Load(int ID)
        {
            if (!EntityCache.Contains(typeof(EntityType).Name, ID))
            {
                EntityType LoadedEntity = new EntityType();
                LoadedEntity.Load(ID);
                EntityCache.Add(typeof(EntityType).Name, ID, LoadedEntity);
            }
            return (EntityType)EntityCache.Get(typeof(EntityType).Name, ID);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public EntityType Create(DatabaseEntityProperties EntityProperties)
        {
            EntityType NewEntity = new EntityType();
            NewEntity.Fill(EntityProperties);
            NewEntity.Save();
            EntityCache.Add(typeof(EntityType).Name, NewEntity.ID, NewEntity);
            return (EntityType)EntityCache.Get(typeof(EntityType).Name, NewEntity.ID);
        }
    }
}

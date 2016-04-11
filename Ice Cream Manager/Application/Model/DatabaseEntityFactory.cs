/// <project> IceCreamManager </project>
/// <module> DatabaseEntityFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Generic class that allows the Factory design pattern to be implemented with any DatabaseEntity type. 
    /// </summary>
    /// <typeparam name="EntityType"> The DatabaseEntity type that this factory should work with. </typeparam>
    public class DatabaseEntityFactory<EntityType> where EntityType : DatabaseEntity, new()
    {
        /// <summary>
        ///   Provides caching for database entities to improve query performance. 
        /// </summary>
        private DatabaseEntityCache EntityCache = DatabaseEntityCache.Reference;

        /// <summary>
        ///   Load an entity from the database from its id and add it to the cache. 
        /// </summary>
        /// <param name="id"> The identity of the entity in the database. </param>
        /// <preconditions></preconditions>
        /// <returns> The entity loaded from the database. </returns>
        public EntityType Load(int id)
        {
            if (!EntityCache.Contains(typeof(EntityType).Name, id))
            {
                EntityType LoadedEntity = new EntityType();
                LoadedEntity.Load(id);
                EntityCache.Add(typeof(EntityType).Name, id, LoadedEntity);
            }
            return (EntityType)EntityCache.Get(typeof(EntityType).Name, id);
        }

        /// <summary>
        ///   Creates a new entity based on DatabaseEntityProperties collection. 
        /// </summary>
        /// <param name="entityProperties"> A collection of values create the entity with. </param>
        /// <returns> A reference to an entity in memory. </returns>
        public EntityType Create(DatabaseEntityProperties entityProperties)
        {
            EntityType NewEntity = new EntityType();
            NewEntity.Fill(entityProperties);
            NewEntity.Save();
            EntityCache.Add(typeof(EntityType).Name, NewEntity.ID, NewEntity);
            return (EntityType)EntityCache.Get(typeof(EntityType).Name, NewEntity.ID);
        }
    }
}

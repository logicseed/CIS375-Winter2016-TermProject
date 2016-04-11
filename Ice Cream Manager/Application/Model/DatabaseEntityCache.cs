/// <project> IceCreamManager </project>
/// <module> DatabaseEntityCache </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;
using System.Runtime.Caching;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Manages the memory cache that stores database entities. This is used to reduce the need for database queries
    ///   for objects that have recently been queried.
    /// </summary>
    public sealed class DatabaseEntityCache
    {
        #region Singleton

        private static readonly DatabaseEntityCache SingletonInstance = new DatabaseEntityCache();

        /// <summary>
        ///   Reference to the DatabaseEntityCache Singleton instance. 
        /// </summary>
        public static DatabaseEntityCache Reference { get { return SingletonInstance; } }

        #endregion Singleton

        private static CacheItemPolicy CachePolicy = new CacheItemPolicy();

        private static MemoryCache EntityCache = new MemoryCache("IceCreamManager");

        private DatabaseEntityCache()
        {
            CachePolicy.SlidingExpiration = new TimeSpan(Requirement.MaxCacheHours, Requirement.MaxCacheMinutes, Requirement.MaxCacheSeconds);
        }

        /// <summary>
        ///   Adds an entity to a specific memory cache. 
        /// </summary>
        /// <param name="cacheName"> The name of the cache. The cache is named for the class that implements DatabaseEntity. </param>
        /// <param name="entityID"> The unique identity of the entity to be added to the cache. </param>
        /// <param name="entity"> The reference to the entity in memory. </param>
        /// <returns> Whether or not the entity was successfully added to the cache. </returns>
        public bool Add(string cacheName, int entityID, DatabaseEntity entity)
        {
            entity.IDChanged += DatabaseEntity_IDChanged;
            return EntityCache.Add(cacheName + entityID, entity, CachePolicy);
        }

        /// <summary>
        ///   Determines if a specific memory cache contains an entity. 
        /// </summary>
        /// <param name="cacheName"> The name of the cache. The cache is named for the class that implements DatabaseEntity. </param>
        /// <param name="entityID"> The unique identity of the entity to be checked. </param>
        /// <returns> Whether or not the specified memory cache contains the specified entity. </returns>
        public bool Contains(string cacheName, int entityID)
        {
            return EntityCache.Contains(cacheName + entityID);
        }

        /// <summary>
        ///   Gets a reference to an entity stored in the cache. 
        /// </summary>
        /// <param name="cacheName"> The name of the cache. The cache is named for the class that implements DatabaseEntity. </param>
        /// <param name="entityID"> The unique identity of the entity to get. </param>
        /// <returns> A reference to the requested entity. </returns>
        public DatabaseEntity Get(string cacheName, int entityID)
        {
            return (DatabaseEntity)EntityCache.Get(cacheName + entityID);
        }

        /// <summary>
        ///   Handles the OnChangedID event that a DatabaseEntity can invoke. Updates the cache's references to match the
        ///   changed identity.
        /// </summary>
        /// <param name="sender"> The entity that invoked the event. </param>
        /// <param name="eventDetails"> Details on the identity change. </param>
        private static void DatabaseEntity_IDChanged(object sender, IDChangedEventArgs eventDetails)
        {
            if (EntityCache.Contains(eventDetails.CacheName + eventDetails.OldID))
            {
                DatabaseEntity Entity = (DatabaseEntity)EntityCache.Get(eventDetails.CacheName + eventDetails.OldID);
                EntityCache.Add(eventDetails.CacheName + eventDetails.NewID, Entity, CachePolicy);
            }
        }
    }
}

/// <project> IceCreamManager </project>
/// <module> DatabaseEntityCache </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;
using System.Runtime.Caching;

namespace IceCreamManager.Model
{
    /// <summary>
    /// </summary>
    internal sealed class DatabaseEntityCache
    {
        #region Singleton

        private static readonly DatabaseEntityCache SingletonInstance = new DatabaseEntityCache();

        /// <summary>
        ///   Reference to the DatabaseEntityCache Singleton instance. 
        /// </summary>
        public static DatabaseEntityCache Reference { get { return SingletonInstance; } }

        #endregion Singleton

        private CacheItemPolicy CachePolicy = new CacheItemPolicy();

        private MemoryCache EntityCache = new MemoryCache("IceCreamManager");

        private DatabaseEntityCache()
        {
            CachePolicy.SlidingExpiration = new TimeSpan(Requirement.MaxCacheHours, Requirement.MaxCacheMinutes, Requirement.MaxCacheSeconds);
        }

        public bool Add(string CacheName, int EntityID, object Entity)
        {
            return EntityCache.Add(CacheName + EntityID, Entity, CachePolicy);
        }

        public bool Contains(string CacheName, int EntityID)
        {
            return EntityCache.Contains(CacheName + EntityID);
        }

        public DatabaseEntity Get(string CacheName, int EntityID)
        {
            return (DatabaseEntity)EntityCache.Get(CacheName + EntityID);
        }
    }
}


namespace FoodApp.Framework
{
    using System;
    using System.Web;

    /// <summary>
    ///     The cache service.
    /// </summary>
    public class CacheService : ICacheService
    {
        /// <summary>
        /// The get cache.
        /// </summary>
        /// <param name="cacheId">
        /// The cache id.
        /// </param>
        /// <param name="getItemCallback">
        /// The get item callback.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T GetCache<T>(string cacheId, Func<T> getItemCallback) where T : class
        {
            var item = HttpContext.Current.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpContext.Current.Cache.Insert(cacheId, item);

                // HttpContext.Current.Cache.Insert(cacheId, item, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 20, 0), CacheItemPriority.Normal, null);
            }

            return item;
        }

        /// <summary>
        /// The get cache.
        /// </summary>
        /// <param name="cacheId">
        /// The cache id.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T GetCache<T>(string cacheId) where T : class
        {
            var item = HttpContext.Current.Cache.Get(cacheId) as T;
            return item;
        }

        /// <summary>
        /// The get session.
        /// </summary>
        /// <param name="sessionId">
        /// The session id.
        /// </param>
        /// <param name="getItemCallback">
        /// The get item callback.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T GetSession<T>(string sessionId, Func<T> getItemCallback) where T : class
        {
            var item = HttpContext.Current.Session[sessionId] as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpContext.Current.Session[sessionId] = item;
            }

            return item;
        }

        /// <summary>
        /// The remove session.
        /// </summary>
        /// <param name="sessionId">
        /// The session id.
        /// </param>
        public void RemoveSession(string sessionId)
        {
            HttpContext.Current.Session.Remove(sessionId);
        }

        /// <summary>
        /// The remove cache.
        /// </summary>
        /// <param name="cacheId">
        /// The cache id.
        /// </param>
        public void RemoveCache(string cacheId)
        {
            HttpRuntime.Cache.Remove(cacheId);
        }
    }

    /// <summary>
    ///     The CacheService interface.
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// The get cache.
        /// </summary>
        /// <param name="cacheId">
        /// The cache id.
        /// </param>
        /// <param name="getItemCallback">
        /// The get item callback.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetCache<T>(string cacheId, Func<T> getItemCallback) where T : class;

        /// <summary>
        /// The get session.
        /// </summary>
        /// <param name="sessionId">
        /// The session id.
        /// </param>
        /// <param name="getItemCallback">
        /// The get item callback.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetSession<T>(string sessionId, Func<T> getItemCallback) where T : class;

        /// <summary>
        /// The get cache.
        /// </summary>
        /// <param name="cacheId">
        /// The cache id.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetCache<T>(string cacheId) where T : class;

        /// <summary>
        /// The remove session.
        /// </summary>
        /// <param name="sessionId">
        /// The session id.
        /// </param>
        void RemoveSession(string sessionId);

        /// <summary>
        /// The remove cache.
        /// </summary>
        /// <param name="cacheId">
        /// The cache id.
        /// </param>
        void RemoveCache(string cacheId);
    }
}
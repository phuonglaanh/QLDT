using System;
using System.Web;

namespace Core
{
    public class DataCache
    {
        public static object GetCache(string cacheKey)
        {
            return HttpRuntime.Cache[cacheKey];
        }
        public static void RemoveCache(string cacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            if (!Convert.ToBoolean(objCache[cacheKey] == null))
                objCache.Remove(cacheKey);
        }
        public static void SetCache(string cacheKey, object objObject)
        {
            HttpRuntime.Cache.Insert(cacheKey, objObject);
        }
        public static void SetCache(string cacheKey, object objObject, DateTime AbsoluteExpiration)
        {
            HttpRuntime.Cache.Insert(cacheKey, objObject, null, AbsoluteExpiration, TimeSpan.Zero);
        }
        public static void SetCache(string cacheKey, object objObject, int SlidingExpiration)
        {
            HttpRuntime.Cache.Insert(cacheKey, objObject, null, DateTime.MaxValue, TimeSpan.FromSeconds((double)SlidingExpiration));
        }
        public static void SetCache(string cacheKey, object objObject, System.Web.Caching.CacheDependency objDependency)
        {
            HttpRuntime.Cache.Insert(cacheKey, objObject, objDependency);
        }
    }
}

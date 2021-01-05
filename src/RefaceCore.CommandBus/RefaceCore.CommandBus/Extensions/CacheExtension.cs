using System;

namespace RefaceCore.CommandBus
{
    public static class CacheExtension
    {
        public static T GetOrDefault<T>(this ICache cache, string key, T defaultData, bool defaultDataSaveToCache = false)
        {
            T result;
            if (cache.TryGet<T>(key, out result))
                return result;

            if (defaultDataSaveToCache)
                cache.Set(key, defaultData);

            return defaultData;
        }

        public static T GetOrDefault<T>(this ICache cache, string key, Func<string, T> defaultDataFactory, bool defaultDataSaveToCache = false)
        {
            T result;
            if (cache.TryGet<T>(key, out result))
                return result;

            T defaultValue = defaultDataFactory(key);

            if (defaultDataSaveToCache)
                cache.Set(key, defaultValue);

            return defaultValue;
        }
    }
}

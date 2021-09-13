using Microsoft.Extensions.Caching.Memory;
using System;

namespace Category.Standard.Cache
{
    public static class CacheManager
    {
        private static readonly IMemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions { ExpirationScanFrequency = new TimeSpan(TimeSpan.TicksPerMinute) });

        public static TItem GetOrCreate<TItem>(object key, int expirationTime, Func<TItem> factory)
        {
            return MemoryCache.GetOrCreate(key, x => { 
                x.AbsoluteExpiration = DateTimeOffset.FromUnixTimeSeconds(expirationTime);
                return factory.Invoke(); 
            });
        }

        public static TItem GetOrCreate<TItem>(object key, Func<ICacheEntry, TItem> factory)
        {
            return MemoryCache.GetOrCreate(key, factory);
        }

        public static void DeleteCache(object key)
        {
            MemoryCache.Remove(key);
        }
    }
}

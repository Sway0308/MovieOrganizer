using Microsoft.Extensions.Caching.Memory;
using System;

namespace Category.Standard.Cache
{
    public static class CacheManager
    {
        private static readonly IMemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions { ExpirationScanFrequency = new TimeSpan(TimeSpan.TicksPerHour) });

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

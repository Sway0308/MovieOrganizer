using Microsoft.Extensions.Caching.Memory;
using System;

namespace Category.Standard.Cache
{
    public class CacheManager
    {
        private static readonly IMemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions { ExpirationScanFrequency = new TimeSpan(TimeSpan.TicksPerHour) });

        public static TItem GetOrCreate<TItem>(string key, Func<ICacheEntry, TItem> factory)
        {
            return MemoryCache.GetOrCreate<TItem>(key, factory);
        }
    }
}

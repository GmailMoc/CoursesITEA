using GeneralHomework.Configurations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public class LoadFile : ILoadFile
    {
        private static string cacheKey = $"image_{DateTime.UtcNow:yyyy_mm_dd}";
        private readonly GeneralAppConfiguration.LoadFile _configuration;
        private readonly IMemoryCache _cache;

        public LoadFile(IMemoryCache cache, IOptions<GeneralAppConfiguration.LoadFile> options)
        {
            _cache = cache;
            _configuration = options.Value;
        }

        public void CacheSet(byte[] image, string imageName)
        {
            MemoryCacheEntryOptions memoryCacheEntry = new MemoryCacheEntryOptions();
            memoryCacheEntry.SlidingExpiration = TimeSpan.FromMinutes(_configuration.CacheStorageTime);
            _cache.Set<byte[]>(imageName + cacheKey, image, memoryCacheEntry);
        }

        public byte[] GetImage(string imageName)
        {
            byte[] result = _cache.Get<byte[]>(imageName + cacheKey);
            return result;
        }
    }
}

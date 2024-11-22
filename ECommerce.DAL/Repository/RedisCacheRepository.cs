using ECommerce.DAL.Repository.IRepository;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository
{
    public class RedisCacheRepository : IRedisCacheRepository
    {
        private readonly IDistributedCache Cache;

        public RedisCacheRepository(IDistributedCache _cache)
        {
            Cache = _cache;
        }


        public T? GetData<T>(string key)
        {
            var data = Cache?.GetString(key);
            if (data == null) { 
                return default(T); 
            }

            return JsonSerializer.Deserialize<T>(data);
        }

        public void SetData<T>(string key, T data)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            Cache.SetString(key,JsonSerializer.Serialize<T>(data),options);
        }
    }
}

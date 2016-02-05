using Enyim.Caching;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liunian.Memcached
{
    public class MemcachedCacheManager : ICacheManager
    {
        private Lazy<MemcachedClient> _client = new Lazy<MemcachedClient>(() => new MemcachedClient());

        private MemcachedClient client
        {
            get
            {
                return _client.Value;
            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TResult Get<TResult>(string key)
        {
            return client.Get<TResult>(key);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="validFor"></param>
        public bool Set(string key, object data, TimeSpan validFor)
        {
            if (data == null)
                return false;
            return client.Store(StoreMode.Set, key, data, validFor);
        }

        /// <summary>
        /// 是否包含某个键值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            object obj = null;
            return client.TryGet(key, out obj);
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            return client.Remove(key);
        }

        public void Clear()
        {
            client.FlushAll();
        }
    }
}

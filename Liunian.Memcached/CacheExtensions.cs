using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liunian.Memcached
{
    public static class CacheExtensions
    {
        private static readonly object _syncObject = new object();

        /// <summary>
        /// 默认60分钟
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="cacheManager"></param>
        /// <param name="key"></param>
        /// <param name="acquire"></param>
        /// <returns></returns>
        public static TResult Get<TResult>(this ICacheManager cacheManager, string key, Func<TResult> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        /// <summary>
        /// 扩展缓存方法
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="cacheManager"></param>
        /// <param name="key"></param>
        /// <param name="cacheMinuteTime">(单位:分钟)</param>
        /// <param name="acquire">缓存过期执行的方法</param>
        /// <returns></returns>
        public static TResult Get<TResult>(this ICacheManager cacheManager, string key, int cacheMinuteTime, Func<TResult> acquire)
        {
            lock (_syncObject)
            {
                if (cacheManager.IsExist(key))
                {
                    return cacheManager.Get<TResult>(key);
                }
                var result = acquire();
                if (cacheMinuteTime > 0)
                    cacheManager.Set(key, result, TimeSpan.FromMinutes(cacheMinuteTime));
                return result;
            }
        }
    }
}

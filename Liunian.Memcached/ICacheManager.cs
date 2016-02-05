using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liunian.Memcached
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICacheManager
    {
        TResult Get<TResult>(string key);

        bool Set(string key, object data, TimeSpan validFor);

        bool IsExist(string key);

        bool Remove(string key);

        void Clear();
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liunian.Memcached.Environment
{
    public class MemcachedStarter
    {
        /// <summary>
        /// 创建缓存容器
        /// </summary>
        /// <param name="registrations">提供IOC注入功能的委托</param>
        /// <returns></returns>
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations = null)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MemcachedCacheManager>()
                .As<ICacheManager>()
                .SingleInstance();
            if (registrations != null)
            {
                registrations(builder);
            }
            var container = builder.Build();
            return container;
        }
    }
}

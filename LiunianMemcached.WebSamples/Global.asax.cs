using Autofac.Integration.Mvc;
using Liunian.Memcached.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LiunianMemcached.WebSamples
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = MemcachedStarter.CreateHostContainer(builder =>
            {
                builder.RegisterControllers(typeof(MvcApplication).Assembly);
            });

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

using MyMvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);


            var defaultPath = new Dictionary<string, object>();
            defaultPath.Add("controller", "Home");
            defaultPath.Add("action", "Index");
            defaultPath.Add("id", null);
            defaultPath.Add("namespaces", "Test.Controllers");
            defaultPath.Add("assembly", "Test");

            InitRoute init = InitRoute.InitInstance();
            init.InstanceController(defaultPath);

            MyRouteTable.Routes.Add("defaultRoute", new MyRoute("{controller}/{action}/{id}", defaultPath, new MyMvc.MVC.MvcRouteHandler()));

            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

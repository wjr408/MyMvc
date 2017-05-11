using MyMvc.MVC;
using MyMvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace MyMvc.MVC
{
    public class MvcRouteHandler : Routing.IRouteHandler
    {
        public IHttpHandler GetHttpHandler(MyRouteData routeData, HttpContextBase context)
        {
            return new MvcHandler(routeData, context);
        }
    }
}

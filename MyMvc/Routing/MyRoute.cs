using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Routing
{
    public class MyRoute
    {
        public MyRoute()
        { }

        //在全局配置里面写入路由规则以及默认配置
        public MyRoute(string url, Dictionary<string, object> defaultPath, IRouteHandler routeHandler)
        {
            TemplateUrl = url;
            DefaultPath = defaultPath;
            RouteHandler = routeHandler;
        }
        public string TemplateUrl { get; set; }

        public IRouteHandler RouteHandler { get; set; }

        public Dictionary<string, object> DefaultPath { get; set; }
    }
}

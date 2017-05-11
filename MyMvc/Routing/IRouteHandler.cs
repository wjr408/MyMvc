﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyMvc.Routing
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(MyRouteData routeData, HttpContextBase context);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace MyMvc.Routing
{
    public class UrlRoutingModule : IHttpModule
    {
        #region Property
        private MyRouteCollection _myRouteCollection;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly",
            Justification = "This needs to be settable for unit tests.")]
        public MyRouteCollection MyRouteCollection
        {
            get
            {
                if (_myRouteCollection == null)
                {
                    _myRouteCollection = MyRouteTable.Routes;
                }
                return _myRouteCollection;
            }
            set
            {
                _myRouteCollection = value;
            }
        }
        #endregion

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication app)
        {
            app.PostResolveRequestCache += app_PostResolveRequestCache;
        }

        void app_PostResolveRequestCache(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            //0.将HttpContext转换为HttpContextWrapper对象（HttpContextWrapper继承HttpContextBase）
            var contextbase = new HttpContextWrapper(app.Context);
            PostResolveRequestCache(contextbase);
        }

        public virtual void PostResolveRequestCache(HttpContextBase context)
        {
            //1.传入当前上下文对象，得到与当前请求匹配的RouteData对象
            MyRouteData routeData = this.MyRouteCollection.GetRouteData(context);
            if (routeData == null)
            {
                return;
            }
            //2.从RouteData对象里面得到当前的RouteHandler对象。
            IRouteHandler routeHandler = routeData.RouteHandler;
            if (routeHandler == null)
            {
                return;
            }

            //3.根据RequestContext对象得到处理当前请求的HttpHandler（MvcHandler）。
            IHttpHandler httpHandler = routeHandler.GetHttpHandler(routeData, context);
            if (httpHandler == null)
            {
                return;
            }

            //4.请求转到HttpHandler进行处理（进入到ProcessRequest方法）。这一步很重要，由这一步开始，请求才由UrlRoutingModule转到了MvcHandler里面
            context.RemapHandler(httpHandler);
        }
    }
}

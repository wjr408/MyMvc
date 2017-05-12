using MyMvc.MVC.Controller;
using MyMvc.MVC.ControllerFactory;
using MyMvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyMvc.MVC
{
    public class MvcHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public HttpContextBase MyContext { get; set; }
        public MyRouteData MyRouteData { get; set; }

        public MvcHandler() { }

        public MvcHandler(MyRouteData routeData, HttpContextBase context)
        {
            MyRouteData = routeData;
            MyContext = context;
        }
        public virtual void ProcessRequest(HttpContext context)
        {
            //写入MVC的版本到HttpHeader里面
            //AddVersionHeader(httpContext);
            //移除参数
            //RemoveOptionalRoutingParameters();

            //1.从当前的RouteData里面得到请求的控制器名称
            string controllerName = MyRouteData.RouteValue["controller"].ToString();

            //2.得到控制器工厂
            IControllerFactory factory = new MyControllerFactory();

            //3.通过默认控制器工厂得到当前请求的控制器对象
            IController controller = factory.CreateController(MyRouteData, controllerName);
            if (controller == null)
            {
                controller = factory.CreateController(MyRouteData, "Home");
            }

            try
            {
                //4.执行控制器的Action
                controller.Execute(MyRouteData);
            }
            catch(Exception e)
            {

            }
            finally
            {
                //5.释放当前的控制器对象
                factory.ReleaseController(controller);
            }

        }
    }
}

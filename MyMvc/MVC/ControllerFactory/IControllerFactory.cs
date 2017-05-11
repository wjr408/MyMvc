using MyMvc.MVC.Controller;
using MyMvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.SessionState;

namespace MyMvc.MVC.ControllerFactory
{
    public interface IControllerFactory
    {
        //创建控制器
        IController CreateController(MyRouteData routeData, string controllerName);

        //释放控制器
        void ReleaseController(IController controller);
    }
}

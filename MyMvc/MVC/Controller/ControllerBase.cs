using MyMvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.MVC.Controller
{
    public abstract class ControllerBase: IController
    {

        public abstract void Execute(MyRouteData routeData);
    }
}

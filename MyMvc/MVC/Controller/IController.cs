using MyMvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.MVC.Controller
{
    public interface IController
    {
        void Execute(MyRouteData routeData);
    }
}

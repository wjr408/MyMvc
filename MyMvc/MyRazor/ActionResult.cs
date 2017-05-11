using MyMvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.MyRazor
{
    public abstract class ActionResult
    {
        public abstract void ExecuteResult(MyRouteData routeData);
    }
}

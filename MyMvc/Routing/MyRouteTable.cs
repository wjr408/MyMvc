using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Routing
{
    public class MyRouteTable
    {
        static  MyRouteTable()
        {
            routes = new MyRouteCollection();
        }
        private static MyRouteCollection routes;
        public static MyRouteCollection Routes
        {
            get
            {
                return routes;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Test
{
    public class InitRoute
    {
        private static InitRoute _initRoute = null;
        public static object lockObject = new object();
        private static bool firstInto = true;
        private InitRoute() { }
        public static InitRoute InitInstance()
        {
            if (_initRoute == null)
            {
                lock (lockObject)
                {
                    if (_initRoute == null)
                    {
                        _initRoute = new InitRoute();
                    }
                }
            }
            return _initRoute;
        }

        public void InstanceController(Dictionary<string,object> path)
        {
            if (!firstInto)
            {
                return;
            }
            Assembly asm = Assembly.GetExecutingAssembly();
            
            var baseType = typeof(MyMvc.MVC.Controller.Controller);
            foreach (Type type in asm.GetTypes())
            {
                var tmp = type.BaseType;
                if (tmp == baseType)
                {
                    path.Add(tmp.Name + type.Name, type.Name.Substring(0,type.Name.LastIndexOf("Controller")));

                    var methods = type.GetMethods();
                    foreach (MethodInfo item in methods)
                    {
                        path.Add(type.Name + item.Name, item.Name);
                    }
                }
            }
            firstInto = false;
        }
    }
}
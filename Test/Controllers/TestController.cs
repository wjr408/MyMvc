using MyMvc.MVC.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Controllers
{
    public class TestController : Controller
    {
        public void Index()
        {
            HttpContext.Current.Response.Write("这是Test的Index页面，，Hello MVC");
        }

        public void Index1()
        {
            HttpContext.Current.Response.Write("这是Test的Index1页面，，Hello MVC");
        }


        public void Index2()
        {
            HttpContext.Current.Response.Write("这是Test的Index2页面，，Hello MVC");
        }

    }
}
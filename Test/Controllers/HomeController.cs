using MyMvc.MVC.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            HttpContext.Current.Response.Write("Hello MVC");
        }

        public void To404()
        {
            HttpContext.Current.Response.Write("欢姐是一个gay");
        }
    }
}
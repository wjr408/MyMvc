using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Test.App_Start
{
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常事件
        /// </summary>
        /// <param name="context">上下文</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ApplicationException)
            {
                //context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
            }
            else
            {
                
            }
        }
    }
}
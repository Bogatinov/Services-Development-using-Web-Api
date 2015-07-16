using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace LessComplexWebApi.Errors
{
    public class NotFoundFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ApplicationException)
            {
                Trace.WriteLine(context.Exception.Message);
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    RequestMessage = new HttpRequestMessage(context.Request.Method,
                        context.Request.RequestUri),
                    ReasonPhrase = context.Exception.Message
                };
            }
        }
    }
}
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace LessComplexWebApi.Errors
{
    public class NotFoundFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NullReferenceException)
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
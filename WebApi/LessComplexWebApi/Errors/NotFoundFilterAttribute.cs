using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace LessComplexWebApi.Errors
{
    public class NotFoundFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NullReferenceException) // what is your exception type
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound) // return 404
                {
                    ReasonPhrase = context.Exception.Message, // return the message you passed in the exception
                    Content = new StringContent("This is a problem"), // return Content that this is a problem
                    RequestMessage = new HttpRequestMessage(context.Request.Method, context.Request.RequestUri) // return I wanted GET api/v1/goose/find/myName
                };
            }
        }
    }
}
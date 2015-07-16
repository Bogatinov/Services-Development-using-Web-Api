using System;
<<<<<<< HEAD
using System.Net;
using System.Net.Http;
=======
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
>>>>>>> Exception handling with G1
using System.Web.Http.Filters;

namespace LessComplexWebApi.Errors
{
    public class NotFoundFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
<<<<<<< HEAD
            if (context.Exception is NullReferenceException) // what is your exception type
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound) // return 404
                {
                    ReasonPhrase = context.Exception.Message, // return the message you passed in the exception
                    Content = new StringContent("This is a problem"), // return Content that this is a problem
                    RequestMessage = new HttpRequestMessage(context.Request.Method, context.Request.RequestUri) // return I wanted GET api/v1/goose/find/myName
=======
            if (context.Exception is ApplicationException)
            {
                Trace.WriteLine(context.Exception.Message);
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    RequestMessage = new HttpRequestMessage(context.Request.Method,
                        context.Request.RequestUri),
                    ReasonPhrase = context.Exception.Message
>>>>>>> Exception handling with G1
                };
            }
        }
    }
}
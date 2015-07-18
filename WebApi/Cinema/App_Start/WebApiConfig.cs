using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace Cinema
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = true;
            traceWriter.MinimumLevel = TraceLevel.Info;
            // OFF NO tracing
            // INFO
            // WARN
            // ERROR
            // FATAL
            // Debug DEBUG_ONLY
            // FATAL FATAL_ONLY
            // WARN FATAL + WARN + ERROR
            // ERROR FATAL + ERROR
            // INFO FATAL + WARN + ERROR + INFO
        }
    }
}

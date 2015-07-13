using System.Web.Http;
using ComplexProject.App_Start;
using Microsoft.Owin;
using Newtonsoft.Json;
using Opus.Core.API.Host;
using Owin;

namespace ComplexProject
{
    [assembly: OwinStartup(typeof(Startup))]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            HttpConfiguration config = new HttpConfiguration();
            var auth = new AuthConfig();
            auth.ConfigureAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            SwaggerConfig.Register(config);
            WebApiConfig.Register(config);
        }
    }
}
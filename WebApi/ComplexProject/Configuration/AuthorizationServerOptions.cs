using System;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace ComplexProject.Configuration
{
    public class AuthorizationServerOptions : OAuthAuthorizationServerOptions
    {
        public AuthorizationServerOptions()
        {
            AuthenticationMode = AuthenticationMode.Active;
            AuthorizeEndpointPath = new PathString("/api/v1/Login/OAuth");
            TokenEndpointPath = new PathString("/token");
#if DEBUG
            AllowInsecureHttp = true;
#endif
            AccessTokenExpireTimeSpan = TimeSpan.FromHours(1);
        }
    }
}
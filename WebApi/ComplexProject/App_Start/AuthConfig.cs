using ComplexProject.Configuration;
using ComplexProject.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace ComplexProject.App_Start
{
    public class AuthConfig
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static GoogleOptions GoogleAuthOptions { get; private set; }
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            GoogleAuthOptions = new GoogleOptions();
            app.UseOAuthAuthorizationServer(new AuthorizationServerOptions()
            {
                Provider = new SimpleAuthorizationServerProvider()
            });
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
            app.UseGoogleAuthentication(GoogleAuthOptions);
        }
    }
}
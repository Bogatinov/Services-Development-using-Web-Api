using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Google;

namespace ComplexProject.Providers
{
    public class GoogleProvider : GoogleOAuth2AuthenticationProvider
    {
        public override void ApplyRedirect(GoogleOAuth2ApplyRedirectContext context)
        {
            context.Response.Redirect(context.RedirectUri);
        }

        public override Task Authenticated(GoogleOAuth2AuthenticatedContext context)
        {
            context.Identity.AddClaim(new Claim("urn:google:accesstoken", context.AccessToken));
            context.Identity.AddClaim(new Claim("urn:google:user", context.User.ToString()));
            return Task.FromResult(0);
        }

        public override Task ReturnEndpoint(GoogleOAuth2ReturnEndpointContext context)
        {
            return Task.FromResult<object>(null);
        }
    }
}
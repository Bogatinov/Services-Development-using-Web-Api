using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace ComplexProject.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (UsernamePasswordInvalid(context))
            {
                context.Rejected();
                return;
            }
            List<Claim> userClaims = new List<Claim>(); // await claims from Service or RESTful call for username and password
            //if (userClaims == null || userClaims.Count == 0)
            //{
            //    context.SetError("invalid_grant", "The user name or password is incorrect.");
            //    context.Rejected();
            //    return;
            //}
            var identity = new ClaimsIdentity(userClaims, context.Options.AuthenticationType);
            var props = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = false
            };
            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(props, identity);
        }

        private static bool UsernamePasswordInvalid(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return string.IsNullOrWhiteSpace(context.UserName) || string.IsNullOrWhiteSpace(context.Password);
        }
    }
}
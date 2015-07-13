using ComplexProject.Providers;
using Microsoft.Owin.Security.Google;

namespace ComplexProject.Configuration
{
    public class GoogleOptions : GoogleOAuth2AuthenticationOptions
    {
        public GoogleOptions()
        {
            ClientId = System.Configuration.ConfigurationManager.AppSettings["google:ClientId"];
            ClientSecret = System.Configuration.ConfigurationManager.AppSettings["google:ClientSecret"];
            Provider = new GoogleProvider();
        }
    }
}
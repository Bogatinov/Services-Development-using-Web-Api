using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;

namespace ComplexProject.Providers
{
    public class BasicToken : ISecureDataFormat<AuthenticationTicket>
    {
        private SecureDataFormat<AuthenticationTicket> _secure; 
        public BasicToken(IDataProtector protector)
        {
            _secure = new SecureDataFormat<AuthenticationTicket>(DataSerializers.Ticket, protector, TextEncodings.Base64Url);
        }
        public string Protect(AuthenticationTicket data)
        {
            return _secure.Protect(data);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            return _secure.Unprotect(protectedText);
        }
    }
}
using System.Web.Http;

namespace MyFirstWebApi2.Controllers
{
    [RoutePrefix("api/doma")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("zdravo")]
        public string Hello()
        {
            return "WEBAPI_2_HELLO";
        }

        [HttpGet]
        [Route("posebno")]
        public string SomethingSpecial()
        {
            return "Not_FOUND";
        }
    }
}

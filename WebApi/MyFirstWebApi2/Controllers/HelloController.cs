using System.Web.Http;
using System.Web.Http.Description;

namespace MyFirstWebApi2.Controllers
{
    [RoutePrefix("home/api/1.1")]
    public class HelloController : ApiController
    {
        // GET home/api/1.1/hello?greetings="string_of_choice"
        [HttpGet]
        [Route("{greetings}", Name = "hello")]
        public int Hello(string greetings)
        {
            int hello = greetings.Length << 2;
            return hello;
        }

        // POST home/api/1.1/status
        [HttpPost]
        [Route("status")]
        [ResponseType(typeof(string))]
        public IHttpActionResult Status([FromBody]string message)
        {
            if (message.Length < 5)
                return BadRequest();

            return Ok(message);
        }
    }
}

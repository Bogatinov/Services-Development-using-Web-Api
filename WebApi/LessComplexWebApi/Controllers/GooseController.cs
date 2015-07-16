using System;
<<<<<<< HEAD
using System.Diagnostics;
=======
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
>>>>>>> Exception handling with G1
using System.Web.Http;
using LessComplexWebApi.Errors;

namespace LessComplexWebApi.Controllers
{
    [RoutePrefix("api/v1/goose")]
    public class GooseController : ApiController
    {
<<<<<<< HEAD
        // GET api/v1/goose/find/myname
        [HttpGet]
        [Route("find/{name}")]
        [NotFoundFilter]
        public IHttpActionResult FindGoose(string name)
        {
            FindGooldenGoose();
            return Ok();
        }

        public void FindGooldenGoose()
        {
            throw new NullReferenceException("This goose is not you are looking for.");
=======
        // GET api/v1/goose/findGoose?name="Golden goose"
        [HttpGet]
        [NotFoundFilter]
        [Route("findGoose", Name = "FindGoose")]
        public IHttpActionResult FindGoose(string name)
        {
            GoldenGoose(name);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateGoose(string name)
        {
            GoldenGoose(name);
            return CreatedAtRoute("FindGoose", new {name = name}, name);
        }

        private int GoldenGoose(string name)
        {
            throw new NullReferenceException("Golden goose is not found");
>>>>>>> Exception handling with G1
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LessComplexWebApi.Errors;

namespace LessComplexWebApi.Controllers
{
    [RoutePrefix("api/v1/goose")]
    public class GooseController : ApiController
    {
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
        }
    }
}

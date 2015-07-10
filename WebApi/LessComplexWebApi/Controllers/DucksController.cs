using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LessComplexWebApi.Models;

namespace LessComplexWebApi.Controllers
{
    [RoutePrefix("api/ducks")]
    public class DucksController : ApiController
    {
        private static readonly ICollection<Duck> Ducks = new List<Duck>();

        // GET /api/ducks/findDuck
        [HttpGet]
        [Route("{name}", Name = "findDuck")]
        public IHttpActionResult FindDuck(string name)
        {
            var foundDuck = Ducks.FirstOrDefault(b => b.Name == name);
            if (foundDuck == null)
                return BadRequest("This is not the bird you are looking for.");

            return Ok(foundDuck);
        }

        // POST api/ducks/create
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Post([FromBody] Duck bird)
        {
            if (bird == null || !ModelState.IsValid)
                return BadRequest();

            Ducks.Add(bird);

            return CreatedAtRoute("findDuck", new {name = bird.Name}, bird);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
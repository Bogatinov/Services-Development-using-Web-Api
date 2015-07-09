using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using LessComplexWebApi.Models;

namespace LessComplexWebApi.Controllers
{
    [RoutePrefix("api/ducks")]
    public class DucksController : ApiController
    {
        private static readonly ICollection<Duck> Ducks = new List<Duck>();

        // GET /api/ducks/findDuck
        [HttpGet]
        [Route("findDuck/{name}", Name = "findDuck")]
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

        //api/ducks/update?id=5
        [HttpPut]
        [Route("{id}", Name = "update")]
        public IHttpActionResult Put(int id, [FromBody] Duck bird)
        {
            if (id != bird.Id)
            {
                return BadRequest(string.Format("The id: {0} is different from expected", id));
            }
            var foundDuck = Ducks.FirstOrDefault(b => b.Id == id);
            if (foundDuck == null)
            {
                return NotFound();
            }
            try
            {
                Ducks.Remove(foundDuck);
                Ducks.Add(bird);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }

            return Ok("The duck has been updated");
        }

        // DELETE api/ducks/delete
        [HttpDelete]
        [Route("delete/{id}", Name = "delete")]
        public IHttpActionResult Delete(int id)
        {
            var foundDuck = Ducks.FirstOrDefault(d => d.Id == id);
            if (foundDuck == null)
                return NotFound();
            Ducks.Remove(foundDuck);
            return Ok("The duck has been deleted");
        }

    }
}
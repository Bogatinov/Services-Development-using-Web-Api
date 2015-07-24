using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class MoviesController : ApiController
    {
        private CinemaContext db = new CinemaContext();

        // GET: api/Movies
        public IQueryable<Movie> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetMovie(string name)
        {
            Movie movie = await db.Movies.Include(m => m.Ticket).FirstOrDefaultAsync(m => m.Name == name);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovie(string name, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (name != movie.Name)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(name))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await db.CreateMovie(movie);

            return CreatedAtRoute("DefaultApi", new { name = movie.Name }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> DeleteMovie(string name)
        {
            Movie movie = await db.Movies.FirstOrDefaultAsync(m => m.Name == name);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(string name)
        {
            return db.Movies.Count(e => e.Name == name) > 0;
        }
    }
}
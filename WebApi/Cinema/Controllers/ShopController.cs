using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Cinema.Models;

namespace Cinema.Controllers
{
    [RoutePrefix("api/v1/shop")]
    public class ShopController : ApiController
    {
        private CinemaContext _db = new CinemaContext();
        /*
         * ShopController
            1. Buy ticket
            2. Buy popcorn
            3. Buy soda
            4. Write tests for each method in Cinema.Tests
         */

        [HttpPut]
        [Route("{movieName}")]
        public async Task<IHttpActionResult> BuyTicket(string movieName)
        {
            var invoice = new Invoice();
            var movie = await _db.Movies.Include(m=>m.Ticket).FirstOrDefaultAsync(m => m.Name == movieName);
            if (movie == null)
                return BadRequest("You tried to buy ticket from non existing movie");

            if (movie.Ticket.Quantity > 0)
            {
                if (invoice.Tickets.Count <= 3)
                {
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Friday && DateTime.Now <= new DateTime(2015, 9, 15))
                    {
                        var popcorn = await _db.Foods.FirstOrDefaultAsync(f => f.Name == "popcorn");
                        popcorn.Quantity--;
                        
                        var newPopcorn = invoice.Items.FirstOrDefault(i => i.Id == popcorn.Id);
                        if (newPopcorn != null)
                            newPopcorn.Quantity++;
                        
                        newPopcorn = new Food()
                        {
                            Name = "popcorn",
                            Price = 0,
                            Weight = popcorn.Weight,
                            Quantity = 1
                        };
                        invoice.Items.Add(newPopcorn);
                    }
                    if (DateTime.Now <= new DateTime(2015, 09, 18) &&
                        DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        invoice.Price += movie.Ticket.Price - movie.Ticket.Price*0.3;
                    }
                }
                if (invoice.Tickets.Count == 4)
                {
                    invoice.Price = 0;
                    foreach (var previousTickets in invoice.Tickets)
                    {
                        invoice.Price += previousTickets.Price;
                    }
                    invoice.Price += movie.Ticket.Price;
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Monday && DateTime.Now <= new DateTime(2015,9,10))
                    {
                        var sodas = await _db.Drinks.FirstOrDefaultAsync(d => d.Name == "soda");
                        sodas.Quantity -= 2;
                        invoice.Items.Add(new Drink()
                        {
                            Name = sodas.Name,
                            Price = 0,
                            Liters = sodas.Liters,
                            Quantity = 2
                        });
                    }
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Friday && DateTime.Now <= new DateTime(2015, 9, 15))
                    {
                        invoice.Price -= invoice.Price * 0.3;
                    }
                }

                invoice.Tickets.Add(movie.Ticket);
                movie.Ticket.Quantity--;
            }
            else
                return BadRequest("No more tickets for this movie");

            _db.Entry(movie.Ticket).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Ok(movie.Ticket);
        }
    }
}

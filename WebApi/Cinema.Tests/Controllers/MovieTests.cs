using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http.Results;
using Cinema.Controllers;
using Cinema.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Cinema.Tests.Controllers
{
    [TestClass]
    public class MovieTests
    {
        // STUBBING vs MOCKING
        [TestMethod]
        [TestCategory("Positive tests")]
        public async Task CanCreateMovie()
        {
            //Arrange
            var controller = new MoviesController();
            var movieName = "Superman";
            var movie = new Movie
            {
                Name = movieName,
                Rating = 11,
                Ticket = new Ticket()
                {
                    Price = 0.99
                }
            };

            var actionResult = await controller.PostMovie(movie)
                               as CreatedAtRouteNegotiatedContentResult<Movie>;

            Assert.AreEqual(movieName, actionResult.Content.Name);

            await controller.DeleteMovie(movieName);
        }

        [TestMethod]
        [TestCategory("Positive tests")]
        public async Task CanDeleteMovie()
        {
            //Arrange
            var controller = new MoviesController();
            var movie = new Movie()
            {
                Name = "Superman",
                Rating = 11
            };
            movie.Ticket = new Ticket()
            {
                Price = 0.99
            };
            await controller.PostMovie(movie);

            var actionResult = await controller.DeleteMovie(movie.Name);
            
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Movie>));

            await controller.DeleteMovie(movie.Name);
        }

        [TestMethod]
        [TestCategory("Negative tests")]
        public async Task CanNotDeleteNotExistingMovie()
        {
            var controller = new MoviesController();
            var movieName = "SomeRandomMovieYouWillNeverBeAbleToFind";

            var actionResult = await controller.DeleteMovie(movieName);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}

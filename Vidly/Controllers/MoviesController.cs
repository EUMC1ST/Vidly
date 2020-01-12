using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private Movie movie;
        private List<Customer> customers = new List<Customer>
        {
                new Customer{ Id = 1, Name = "Edgar" },
                new Customer{ Id = 2, Name = "Anahi"}
        };
        private List<Movie> movies = new List<Movie>
        {
                new Movie { Id = 1, Name = "IT"},
                new Movie { Id = 2, Name = "Evil"},
                new Movie { Id = 3, Name = "Aro"}
        };

        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }


        public ActionResult GetMovieDetails(int id)
        {
            foreach (var movie in GetMovies())
            {
                if (movie.Id == id)
                {
                    this.movie = movie;
                }
            }
            return View("Details",movie);
        }
        private List<Movie> GetMovies()
        {
            return movies;
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "IT",
                Id = 1
            };

            var viewModel = new RandomMovieViewModel{
                Movie = movie,
                Customers = customers
            };

            return View(movie);
        }
    }
}
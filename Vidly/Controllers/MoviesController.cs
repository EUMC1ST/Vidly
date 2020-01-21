using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public Model _context;
        public MoviesController()
        {
            _context = new Model();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            //var movies = GetMovies();
            return View(movies);
        }


        public ActionResult GetMovieDetails(int id)
        {
            var movieDetails = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id); //Where(m => m.Id == id).Include(m => m.Genre);
            //foreach (var movie in GetMovies())
            //{
            //    if (movie.Id == id)
            //    {
            //        this.movie = movie;
            //    }
            //}
            return View("Details",movieDetails);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {

            //var viewModel = new RandomMovieViewModel{
            //    Movie = movie,
            //    Customers = customers
            //};

            return View();
        }
    }
}
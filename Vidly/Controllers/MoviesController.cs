using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            //var movies = GetMovies();
            return View(movies);
        }



        [HttpGet]
        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel()
            {
                GenreTypes = _context.GenreTypes.AsEnumerable()
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
                //New Movie
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }   
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException Exception)
            {
                return HttpNotFound(Exception.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
                //throw;
            }
            
            return RedirectToAction("Index","Movies");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel()
            {
                GenreTypes = _context.GenreTypes.AsEnumerable(),
                Movie = movie
            };
            return View("MovieForm",viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
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
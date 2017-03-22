using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ViewResult Random()
        {
            var movie = new Movies() { name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer1" },
                new Customer { Name = "Customer2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult edit(int id)
        {
            Movies movie = _context.Movies.SingleOrDefault(m => m.id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        //public ActionResult index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        [Route("movies/released/{year:regex(2016|2017)}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                Action = "New"
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movies Movie)
        {
            if (Movie.id == 0)
                _context.Movies.Add(Movie);
            else
            {
                var MovieInDB = _context.Movies.Single(m => m.id == Movie.id);
                MovieInDB.name = Movie.name;
                MovieInDB.ReleaseDate = Movie.ReleaseDate;
                MovieInDB.GenreId = Movie.GenreId;
                MovieInDB.NumberInStock = Movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MyDBContext _Context;
        private List<Movie> movies;

       public MoviesController()
        {
            _Context = new MyDBContext();
            movies = _Context.Movies.Include(x => x.Genre).ToList();
        }




        // GET: Movies
        public ActionResult Index()
        {
            return View(movies);
        }




        //GET:Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "ABC" };
            List<Customer> customers= new List<Customer>{ 
                new Customer{ Name="Customer 1" },
                new Customer{ Name="Customer 2" }
            };
            var viewmodel = new RandomMovieViewModel
            {
                customers=customers,
                movie=movie
            };
            return View(viewmodel);
        }

        public ActionResult Details(int Id)
        {
            var movie = movies.SingleOrDefault(m => m.Id == Id);
            if(movie!=null)
                return View(movie);
            return HttpNotFound();
        }

         
        public ActionResult Edit(int id)
        {
            return Content("Id=" + id);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year+"/"+month);
        }

        
    }
}
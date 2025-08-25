using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC9.Repository;
using CC9.Models;
namespace CC9.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _movieRepository.GetAll();
            return View(movies);
        }

        public MovieController()
        {
            _movieRepository = new MovieRepository();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        
        public ActionResult Edit(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        
        public ActionResult Delete(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _movieRepository.Delete(id);
            return RedirectToAction("Index");
        }

        
        public ActionResult ByYear(int? year)
        {
            if (!year.HasValue)
            {
                return RedirectToAction("Index"); 
            }

            var movies = _movieRepository.GetByYear(year.Value);
            ViewBag.Year = year.Value;
            return View(movies);
        }

        
       

        public ActionResult ByDirector(string director)
        {
            
            var movies = _movieRepository.GetByDirector(director);
            ViewBag.Director = director;
            return View(movies);
        }


    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System.Collections.Generic;

namespace MovieTickets.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository movieRepo;

        public MovieController(IMovieRepository movieRepo)
        {
            this.movieRepo=movieRepo;


        }



        // To get All Movies
        public ActionResult Index()
        {

            List<Movie> movies= movieRepo.GetAll();

            return View();
        }

        // To Get Movie by ID
        public ActionResult Details(int id)
        {

            Movie movie= movieRepo.GetById(id);
            return View();
        }


        //To get Movie by name
        public ActionResult Details(string name)
        {

            Movie movie = movieRepo.GetByName(name);
            return View();
        }


        // To add new movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                int numOfRowsInsertion = movieRepo.insert(newMovie);
                return View();
            }

            return RedirectToAction();
        }



        // To Edit any Movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie editMovie, int id)
        {
            if (ModelState.IsValid)
            {
                int numOfRowsUpdated=movieRepo.update(editMovie,id);
                return View();
            }
            return RedirectToAction();

        }

        // POST: MovieController/Edit/5



        // To delete movies
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int numOfRowsDeleted= movieRepo.delete(id); 
            return View();
        }

        // POST: MovieController/Delete/5
        
        
    }
}

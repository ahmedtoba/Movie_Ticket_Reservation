using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieTickets.Models;
using MovieTickets.Services;
using MovieTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieContext db;
        IMovieRepository movieRepo;

        public MovieController(MovieContext db ,IMovieRepository movieRepo, ICategoryRepository categoryRepo, ICinemaRepository cinemaRepo)
        {
            this.db = db;
            this.movieRepo=movieRepo;


        }



        // To get All Movies
        public ActionResult Index()
        {

            List<Movie> movies= movieRepo.GetAll();

            return View();
        }

        // To Get Movie by ID
        public ActionResult Details(Guid id)
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
        //get method opening create page
        public IActionResult Create()
        {
            ViewBag.Cinemas = new SelectList(db.Cinemas.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            ViewBag.Actors = new SelectList(db.Actors.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(db.Producers.ToList(), "Id", "Name");

            return View(new MovieViewModel());

        }



        // post create method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieViewModel movievm)
        {
            if (ModelState.IsValid)
            {
                movieRepo.Insert(movievm);
                return RedirectToAction();
            }


            ViewBag.Cinemas = new SelectList(db.Cinemas.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            ViewBag.Actors = new SelectList(db.Actors.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(db.Producers.ToList(), "Id", "Name");
            return View(movievm);

        }



        // To Edit any Movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie editMovie, Guid id)
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
        public ActionResult Delete(Guid id)
        {
            int numOfRowsDeleted= movieRepo.delete(id); 
            return View();
        }

        // POST: MovieController/Delete/5
        
        
    }
}

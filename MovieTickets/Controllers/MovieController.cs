﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieTickets.Models;
using MovieTickets.Services;
using MovieTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieContext db;
        IMovieRepository movieRepo;
        private readonly ICategoryRepository categoryRepo;
        private readonly ICinemaRepository cinemaRepo;
        private readonly IProducerRepository produerService;
        private readonly IActorRepository actorService;
        private readonly IMovieActorRepository movieactorService;
        private readonly IMovieInCinemaRepository movieincinemaService;

        public MovieController(MovieContext db, IMovieRepository movieRepo,
            ICategoryRepository categoryRepo, ICinemaRepository cinemaRepo,
            IProducerRepository produerService, IActorRepository actorService,
            IMovieActorRepository movieactorService, IMovieInCinemaRepository movieincinemaService)
        {
            this.db = db;
            this.movieRepo = movieRepo;
            this.categoryRepo = categoryRepo;
            this.cinemaRepo = cinemaRepo;
            this.produerService = produerService;
            this.actorService = actorService;
            this.movieactorService = movieactorService;
            this.movieincinemaService = movieincinemaService;
        }



        // To get All Movies
        public ActionResult Index()
        {


            MovieItemViewModel mivm = new MovieItemViewModel()
            {
                Movies = movieRepo.GetAll(),
                Producers = produerService.GetAll(),
                Cinemas = cinemaRepo.GetAll(),
                Actors = actorService.GetAll(),
                Categories = categoryRepo.GetAll(),
                MovieActors = movieactorService.GetAll()

            };

            return View("IndexUser", mivm);
        }
<<<<<<< HEAD
        //searching by categories-------------------------
        [HttpGet]
        public async Task<IActionResult> filterSearch(string MovieName)
        {
            ViewData["MovieName"] = MovieName;
           
            if (!string.IsNullOrEmpty(MovieName))
            {
                var movies = new MovieItemViewModel()
                {
                    Movies = db.Movies.Where(c => c.Name.Contains(MovieName)).ToList(),
                    Producers = produerService.GetAll(),
                    Cinemas = cinemaRepo.GetAll(),
                    Actors = actorService.GetAll(),
                    Categories = categoryRepo.GetAll(),
                    MovieActors = movieactorService.GetAll()
                };

                //movie = movie;
                return View("IndexUser", movies);


            }
            return Content("nothing");

        }

        //search by name or actor-------------------
        [HttpGet]
        public async Task<IActionResult> movieSearch(string Keyword)
        {
            ViewData["searching"] = Keyword;
            var movies = db.Movies.Select(x => x);
            if (!string.IsNullOrEmpty(Keyword))
            {
                movies = movies.Where(c => c.Name.Contains(Keyword));

            }
            return View(await movies.AsNoTracking().ToListAsync());
        }
=======
>>>>>>> 16ac73ffb7ed4f4591e070670ffbf15c5da1e3a2

        public ActionResult GetMoviesAdmin()
        {
            List<Movie> MovieView = movieRepo.GetAll();

            return View("AdminMovie", MovieView);

        }

        public ActionResult GetMoviesDetailsAdmin(Guid id)

        {
            MovieViewModel Moviemodel = movieRepo.GetMovieByIdAdmin(id);

            ViewBag.Cinemas = new SelectList(db.Cinemas.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            ViewBag.Actors = new SelectList(db.Actors.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(db.Producers.ToList(), "Id", "Name");





            return View("MovieDetailsAdmain", Moviemodel);
        }




        // To Get Movie by ID
        public ActionResult Details(Guid id)
        {
            MovieDetailsViewModel mdvm = new MovieDetailsViewModel()
            {
                Movie = movieRepo.GetById(id),
                MovieActors = movieactorService.GetAll().Where(w => w.MovieId == id).ToList(),
                MoviesInCinemas = movieincinemaService.GetAll().Where(w => w.MovieId == id).ToList()
            };

            return View("DetailsUser", mdvm);
        }


        //To get Movie by name
        //public ActionResult Details(string name)
        //{
        //    Movie movie = movieRepo.GetByName(name);
        //    return View();
        //}

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
        public IActionResult Create(MovieViewModel movievm, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                movieRepo.Insert(movievm, Image);
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
        public ActionResult Edit(MovieViewModel editMovie, Guid id, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                Task<int> numOfRowsUpdated = movieRepo.update(editMovie, id, Image);
                return View("AdminMovie");
            }
            ViewBag.Cinemas = new SelectList(db.Cinemas.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            ViewBag.Actors = new SelectList(db.Actors.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(db.Producers.ToList(), "Id", "Name");

            return RedirectToAction("Edit");

        }


        public ActionResult EditMovieFromAdmin(Guid id)

        {

            MovieViewModel Moviemodel = movieRepo.GetMovieByIdAdmin(id);

            ViewBag.Cinemas = new SelectList(db.Cinemas.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            ViewBag.Actors = new SelectList(db.Actors.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(db.Producers.ToList(), "Id", "Name");



            return View("Edit", Moviemodel);
        }

        // POST: MovieController/Edit/5



        // To delete movies
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            int numOfRowsDeleted = movieRepo.delete(id);
            return View();
        }

        // POST: MovieController/Delete/5


    }
}
